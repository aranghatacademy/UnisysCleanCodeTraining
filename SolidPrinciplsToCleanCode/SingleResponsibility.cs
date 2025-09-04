using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplsToCleanCode
{
    /*public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        
        public string PaymentType { get; set; }

        public decimal Amount { get; set; }
    }*/

    // This class adheres to the Single Responsibility Principle
    /*public class OrderProcessor
    {
        public void ProcessOrder(Order order)
        {
            if(order is null)
                throw new ArgumentNullException(nameof(order));

            if(order.Amount <= 0)
                throw new ArgumentException("Order amount must be greater than zero.");

            // Order processing logic
            Console.WriteLine($"Processing order {order.Id} for product {order.ProductName}");

            if(order.PaymentType == "Stripe")
            {
                Console.WriteLine("Processing payment through Stripe...");
            }
            else
            {
                Console.WriteLine("Processing payment through PayPal...");
            }
        }
    }*/

    public enum PaymentMethod
    {
        UPI,
        CreditCard,
        BankTransfer
    }

    public record Order(decimal Price, string ProductName, PaymentMethod PaymentMethod);

    public class OrderValidator
    {
        public void Validate(Order order)
        {
            if(order == null || order.Price <=0)
                throw new InvalidDataException("Invalid order data.");
        }
    }

    public class PriceCalculator
    {
         public decimal CalculateTotalPriceWithTax(Order order)
        {
            return (order.Price) + (order.Price * 0.18M);
        }
    }

    public interface IPaymentProvider
    {
        void ProcessPayment(Order order);
    }

    public class StripePaymentProvider : IPaymentProvider
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Processing payment through Stripe...");
        }
    }

    public class RazorPayPaymentProvider : IPaymentProvider
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Processing payment through RazorPay...");
        }
    }


    //Factory - Design Pattern
    public static class PaymentProviderFactory
    {
        public static IPaymentProvider GetPaymentProvider(PaymentMethod paymentMethod)
        {
            return paymentMethod switch
            {
                PaymentMethod.UPI => new RazorPayPaymentProvider(),
                PaymentMethod.CreditCard => new StripePaymentProvider(),
                _ => throw new NotSupportedException("Payment method not supported.")
            };
        }
    }


    //SRP - Order Processor
    public class OrderProcessor
    {
        private readonly OrderValidator orderValidator;
        private readonly PriceCalculator priceCalculator;
        private IPaymentProvider paymentProvider;

        public OrderProcessor(OrderValidator orderValidator, PriceCalculator priceCalculator)
        {
            this.orderValidator = orderValidator;
            this.priceCalculator = priceCalculator;
        }

        public void ProcessOrder(Order order)
        {
            //IF order is not valid expected throw and exception
            orderValidator.Validate(order);

            //Calculate the total
            var total = priceCalculator.CalculateTotalPriceWithTax(order);

            //Get the payment gateway
            paymentProvider = PaymentProviderFactory.GetPaymentProvider(order.PaymentMethod);

            //PRoces the payment
            paymentProvider.ProcessPayment(order);
        }
    }
}
