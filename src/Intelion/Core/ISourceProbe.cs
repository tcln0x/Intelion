namespace Intelion.Core
{
    public interface ISourceProbe<in TInput, TResult>
    {
        string SourceName { get; }

        ProbeCategory Category { get; }

        Task<TResult> ProbeAsync(TInput input);
    }
}