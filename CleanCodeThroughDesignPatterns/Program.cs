// See https://aka.ms/new-console-template for more information

using CleanCodeThroughDesignPatterns.ObserverPattern;
using CleanCodeThroughDesignPatterns.StratagyPAttern;

/*Console.WriteLine("How do you like to pay? (CreditCard/PayPal/UPI)");
var paymentType = Console.ReadLine();

//FActory Method : Choose and create the instance based on the condition
IPaymentStratagy paymentStrategy = PaymentStrategyFactory.CreatePaymentStratagy(paymentType);

// Dependency Injection : Inject the dependency via constructor
//Provide a stratagy during runtime which the processor will use
var processor = new PaymentProcessorStrategy(paymentStrategy);
processor.ProcessPayment(1000);*/

/*var paymentProcess = new StrategyContext<PaymentRequest, PaymentResponse>(new CreditCardPaymentStrategy());
paymentProcess.ExecuteStrategy(new PaymentRequest { Amount = 100 });

var messageProcess = new StrategyContext<Message, MessageResponse>(new EmailMessageSender());
messageProcess.ExecuteStrategy(new Message { Content = "Test MEssage", Email = "sree@gmail.com" });

var discountProcess = new StrategyContext<Order, decimal>(new PrimeMemberDiscountStrategy());
var discount = discountProcess.ExecuteStrategy(new Order { OrderId = 1, Amount = 1000 });*/

/*var temperatureSensor = new TemperatureObserverService();

var alertSystem = new AlarmObserver();
var smsSystem   = new SMSObserver();
var fireStation = new FireStationObserver();
var openDoorService = new OpenEmergencyDoors();

temperatureSensor.RegisterObserver(alertSystem);
temperatureSensor.RegisterObserver(smsSystem);
temperatureSensor.RegisterObserver(fireStation);
temperatureSensor.RegisterObserver(openDoorService);


temperatureSensor.UpdateTemperature(85);*/

var temperatureSensor = new TemperatureSensor();
temperatureSensor.UpdateEventHandler += (sender, temp) =>
{
    Console.WriteLine($"Temperature Sensor Event Triggered. Current Temperature: {temp.Temperature}. Time {temp.TimeStamp}");

    new AlarmObserver().Update(temp.Temperature);
    new SMSObserver().Update(temp.Temperature);
    new FireStationObserver().Update(temp.Temperature);
    new OpenEmergencyDoors().Update(temp.Temperature);
};

temperatureSensor.UpdateEventHandler += (sender, temp) =>
{
    Console.WriteLine("TEMP EVENT HANDLER 2");
};

temperatureSensor.SetTemperature(85);
