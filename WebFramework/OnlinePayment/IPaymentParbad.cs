//using Common.Interface;
//using Data.Dto.OnlinePayment;
//using Parbad;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace WebFramework.OnlinePayment
//{
//    public  interface IPaymentParbad : IScopedDependency
//    {
//        Task<IPaymentRequestResult> Pay(PayOnlinePaymentDto pay, string callbackUrl, CancellationToken cancellationToken);
//        Task<IPaymentVerifyResult> Verify(IPaymentFetchResult invoice, CancellationToken cancellationToken);
//        Task<IPaymentFetchResult> Fetch(CancellationToken cancellationToken);
//        IPaymentRefundResult Refund(int TrackingNumber);
//    }
//}
