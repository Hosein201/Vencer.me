namespace Common.CommonModel
{
    public class ReqSendSms
    {
        public ReqSendSms()
        {
            this.username = "saeed1371";
            this.password = "9399788755";
            this.from = "50005000901058";
            this.isFlash = false;
        }

        public string username { get; set; }
        public string password { get; set; }
        public string to { get; set; }
        public string from { get; set; }
        public string text { get; set; }
        public bool isFlash { get; set; }
    }
    public class ResSendSms
    {
        public string Value { get; set; }
        public int RetStatus { get; set; }
        public string StrRetStatus { get; set; }
    }

    public class ReqDelivery
    {
        public ReqDelivery()
        {
            this.UserName = "saeed1371";
            this.PassWord = "9399788755";
        }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public dynamic RecId { get; set; }
    }

    public class ResDelivery
    {
        public string Value { get; set; }
        public int RetStatus { get; set; }
        public string StrRetStatus { get; set; }
    }
}
