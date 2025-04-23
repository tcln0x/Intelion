using Intelion.Core;
using Intelion.Inputs;

namespace Intelion
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var input = new ScanInput()
            {
                Username = "johndoe"
            };

            var engine = new IntelionEngine();
            var results = await engine.RunAsync(input);

            foreach (var report in results)
            {
                foreach (var result in report.Results)
                {
                    var status = result.Found ? "Found" : "Not Found";
                    Console.WriteLine($"{result.Source} [{result.Category}]: {status} (HTTP {result.StatusCode})");
                    if (!string.IsNullOrEmpty(result.ProfileUrl))
                        Console.WriteLine($"  URL: {result.ProfileUrl}");
                    if (!string.IsNullOrEmpty(result.ErrorMessage))
                        Console.WriteLine($"  Error: {result.ErrorMessage}");
                }

                Console.WriteLine();
            }
        }
    }
}