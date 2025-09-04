// See https://aka.ms/new-console-template for more information
using SolidPrinciplsToCleanCode;
using SolidPrinciplsToCleanCode2;


public class Program

{
    public static void Main() {
        Console.WriteLine("Hello, World!");

        /*var orderItem = new OrderItem("Pencil", 10, 15);

        var orderProcessor = new OrderItemProcessor()
                                 .WithPriceCalculator(new PriceItemCalculator())
                                 .WithOrderValidator(new OrderItemValidator())
                                 .UsingPaymentType(PaymentMethod.UPI)
                                 .ForOrder(orderItem);

        orderProcessor.Process();*/

        var imageReader = new QRCodeReader();//new BarCodeReader();
        ReadImage("barcode.png", imageReader);
    }

    static void ReadImage<T>(string fileName, T reader) where T : ImageReader
    {
        var result = reader.ReadImage(fileName);
        Console.WriteLine("Iamge Read Result", result);
    }
}
