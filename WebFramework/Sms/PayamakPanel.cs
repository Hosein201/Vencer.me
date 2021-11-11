using Common.Interface;
using Common.Utilities;
using Common.CommonModel;


namespace WebFramework.Sms
{
    public static class PayamakPanel
    {
        private readonly static string UrlSendSMS = "http://rest.payamak-panel.com/api/SendSMS/SendSMS";

        private readonly static string UrlGetDeliveries2 = "https://rest.payamak-panel.com/api/SendSMS/GetDeliveries2";

        private static IHttpConnect Connect;

        private static ReqSendSms reqSendSms;

        private static ReqDelivery reqDelivery;
        public static void SendSMS(string Mobile, string Text)
        {
            reqSendSms = new ReqSendSms();
            reqSendSms.to = Mobile;
            reqSendSms.text = Text;

            Connect = new BaseRestSharp(UrlSendSMS); // Send sms
            var responseSend = Connect.Connecting<ResSendSms>(UrlSendSMS, ConnectType.POST, null, reqSendSms);


            reqDelivery = new ReqDelivery();
            reqDelivery.RecId = responseSend.Value;

            Connect = new BaseRestSharp(UrlGetDeliveries2); // Del sms
            var responseDel = Connect.Connecting<ReqDelivery>(UrlSendSMS, ConnectType.POST, null, reqSendSms);

            //TODO whatsapp if user send sms
        }
    }
}

