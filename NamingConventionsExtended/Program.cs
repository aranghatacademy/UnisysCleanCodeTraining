// See https://aka.ms/new-console-template for more information
using Arangahat.Product.Feature;
using Aranghat.Product.Feature;

//var order = new Order();
//var totalCost = order.CalcualteTotal();

//Domain Driven Design (DDD) Naming Conventions
//Use clear ubiquitous language that reflects the domain model.

var currentCustomerOrder = new CustomerOrder();
var totalCostWithTaxes   = currentCustomerOrder.CalcualteTotalPriceWithTaxes();

var orderPaymentService  = new StripeOrderPaymentService(1, "Stripe Service");
var paymentRequest = new OrderPaymentRequest
{
    OrderId = 1,
    Amount = 10.0M,
};

// Initiate payment
orderPaymentService.InitiateOrderPayment(paymentRequest);

if(orderPaymentService.IsOrderPaymentCompleted(1))
{
    Console.WriteLine("Payment Completed");
}