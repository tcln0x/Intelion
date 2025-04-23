namespace Intelion.Core
{
    public class ProbeResult
    {
        public string Source { get; set; }

        public ProbeCategory Category { get; set; }

        public bool Found { get; set; }

        public string? ProfileUrl { get; set; }

        public int StatusCode { get; set; }

        public string? ErrorMessage { get; set; }
    }
}