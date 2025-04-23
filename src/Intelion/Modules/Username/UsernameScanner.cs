using Intelion.Core;
using Intelion.Inputs;
using Intelion.Modules.Username.Models;
using Intelion.Modules.Username.Modules;

namespace Intelion.Modules.Username
{
    public class UsernameScanner : IScanModule
    {
        public ScanAttribute Attribute => ScanAttribute.Username;

        private readonly List<ISourceProbe<UsernameTarget, ProbeResult>> _probes;

        public UsernameScanner()
        {
            _probes =
            [
                new GitHubProbe(),
                new ChessProbe()
            ];
        }

        public bool CanHandle(ScanInput input) =>
            !string.IsNullOrWhiteSpace(input.Username);

        public async Task<ScanReport> ScanAsync(ScanContext context)
        {
            var target = new UsernameTarget(context.Input.Username!);
            var probeResults = new List<ProbeResult>();

            foreach (var probe in _probes)
            {
                var result = await probe.ProbeAsync(target);
                result.Category = probe.Category;
                probeResults.Add(result);
            }

            return new ScanReport()
            {
                Attribute = Attribute,
                Results = probeResults
            };
        }
    }
}