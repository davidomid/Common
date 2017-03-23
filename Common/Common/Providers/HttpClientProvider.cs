using System;
using System.Net.Http;

namespace Common.Providers
{
    public class HttpClientProvider : IHttpClientProvider
    {
        public static HttpClientProvider Current = new HttpClientProvider();

        private static readonly Lazy<HttpClient> _httpClient
            = new Lazy<HttpClient>(() => new HttpClient());

        public HttpClient HttpClient
        {
            get { return _httpClient.Value; }
        }
    }
}