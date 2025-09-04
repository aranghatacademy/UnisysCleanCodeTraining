using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellType1
{

    public record InlineItem(string Name, int Quantity, float Price);

    public class Invoice
    {
        public List<InlineItem> Items { get; } = new List<InlineItem>();
        public float GST { get; set; } = 0.18f;

        public float TotalBeforeTax
        {
            get
            {
                return Items.Sum(i => i.Quantity * i.Price);
            }
        }

        public float TaxAmount {  get
            {
                  return TotalBeforeTax * GST;
            }}

        public float NetAmount
        {
            get
            {
                return TotalBeforeTax + TaxAmount;
            }
        }
    }

    public class InvoicePrinter
    {
        // Feature Envy: A method that seems more interested in the data of another class than that of its own class.
        /*public static void Print(Invoice invoice)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Invoice");
            sb.AppendLine("-------");
            foreach (var item in invoice.Items)
            {
                sb.AppendLine($"{item.Name} - Qty: {item.Quantity}, Price: {item.Price}, Total: {item.Quantity * item.Price}");
            }
            float subTotal = invoice.Items.Sum(i => i.Quantity * i.Price); // Calcualte the Total
            float tax = subTotal * invoice.GST; // Tax Calculation
            float total = subTotal + tax; // Net Total
            sb.AppendLine($"Subtotal: {subTotal}");
            sb.AppendLine($"GST ({invoice.GST * 100}%): {tax}");
            sb.AppendLine($"Total: {total}");
            Console.WriteLine(sb.ToString());
        }*/

        public static void Print(Invoice invoice)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Invoice");
            sb.AppendLine("-------");
            foreach (var item in invoice.Items)
            {
                sb.AppendLine($"{item.Name} - Qty: {item.Quantity}, Price: {item.Price}, Total: {item.Quantity * item.Price}");
            }
            sb.AppendLine($"Subtotal: {invoice.TotalBeforeTax}");
            sb.AppendLine($"GST ({invoice.GST * 100}%): {invoice.TaxAmount}");
            sb.AppendLine($"Total: {invoice.NetAmount}");
            Console.WriteLine(sb.ToString());
        }
    }
}
