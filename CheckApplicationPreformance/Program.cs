using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using CheckApplicationPreformance;

public class Program
{
    public static void Main()
    { 
        var config = ManualConfig.Create(DefaultConfig.Instance)
                  .AddColumn(BenchmarkDotNet.Columns.StatisticColumn.AllStatistics)
                  .AddDiagnoser(BenchmarkDotNet.Diagnosers.MemoryDiagnoser.Default)
                  .AddExporter(BenchmarkDotNet.Exporters.MarkdownExporter.Default)
                  .WithArtifactsPath("BenchmarkDotNet.Artifacts");

        BenchmarkRunner.Run<BenchMarkItems>(config);
    }
}
