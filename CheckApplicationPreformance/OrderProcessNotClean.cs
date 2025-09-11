using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckApplicationPreformance
{
   
    public class OrderProcessNotClean
    {
    
        public void ProcessOrder(string orderType, decimal amount)
        {
            if (orderType == "Standard")
            {
                // Standard order processing logic
                Console.WriteLine($"Processing standard order of amount {amount}");
                // Additional logic for standard orders
                ProcessPayment("CreditCard", amount + 20);
            }
            else if (orderType == "Express")
            {
                // Express order processing logic
                Console.WriteLine($"Processing express order of amount {amount}");
                // Additional logic for express orders
                ProcessPayment("CreditCard", amount + 50);
            }
            else if (orderType == "International")
            {
                // International order processing logic
                Console.WriteLine($"Processing international order of amount {amount}");
                // Additional logic for international orders
                ProcessPayment("WireTransfer", amount + 100);
            }
            else
            {
                Console.WriteLine("Unknown order type");
            }
        }

        public void ProcessPayment(string paymentType, decimal amount) { 
            Console.WriteLine($"Processing payment of type {paymentType} for amount {amount}");

            if (paymentType == "CreditCard")
            {
                // Process Credit Card Payment
                Console.WriteLine($"Processing credit card payment of {amount}");
            }
            else if (paymentType == "PayPal")
            {
                // Process PayPal Payment
                Console.WriteLine($"Processing PayPal payment of {amount}");
            }
            else if (paymentType == "WireTransfer")
            {
                // Process Wire Transfer Payment
                Console.WriteLine($"Processing wire transfer payment of {amount}");
            }
            else
            {
                throw new NotSupportedException("Payment type not supported");
            }
        }
    }
}
