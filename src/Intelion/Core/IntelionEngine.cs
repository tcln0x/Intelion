using Intelion.Inputs;
using Intelion.Modules.Username;

namespace Intelion.Core
{
    public class IntelionEngine
    {
        private readonly List<IScanModule> _modules;

        public IntelionEngine()
        {
            _modules = new List<IScanModule>
            {
                new UsernameScanner()
            };
        }

        public async Task<IEnumerable<ScanReport>> RunAsync(ScanInput input)
        {
            var context = new ScanContext(input);
            var tasks = _modules
                .Where(m => m.CanHandle(input))
                .Select(m => m.ScanAsync(context));

            return await Task.WhenAll(tasks);
        }
    }
}