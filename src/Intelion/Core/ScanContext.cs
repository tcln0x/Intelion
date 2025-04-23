using Intelion.Inputs;

namespace Intelion.Core
{
    public class ScanContext
    {
        public ScanInput Input { get; }

        public ScanContext(ScanInput input)
        {
            Input = input;
        }
    }
}