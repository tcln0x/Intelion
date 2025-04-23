using Intelion.Core;
using Intelion.Modules.Username.Models;
using Intelion.Services;

namespace Intelion.Modules.Username.Modules
{
    public class ChessProbe : ISourceProbe<UsernameTarget, ProbeResult>
    {
        public string SourceName => "Chess.com";
        public ProbeCategory Category => ProbeCategory.Gaming;

        public async Task<ProbeResult> ProbeAsync(UsernameTarget input)
        {
            var url = $"https://www.chess.com/member/{input.Username}";
            try
            {
                var resp = await HttpService.Instance.GetAsync(url);
                return new ProbeResult
                {
                    Source = SourceName,
                    Category = Category,
                    Found = resp.IsSuccessStatusCode,
                    ProfileUrl = resp.IsSuccessStatusCode ? url : null,
                    StatusCode = (int)resp.StatusCode,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                return new ProbeResult
                {
                    Source = SourceName,
                    Category = Category,
                    Found = false,
                    ProfileUrl = null,
                    StatusCode = 0,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}