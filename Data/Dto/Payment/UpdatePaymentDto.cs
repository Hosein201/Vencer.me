namespace Data.Dto.Payment
{
    public class UpdatePaymentDto
    {
        public string Authority { get; set; }
        public long Amount { get; set; }
        public string RefID { get; set; }
        public bool IsComplete { get; set; }
    }
}
