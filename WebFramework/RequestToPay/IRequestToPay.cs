using Common.CommonModel;
using Common.Interface;

namespace WebFramework
{
    public interface IRequestToPay :IScopedDependency
    {
        ZarinPalRequestResponse ZarinPalRequestToPay(string Amount, string CallbackURL, string Description, string Mobile, bool iSSandBox = false);
    ZarinPalVerifyResponse ZarinPalVerifyPay(string Amount, string Authority, bool iSSandBox = false);
}
}
