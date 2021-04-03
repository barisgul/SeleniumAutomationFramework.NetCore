using Framework.ApiHandler.Contracts;
using RestSharp;
using System;
using System.Net.Http;

namespace Framework.ApiHandler.Implementations
{
    public class RestClientHandler : IRestClientHandler
    {
        public T Execute<T>()
        {
            throw new NotImplementedException();
        }

        public T Execute<T>(string baseUrl)
        {
            throw new NotImplementedException();
        }

        public T Execute<T>(string baseUrl, HttpMethod httpMethod)
        {
            throw new NotImplementedException();
        }

        public T Execute<T>(string baseUrl, HttpMethod httpMethod, IRestRequest restRequest)
        {
            throw new NotImplementedException();
        }
    }
}
