using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckApplicationPreformance
{
    [MemoryDiagnoser]
    [RankColumn]
    public class BenchMarkItems
    {
        [Benchmark]
        public void OrderWithNotCleanCode()
        {
            var orderProcessor = new OrderProcessNotClean();
            orderProcessor.ProcessOrder("Standard", 500);
        }

        [Benchmark]
        public void OrderWithCleanCode()
        {
            var orderProcessor = new OrderProcessCleaned();
            orderProcessor.ProcessOrder(new OrderRequest
            {
         
                Amount = 500,
                ShippingChoice = Shipping.International,
            });
        }
    }
}
