namespace Intelion.Core
{
    public class ScanReport
    {
        public ScanAttribute Attribute { get; set; }

        public IReadOnlyCollection<ProbeResult> Results { get; set; }
    }
}