using System.Net.Http;

namespace Common.Providers
{
    internal interface IHttpClientProvider
    {
        HttpClient HttpClient { get; }
    }
}