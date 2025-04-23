using Intelion.Inputs;

namespace Intelion.Core
{
    public interface IScanModule
    {
        ScanAttribute Attribute { get; }

        bool CanHandle(ScanInput input);

        Task<ScanReport> ScanAsync(ScanContext context);
    }
}