namespace CodeSmellType1;

public enum ExportFormat
{
    PDF,
    Excel,
    Word
}

public enum Orientation
{
    Portrait,
    Landscape
}

public record ReportOptions(string Title
                        , DateTime FromDate
                        , DateTime ToDate
                        , ExportFormat exportFormat
                         , Orientation Orientation);

public class ReportGenerator
{
    

    // Too many flag arguments indicate that a method is trying to do too much.
    //public string GenerateReport(string title, DateTime fromDate, DateTime toDate, bool includeMargins, bool isLandscape, string exportFormat)
    public string GenerateReport(ReportOptions options)
    {
        // Report generation logic
        return "Report Content";
    }
}