using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeThroughDesignPatterns.StratagyPAttern
{
    public static class PaymentStrategyFactory
    {
        public static IPaymentStratagy CreatePaymentStratagy(string paymentype)
        {
            IPaymentStratagy paymentStrategy = paymentype == "CreditCard" ? new CreditCardPayment() :
                                     paymentype == "PayPal" ? new PayPalPayment() :
                                     paymentype == "UPI" ? new UPIPayment() : null;

            return paymentStrategy;
        }

    }
}
