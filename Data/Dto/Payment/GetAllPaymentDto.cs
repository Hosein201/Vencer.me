using System;

namespace Data.Dto.Payment
{
    public class GetAllPaymentDto
    {
        public string Amount { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public string WherePayment { get; set; }
        public bool IsComplete { get; set; }
        public bool IsSite { get; set; }
        public string RefID { get; set; }
    }
}
