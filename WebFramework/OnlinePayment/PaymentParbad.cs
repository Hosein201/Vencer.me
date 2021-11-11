//using Data.Dto.OnlinePayment;
//using Parbad;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using Parbad.Abstraction;
//using System.Threading;
//using Common.Utilities;
//using Common.Interface;

//namespace WebFramework.OnlinePayment
//{
//    public class PaymentParbad : IPaymentParbad
//    {
//        private IOnlinePayment _onlinePayment;
//        public async Task<IPaymentRequestResult> Pay(PayOnlinePaymentDto pay, string callbackUrl, CancellationToken cancellationToken)
//        {
//            var Invoice = new Invoice() {
//                Amount = pay.Amount,
//                CallbackUrl = CallbackUrl.Parse(callbackUrl),
//                GatewayName = pay.GatewayType.ToDisplay(),
//                TrackingNumber = RandomCommon.GetRendom()
//            };
//            var result = await _onlinePayment.RequestAsync(Invoice, cancellationToken);

//            return result;
//        }
//        public async Task<IPaymentFetchResult> Fetch(CancellationToken cancellationToken)
//        {
//            var result = await _onlinePayment.FetchAsync(cancellationToken);
//            return result;
//        }
//        public async Task<IPaymentVerifyResult> Verify(IPaymentFetchResult invoice, CancellationToken cancellationToken)
//        {
//            var result = await _onlinePayment.VerifyAsync(invoice, cancellationToken);
//            return result;
//        }

//        public IPaymentRefundResult Refund(int TrackingNumber) 
//        {
//            var result = _onlinePayment.RefundCompletely(TrackingNumber);
//            return result;
//        }
//    }
//}
