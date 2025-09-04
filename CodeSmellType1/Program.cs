using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellType1
{
    public class Program
    {
        public static void Main()
        {
           var options =  new ReportOptions("Sales Report", DateTime.Now.AddMonths(-1), DateTime.Now, ExportFormat.PDF, Orientation.Portrait);
           var reportGenerator = new ReportGenerator();
           var report = reportGenerator.GenerateReport(options);
        }
    }
}
