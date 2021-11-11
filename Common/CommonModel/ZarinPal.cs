using System;

namespace Common.CommonModel
{
    public class ZarinPalRequest
    {
        public string MerchantID { get; set; }
        public string Amount { get; set; }
        public string CallbackURL { get; set; }
        public string Mobile { get; set; }
        public string Description { get; set; }
    }
    public class ZarinPalRequestResponse
    {
        public int Status { get; set; }
        public string Authority { get; set; }
    }


    //---------------
    public class ZarinPalVerifyPayment
    {
        public string MerchantID { get; set; }
        public string Authority { get; set; }
        public string Amount { get; set; }
    }
    public class ZarinPalVerifyResponse
    {
        public int Status { get; set; }
        public string RefID { get; set; }
    }
  
}
