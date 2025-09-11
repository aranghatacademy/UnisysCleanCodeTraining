// See https://aka.ms/new-console-template for more information

using CleanCodeThroughDesignPatterns.StratagyPAttern;

Console.WriteLine("How do you like to pay? (CreditCard/PayPal/UPI)");
var paymentType = Console.ReadLine();

IPaymentStratagy paymentStrategy = paymentType  == "CreditCard" ? new CreditCardPayment() :
                         paymentType == "PayPal" ? new PayPalPayment() :
                         paymentType == "UPI" ? new UPIPayment() : null;

var processor = new PaymentProcessorStrategy(paymentStrategy);
processor.ProcessPayment(1000);
