using SolidPrinciplsToCleanCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplsToCleanCode2
{
    public record OrderItem(string productName,int qty,decimal price);
    public interface IPaymentGateway {  void ProcessPayment(decimal price, string tags); }

    public class StripePaymentNewGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal price, string tags)
        {
            Console.WriteLine("Processing payment for order through stipe");

        }
    }

    public class RazorPayPaymentNewGateway : IPaymentGateway {
        public void ProcessPayment(decimal price, string tags)
        {
            Console.WriteLine("Processing payment for order through RazorPay");

        }
    }

    public class OrderItemValidator
    {
        public void Validate(OrderItem order)
        {
            if (order == null || order.price <= 0)
                throw new InvalidDataException("Invalid order data.");
        }
    }

    public class PriceItemCalculator
    {
        public decimal CalculateTotalPriceWithTax(OrderItem order)
        {
            return (order.price) + (order.price * 0.18M);
        }
    }

    public static class PaymentProviderFactory
    {
        public static IPaymentGateway GetPaymentProvider(PaymentMethod paymentMethod)
        {
            return paymentMethod switch
            {
                PaymentMethod.UPI => new StripePaymentNewGateway(),
                PaymentMethod.CreditCard => new StripePaymentNewGateway(),
                _ => throw new NotSupportedException("Payment method not supported.")
            };
        }
    }

    public class OrderItemProcessor
    {
        private IPaymentGateway paymentGateway;
        private OrderItem order;
        private PriceItemCalculator itemCalculator;
        private OrderItemValidator validator;

        public OrderItemProcessor UsingPaymentType(PaymentMethod method)
        {
            this.paymentGateway = PaymentProviderFactory.GetPaymentProvider(method);
            return this;
        }

        public OrderItemProcessor ForOrder(OrderItem order)
        {
            this.order = order;
            return this;
        }

        public OrderItemProcessor WithPriceCalculator(PriceItemCalculator calculator)
        {
            this.itemCalculator = calculator;
            return this;
        }

        public OrderItemProcessor WithOrderValidator(OrderItemValidator validator)
        {
            this.validator = validator;
            return this;
        }

        public void Process()
        {
            validator.Validate(order);

            var totalPrice = itemCalculator.CalculateTotalPriceWithTax(order);

            paymentGateway.ProcessPayment(totalPrice, "OrerId");
        }
    }


}
