namespace Intelion.Services
{
    public sealed class HttpService : IDisposable
    {
        private static readonly Lazy<HttpService> _instance = new(() => new HttpService());

        public static HttpService Instance => _instance.Value;

        private readonly HttpClient _client;

        private HttpService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("Intelion/1.0");
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return _client.GetAsync(url);
        }

        public Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return _client.PostAsync(url, content);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}