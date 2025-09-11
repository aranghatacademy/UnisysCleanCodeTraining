// See https://aka.ms/new-console-template for more information

using CleanCodeThroughDesignPatterns.StratagyPAttern;

/*Console.WriteLine("How do you like to pay? (CreditCard/PayPal/UPI)");
var paymentType = Console.ReadLine();

//FActory Method : Choose and create the instance based on the condition
IPaymentStratagy paymentStrategy = PaymentStrategyFactory.CreatePaymentStratagy(paymentType);

// Dependency Injection : Inject the dependency via constructor
//Provide a stratagy during runtime which the processor will use
var processor = new PaymentProcessorStrategy(paymentStrategy);
processor.ProcessPayment(1000);*/

var paymentProcess = new StrategyContext<PaymentRequest, PaymentResponse>(new CreditCardPaymentStrategy());
paymentProcess.ExecuteStrategy(new PaymentRequest { Amount = 100 });

var messageProcess = new StrategyContext<Message, MessageResponse>(new EmailMessageSender());
messageProcess.ExecuteStrategy(new Message { Content = "Test MEssage", Email = "sree@gmail.com" });
