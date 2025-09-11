using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeThroughDesignPatterns.StratagyPAttern
{
   public interface IPaymentStratagy
    {
        void ProcessPayment(decimal amount);
    }

    //CreditCard Payment Strategy
    public class CreditCardPayment : IPaymentStratagy
    {
        public void ProcessPayment(decimal amount)
        {
            // Process Credit Card Payment
            Console.WriteLine($"Processing credit card payment of {amount}");
        }
    }

    public class PayPalPayment : IPaymentStratagy
    {
        public void ProcessPayment(decimal amount)
        {
            // Process PayPal Payment
            Console.WriteLine($"Processing PayPal payment of {amount}");
        }
    }

    public class UPIPayment : IPaymentStratagy
    {
        public void ProcessPayment(decimal amount)
        {
            // Process UPI Payment
            Console.WriteLine($"Processing UPI payment of {amount}");
        }
    }

    public class PaymentProcessorStrategy
    {
        private readonly IPaymentStratagy _paymentStratagy;
        public PaymentProcessorStrategy(IPaymentStratagy paymentStratagy)
        {
            _paymentStratagy = paymentStratagy;
        }
        public void ProcessPayment(decimal amount)
        {
            _paymentStratagy.ProcessPayment(amount);
        }
    }
}
