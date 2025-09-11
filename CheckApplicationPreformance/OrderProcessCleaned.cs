using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckApplicationPreformance
{
    public enum Shipping
    {
        Standard,
        Express,
        International
    }

    public class OrderRequest
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public Shipping ShippingChoice { get; set; }
    }

   
    public class OrderProcessCleaned
    {
     
        public void ProcessOrder(OrderRequest order)
        {
            decimal shippingCost = order.ShippingChoice switch
            {
                Shipping.Standard => 20,
                Shipping.Express => 50,
                Shipping.International => 100,
                _ => throw new NotSupportedException("Shipping type not supported"),
            };
            decimal totalAmount = order.Amount + shippingCost;
            Console.WriteLine($"Processing {order.ShippingChoice} order of amount {order.Amount} with shipping cost {shippingCost}. Total: {totalAmount}");
            var paymentProcessor = PaymentFactory.GetPaymentProcessor("CreditCard");
            paymentProcessor.ProcessPayment(totalAmount);
        }
    }

    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount}");
        }
    }

    public class PayPalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount}");
        }
    }

    public static class PaymentFactory
    {
        public static IPaymentProcessor GetPaymentProcessor(string paymentType)
        {
            return paymentType switch
            {
                "CreditCard" => new CreditCardProcessor(),
                "PayPal" => new PayPalProcessor(),
                _ => throw new NotSupportedException("Payment type not supported"),
            };
        }
    }
}
