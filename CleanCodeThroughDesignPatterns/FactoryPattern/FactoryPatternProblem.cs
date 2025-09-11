using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeThroughDesignPatterns
{
    public class ExportReportService
    {
        public void ExportReport(string report, string format)
        {
            var reportGenerator = ExportEngineFactory.CreateReportGenerator(format);
            reportGenerator.Generate(report);
        }


        public interface IReportGenerator
        {
            void Generate(string report);
        }

        public class PDFReportGenerator : IReportGenerator
        {
            public void Generate(string report)
            {
                // Generate PDF Report
            }
        }

        public class ExcelReportGenerator : IReportGenerator
        {
            public void Generate(string report)
            {
                // Generate Excel Report
            }
        }

        public class WordReportGenerator : IReportGenerator
        {
            public void Generate(string report)
            {
                // Generate Word Report
            }
        }


        public static class ExportEngineFactory
        {
        
            public static IReportGenerator CreateReportGenerator(string format)
            {
                IReportGenerator reportGenerator = format == "PDF" ? new PDFReportGenerator() :
                                                 format == "Excel" ? new ExcelReportGenerator() :
                                                 format == "Word" ? new WordReportGenerator() : null;
                return reportGenerator;
            }


        }

        
    }
}
