using System;
using System.Collections.Generic;

namespace Data.Dto.Vencoin
{
    public class ReportVencoin
    {
        public long TotalClient { get; set; }
        public long TotalVolume { get; set; }
        public long Price { get; set; }

    }

    public class DataLineReport
    {
        public long TotalVolume { get; set; }
        public long Price { get; set; }
    }

    public class ResultLineReport
    {
        public List<DataLineReport> Sales { get; set; } = new List<DataLineReport>();
        public List<DataLineReport> Buys { get; set; } = new List<DataLineReport>();
    }

    public class ResultAreaReport
    {
        public List<DataAreaReport> Sales { get; set; } = new List<DataAreaReport>();
        public List<DataAreaReport> Buys { get; set; } = new List<DataAreaReport>();
    }

    public class DataAreaReport
    {
        public long TotalVolume { get; set; }
        public long Price { get; set; }
        public DateTime RegisterDate { get; set; }
    }

    public class ResultColumnReport
    {
        public List<DataColumnReport> Sales { get; set; } = new List<DataColumnReport>();
        public List<DataColumnReport> Buys { get; set; } = new List<DataColumnReport>();
    }

    public class DataColumnReport
    {
        public long TotalVolume { get; set; }
        public int DateYear { get; set; }
        public int DateMonth { get; set; }
    }

    public class ReportTicker
    {
        public long MaxSalePrice { get; set; }
        public long MinSalePrice { get; set; }
        public long MaxBuyPrice { get; set; }
        public long MinBuyPrice { get; set; }
        public DateTime LastTransactionTime { get; set; }
    }
}
