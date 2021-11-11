using Common.CommonModel;
using Common.Interface;
using Common.Utilities;
using Data.Dto.Payment;
using System;
using System.Threading.Tasks;

namespace WebFramework
{
    public class RequsetToPay : IRequestToPay
    {
        private static IHttpConnect Connect;
        private string urlZarinPalToRequest;
        private string urlZarinPalToVerify;
        public ZarinPalRequestResponse ZarinPalRequestToPay(string Amount, string CallbackURL,string Description,string Mobile, bool iSSandBox = false)
        {
            if (iSSandBox)
                urlZarinPalToRequest = "https://sandbox.zarinpal.com/pg/rest/WebGate/PaymentRequest.json"; // sand Box
            else
                urlZarinPalToRequest = "https://www.zarinpal.com/pg/rest/WebGate/PaymentRequest.json";
            var ZarinPalRequest = new ZarinPalRequest()
            {
                Amount = Convert.ToString(Amount),
                CallbackURL = CallbackURL,
                Description = Description,
                MerchantID = "09fea688-4b84-11e8-aa2a-005056a205be",
                Mobile = Mobile
            };

            Connect = new BaseRestSharp(urlZarinPalToRequest);
            var responseSend = Connect.Connecting<ZarinPalRequestResponse>(urlZarinPalToRequest, ConnectType.POST, null, ZarinPalRequest);
            return responseSend;
        }

        public ZarinPalVerifyResponse ZarinPalVerifyPay(string Amount,string Authority, bool iSSandBox = false)
        {
            var zarinPalVerify = new ZarinPalVerifyPayment
            { 
                MerchantID= "09fea688-4b84-11e8-aa2a-005056a205be",
                Amount= Amount,
                Authority= Authority
            };

            if (iSSandBox)
                urlZarinPalToVerify = "https://sandbox.zarinpal.com/pg/rest/WebGate/PaymentVerification.json"; // sand Box
            else
                urlZarinPalToVerify = "https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json";

            Connect = new BaseRestSharp(urlZarinPalToVerify);
           var responseSend =Connect.Connecting<ZarinPalVerifyResponse>(urlZarinPalToRequest, ConnectType.POST, null, zarinPalVerify);
            if (responseSend.Status == 100)
                return responseSend;
            return responseSend;
        }
    }
}
