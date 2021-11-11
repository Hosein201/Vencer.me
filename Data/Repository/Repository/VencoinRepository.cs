using Common.Interface;
using Common.Utilities;
using Data.Dto.Vencoin;
using Data.Model;
using Kendo.DynamicLinqCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository.Repository
{
    public class VencoinRepository : Repository<Vencoin>, IVencoinRepository, IScopedDependency
    {
        private readonly VencerDbContext _dbContext;
        public VencoinRepository(VencerDbContext dbContext)
            : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        private async Task AddVencoin(int condition, long price, long total, int saleOrBuy, Guid userId, bool cancel, bool complete, CancellationToken cancellationToken)
        {
            var vencore = new Vencoin()
            {
                UserId = userId,
                Condition = condition,
                Price = price,
                Total = total,
                TypeSaleOrBuy = saleOrBuy,
                Cancel = cancel,
                Complete = complete,
            };
            await AddAsync(vencore, cancellationToken);
        }

        public async Task<TransactionDaily> CreateVencoin(VencoinCondition condition, string price, string total, VencoinTypeSaleOrBuy saleOrBuy, Guid userId, CancellationToken cancellationToken)
        {
            var result = new TransactionDaily();
            switch (condition)
            {
                case VencoinCondition.Now: // شرط زمان نداشت در همان لحظه باید خرید یا فروش انجام شود
                    switch (saleOrBuy)
                    {
                        case VencoinTypeSaleOrBuy.Buy:  // خرید   1 
                            result = await TransactionNow(long.Parse(price), long.Parse(total), 0, userId, 1, cancellationToken);
                            break;

                        case VencoinTypeSaleOrBuy.Sale: // فروش  0
                            result = await TransactionNow(long.Parse(price), long.Parse(total), 1, userId, 0, cancellationToken);
                            break;
                        default:
                            result.IsSave = false;
                            return result;
                    }
                    break;
                case VencoinCondition.OneDay:
                case VencoinCondition.TwoDay:
                case VencoinCondition.ThreeDay:
                case VencoinCondition.FourDay:
                case VencoinCondition.FiveDay:
                case VencoinCondition.SixDay:
                case VencoinCondition.SevenDay:
                case VencoinCondition.WaitingLine:
                    await AddVencoin((int)condition, long.Parse(price), long.Parse(total), (int)saleOrBuy, userId, false, false, cancellationToken);
                    break;
                default:
                    result.IsSave = false;
                    return result;
            }
            return result;
        }

        private async Task<TransactionDaily> TransactionNow(long price, long totalUser, int saleOrBuyTransaction, Guid userId, int saleOrBuy, CancellationToken cancellationToken)
        {
            var result = new TransactionDaily();
            var listUpdateVencoin = new List<Vencoin>();
            long dbVencoinTotal = 0;
            bool whileCheck = true;

            var sumTotal = TableNoTracking.OrderByDescending(o => o.RegisterDate)
                 .Where(w => !w.Complete && !w.Cancel && w.TypeSaleOrBuy == saleOrBuyTransaction &&
                             w.UserId != userId && (w.Condition == 0 || w.Condition == 8) && w.Price == price)
                  .Sum(s => s.Total);
            if (sumTotal == 0)
            {
                await AddVencoin(8, price, totalUser, (int)saleOrBuy, userId, false, false, cancellationToken);
                return result;
            }
            var listVenDb = await Table.OrderByDescending(o => o.RegisterDate)
                  .Where(w => !w.Complete && !w.Cancel && w.TypeSaleOrBuy == saleOrBuyTransaction && w.UserId != userId &&
                              (w.Condition == 0 || w.Condition == 8) && w.Price == price)
                  .ToListAsync(cancellationToken);

            startWhile:
            while (whileCheck)
            {
                foreach (var vencoin in listVenDb)
                {
                    if (vencoin.Total == totalUser)
                    {
                        vencoin.Complete = true;
                        vencoin.ModifyDate = DateTime.Now;
                        listUpdateVencoin.Add(vencoin);
                        dbVencoinTotal = 0;
                        whileCheck = false;
                        result.DataTransactionCompleteForPayment.Add(new DataTransactionCompleteForPayment()
                        {
                            UserId = vencoin.UserId,
                            Amount = vencoin.Price,
                            BuyOrSale = saleOrBuy == 0 ? "sale" : "buy"

                        });
                        goto startWhile;
                    }
                    if (vencoin.Total > totalUser)
                    {
                        var total = vencoin.Total;
                        var newTotal = vencoin.Total - totalUser;
                        var dispute = vencoin.Total - newTotal;

                        dbVencoinTotal = dispute;
                        vencoin.Total = newTotal;

                        vencoin.Complete = false;
                        result.DataTransactionNotCompleteForPayment.Add(new DataTransactionNotCompleteForPayment()
                        {
                            BuyOrSale = saleOrBuy == 0 ? "sale" : "buy",
                            UserId = vencoin.UserId,
                            Amount = vencoin.Price,
                            Dispute = dispute,
                            Total = total
                        });
                        listUpdateVencoin.Add(vencoin);
                    }
                };
                whileCheck = false;
            }

            await AddVencoin(dbVencoinTotal == 0 ? 0 : 8, price, totalUser, (int)saleOrBuy, userId, false, true, cancellationToken);
            result.DataTransactionCompleteForPayment.Add(new DataTransactionCompleteForPayment()
            {
                UserId = userId,
                Amount = price,
                BuyOrSale = saleOrBuy == 0 ? "sale" : "buy"

            });
            UpdateRange(listUpdateVencoin);
            return result;
        }

        public async Task<bool> CancelTransaction(VencoinTransactionDto transactionDto, Guid userId, CancellationToken cancellationToken)
        {
            var vencoin = await Table.FirstOrDefaultAsync(f => f.UserId == userId && !f.Cancel && f.Id == transactionDto.VencoinId, cancellationToken);
            if (vencoin == null)
                return false;
            if (vencoin.Complete)
                throw new AppException(ApiResultStatusCode.NotFound, "این تراکنش قابلیت کنسل شدن را ندارد");

            vencoin.Cancel = true;
            Update(vencoin);
            return true;
        }

        public async Task<TransactionDaily> JobTransactionDailyVencoin(CancellationToken cancellationToken = default)
        {
            var updateVencoinSales = new List<Vencoin>();
            var updateVencoinBuys = new List<Vencoin>();
            var result = new TransactionDaily();

            var dataTimeNow = DateTime.Now.Date;

            var dataGroup = await Task.Run(() => Table.OrderBy(o => o.RegisterDate)
                 .Where(w => !w.Complete && !w.Cancel && w.Condition == 1 && (w.RegisterDate.Date.AddDays(-1) == dataTimeNow))
                .Select(f => f).ToList().GroupBy(g => new { g.Price }).ToList(), cancellationToken);

            foreach (var item in dataGroup)
            {
                var vencoins = item.ToList();

                if (vencoins.Any(a => a.TypeSaleOrBuy == 0) && vencoins.Any(a => a.TypeSaleOrBuy == 1))
                {
                    var sales = vencoins.Where(w => w.TypeSaleOrBuy == 0).ToList();
                    var buys = vencoins.Where(w => w.TypeSaleOrBuy == 1).ToList();
                    startForeach:
                    foreach (var sale in sales.ToList())
                    {
                        foreach (var buy in buys.ToList())
                        {
                            if (sale.UserId != buy.UserId)
                            {
                                if (sale.Total == buy.Total)
                                {
                                    sale.Complete = true;
                                    buy.Complete = true;

                                    sale.ModifyDate = DateTime.Now;
                                    buy.ModifyDate = DateTime.Now;

                                    result.DataTransactionCompleteForPayment.Add(new DataTransactionCompleteForPayment() { UserId = sale.UserId, Amount = sale.Price, BuyOrSale = "sale" });

                                    result.DataTransactionCompleteForPayment.Add(new DataTransactionCompleteForPayment() { UserId = buy.UserId, Amount = buy.Price, BuyOrSale = "buy" });

                                    updateVencoinSales.Add(sale);
                                    updateVencoinBuys.Add(buy);

                                    sales.Remove(sale);
                                    buys.Remove(buy);
                                    goto startForeach;
                                }

                                if (sale.Total > buy.Total)
                                {
                                    var total = sale.Total;

                                    var newTotal = sale.Total - buy.Total;
                                    var dispute = sale.Total - newTotal;
                                    sale.Total = newTotal;

                                    sale.Complete = false;
                                    buy.Complete = true;
                                    buy.ModifyDate = DateTime.Now;

                                    if (updateVencoinSales.All(a => a.Id != sale.Id))
                                        updateVencoinSales.Add(sale);
                                    else
                                    {
                                        var oldSale = updateVencoinSales.FirstOrDefault(a => a.Id == sale.Id);
                                        oldSale.Total = sale.Total;

                                        updateVencoinSales.Remove(oldSale);
                                        updateVencoinSales.Add(oldSale);
                                    }
                                    result.DataTransactionCompleteForPayment.Add(new DataTransactionCompleteForPayment()
                                    {
                                        UserId = buy.UserId,
                                        Amount = buy.Price,
                                        BuyOrSale = "buy"
                                    });

                                    result.DataTransactionNotCompleteForPayment.Add(new DataTransactionNotCompleteForPayment()
                                    {
                                        UserId = sale.UserId,
                                        Amount = sale.Price,
                                        BuyOrSale = "sale",
                                        Dispute = dispute,
                                        Total = total
                                    });

                                    updateVencoinBuys.Add(buy);
                                    buys.Remove(buy);
                                    goto startForeach;
                                }

                                if (sale.Total < buy.Total)
                                {
                                    var total = buy.Total;
                                    var newTotal = buy.Total - sale.Total;
                                    var dispute = buy.Total - newTotal;
                                    buy.Total = newTotal;

                                    sale.Complete = true;
                                    buy.Complete = false;

                                    sale.ModifyDate = DateTime.Now;


                                    if (updateVencoinBuys.All(a => a.Id != sale.Id))
                                        updateVencoinBuys.Add(sale);
                                    else
                                    {
                                        var oldBuy = updateVencoinBuys.FirstOrDefault(a => a.Id == sale.Id);
                                        oldBuy.Total = buy.Total;

                                        updateVencoinBuys.Remove(oldBuy);
                                        updateVencoinBuys.Add(oldBuy);
                                    }
                                    result.DataTransactionCompleteForPayment.Add(new DataTransactionCompleteForPayment()
                                    {
                                        UserId = sale.UserId,
                                        Amount = sale.Price,
                                        BuyOrSale = "sale"
                                    });

                                    result.DataTransactionNotCompleteForPayment.Add(new DataTransactionNotCompleteForPayment()
                                    {
                                        UserId = buy.UserId,
                                        Amount = buy.Price,
                                        BuyOrSale = "buy",
                                        Dispute = dispute,
                                        Total = total

                                    });

                                    updateVencoinSales.Add(sale);
                                    sales.Remove(sale);
                                    goto startForeach;
                                }
                            }
                            else
                            {
                                var disSales = sales.Select(s => s.UserId).Distinct().ToList();
                                var disBuys = buys.Select(s => s.UserId).Distinct().ToList();
                                if (disBuys.Count > 0 || disSales.Count > 0)
                                {
                                    buys.Reverse();
                                    sales.Reverse();
                                    goto startForeach;
                                }
                            }
                        }
                    }

                }
            }
            UpdateRange(updateVencoinBuys);
            UpdateRange(updateVencoinSales);

            return result;
        }

        #region Reports
        public DataSourceResult GetAllTransactionUser(DataSourceRequest dataSourceRequest, Guid userId)
        {
            return TableNoTracking.OrderByDescending(o => o.RegisterDate).Where(w => w.UserId == userId).ToDataSourceResult(dataSourceRequest);
        }

        public DataSourceResult GetReportVencoinBuyGrid(DataSourceRequest dataSourceRequest)
        {
            var data = TableNoTracking.OrderByDescending(o => o.Price)
                .Where(w => !w.Complete && !w.Cancel)
                .Select(f => f);

            var groupByBuys = data.Where(w => w.TypeSaleOrBuy == 1)
                .GroupBy(g => new { g.Price })
                .Select(s => new ReportVencoin()
                {
                    Price = s.Key.Price,
                    TotalClient = s.Count(),
                    TotalVolume = s.Sum(sum => sum.Total)
                }).OrderBy(o => o.Price).ToDataSourceResult(dataSourceRequest);
            return groupByBuys;
        }

        public DataSourceResult GetReportVencoinSaleGrid(DataSourceRequest dataSourceRequest)
        {
            var data = TableNoTracking.OrderByDescending(o => o.Price)
                .Where(w => !w.Complete && !w.Cancel)
                .Select(f => f);

            var groupBySales = data.Where(w => w.TypeSaleOrBuy == 0)
                .GroupBy(g => new { g.Price })
                .Select(s => new ReportVencoin()
                {
                    Price = s.Key.Price,
                    TotalClient = s.Count(),
                    TotalVolume = s.Sum(sum => sum.Total)
                }).OrderBy(o => o.Price).ToDataSourceResult(dataSourceRequest);

            return groupBySales;
        }

        public async Task<ResultLineReport> GetReportLineChart(CancellationToken cancellationToken)
        {
            var resultSales = await TableNoTracking.Where(w => !w.Complete && !w.Cancel && w.TypeSaleOrBuy == 0).OrderByDescending(s => s.Price)
                .GroupBy(g => new { g.Price })
                .Select(s => new DataLineReport()
                {
                    Price = s.Key.Price,
                    TotalVolume = s.Sum(sum => sum.Total),
                }).ToListAsync(cancellationToken);

            var resultBuys = await TableNoTracking.Where(w => !w.Complete && !w.Cancel && w.TypeSaleOrBuy == 1).OrderByDescending(s => s.Price)
                .GroupBy(g => new { g.Price })
                .Select(s => new DataLineReport()
                {
                    Price = s.Key.Price,
                    TotalVolume = s.Sum(sum => sum.Total),
                }).ToListAsync(cancellationToken);
            return new ResultLineReport() { Buys = resultBuys, Sales = resultSales };
        }

        public async Task<ResultAreaReport> GetReporAreaChart(CancellationToken cancellationToken)
        {
            var resultSales = await TableNoTracking.Where(w => !w.Complete && !w.Cancel && w.TypeSaleOrBuy == 0).OrderByDescending(s => s.Price)
                .GroupBy(g => new { g.Price, g.RegisterDate })
                .Select(s => new DataAreaReport()
                {
                    Price = s.Key.Price,
                    TotalVolume = s.Sum(sum => sum.Total),
                    RegisterDate = s.Key.RegisterDate
                }).ToListAsync(cancellationToken);

            var resultBuys = await TableNoTracking.Where(w => !w.Complete && !w.Cancel && w.TypeSaleOrBuy == 1).OrderByDescending(s => s.Price)
                .GroupBy(g => new { g.Price, g.RegisterDate })
                .Select(s => new DataAreaReport()
                {
                    Price = s.Key.Price,
                    TotalVolume = s.Sum(sum => sum.Total),
                    RegisterDate = s.Key.RegisterDate

                }).ToListAsync(cancellationToken);
            return new ResultAreaReport() { Buys = resultBuys, Sales = resultSales };
        }

        public async Task<ResultColumnReport> GetReportColumnChart(CancellationToken cancellationToken)
        {
            var resultSales = await TableNoTracking.Where(w => !w.Complete && !w.Cancel && w.TypeSaleOrBuy == 0).OrderByDescending(s => s.Price)
                .GroupBy(g => new { g.RegisterDate.Year, g.RegisterDate.Month })
                .Select(s => new DataColumnReport()
                {
                    TotalVolume = s.Sum(sum => sum.Total),
                    DateMonth = s.Key.Month,
                    DateYear = s.Key.Year
                }).ToListAsync(cancellationToken);

            var resultBuys = await TableNoTracking.Where(w => !w.Complete && !w.Cancel && w.TypeSaleOrBuy == 1).OrderByDescending(s => s.Price)
                .GroupBy(g => new { g.RegisterDate.Year, g.RegisterDate.Month })
                .Select(s => new DataColumnReport()
                {
                    TotalVolume = s.Sum(sum => sum.Total),
                    DateMonth = s.Key.Month,
                    DateYear = s.Key.Year
                }).ToListAsync(cancellationToken);

            return new ResultColumnReport() { Buys = resultBuys, Sales = resultSales };
        }

        public async Task<ReportTicker> GetReportTicker(CancellationToken cancellationToken)
        {
            var lastTransactionTime = await TableNoTracking.Where(w => w.Complete && !w.Cancel)
                .OrderByDescending(o => o.ModifyDate)
                .Select(s => s.ModifyDate).FirstOrDefaultAsync(cancellationToken);

            var maxSelePrice = await TableNoTracking.Where(w => !w.Complete && !w.Cancel && w.TypeSaleOrBuy == 0)
                .OrderByDescending(o => o.Price)
                .Select(s => s.Price).FirstOrDefaultAsync(cancellationToken);

            var minSalePrice = await TableNoTracking.Where(w => !w.Complete && !w.Cancel && w.TypeSaleOrBuy == 0)
                .OrderBy(o => o.Price)
                .Select(s => s.Price).FirstOrDefaultAsync(cancellationToken);

            var maxBuyPrice = await TableNoTracking.Where(w => !w.Complete && !w.Cancel && w.TypeSaleOrBuy == 1)
                .OrderByDescending(o => o.Price)
                .Select(s => s.Price).FirstOrDefaultAsync(cancellationToken);

            var minBuyPrice = await TableNoTracking.Where(w => !w.Complete && !w.Cancel && w.TypeSaleOrBuy == 1)
                .OrderBy(o => o.Price)
                .Select(s => s.Price).FirstOrDefaultAsync(cancellationToken);

            return new ReportTicker()
            {
                LastTransactionTime = lastTransactionTime,
                MaxBuyPrice = maxBuyPrice,
                MinBuyPrice = minBuyPrice,
                MaxSalePrice = maxSelePrice,
                MinSalePrice = minSalePrice
            };
        }

        public DataSourceResult GetVolumeVencoinOfUsers(DataSourceRequest dataSourceRequest ,Guid userId )
        {
            var result = TableNoTracking.Where(w => !w.Cancel && w.UserId==userId).OrderByDescending(o => o.RegisterDate)
                .GroupBy(g => new { g.Price , g.UserId})
                .Select(s => new
                {
                    Total = s.Sum(sum=> sum.Total),
                    Price = s.Key.Price,

                }).ToDataSourceResult(dataSourceRequest);

            return result;
        }
        #endregion
    }
}