// See https://aka.ms/new-console-template for more information
using SolidPrinciplsToCleanCode;
using SolidPrinciplsToCleanCode2;

Console.WriteLine("Hello, World!");

var orderItem = new OrderItem("Pencil", 10, 15);

var orderProcessor = new OrderItemProcessor()
                         .WithPriceCalculator(new PriceItemCalculator())
                         .WithOrderValidator(new OrderItemValidator())
                         .UsingPaymentType(PaymentMethod.UPI)
                         .ForOrder(orderItem);

orderProcessor.Process();