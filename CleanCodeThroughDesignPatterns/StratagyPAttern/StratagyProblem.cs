using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeThroughDesignPatterns.StratagyPAttern
{
    public class PaymentProcessor
    {
        public void ProcessPayment(string paymentType, float amount)
        {
            if(paymentType == "CreditCard")
            {
                // Process Credit Card Payment
                Console.WriteLine($"Processing credit card payment of {amount}");
            }
            else if (paymentType == "PayPal")
            {
                // Process PayPal Payment
                Console.WriteLine($"Processing PayPal payment of {amount}");
            }
            else if (paymentType == "BankTransfer")
            {
                // Process Bank Transfer Payment
                Console.WriteLine($"Processing bank transfer payment of {amount}");
            }
            else
            {
                throw new NotSupportedException("Payment type not supported");
            }
        }
    }
}
