using System;
using System.Collections.Generic;

namespace Data.Dto.Vencoin
{
    public class VencoinTransactionDto
    {
        public Guid VencoinId { get; set; }
        public string Cancel { get; set; }
    }

    public class TransactionDaily
    {
        public TransactionDaily()
        {
            IsSave = true;
        }
        public List<DataTransactionCompleteForPayment> DataTransactionCompleteForPayment { get; set; } = new List<DataTransactionCompleteForPayment>();
        public List<DataTransactionNotCompleteForPayment> DataTransactionNotCompleteForPayment { get; set; } = new List<DataTransactionNotCompleteForPayment>();
        public bool IsSave { get; set; }
    }

    public class DataTransactionCompleteForPayment
    {
        public Guid UserId { get; set; }
        public double Amount { get; set; }
        public string BuyOrSale { get; set; }
    }

    public class DataTransactionNotCompleteForPayment
    {
        public Guid UserId { get; set; }
        public double Amount { get; set; }
        public string BuyOrSale { get; set; }
        public long Dispute { get; set; }
        public long Total { get; set; }
    }
}
