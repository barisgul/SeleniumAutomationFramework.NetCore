using RestSharp;
using System;
using System.Net.Http;

namespace Framework.ApiHandler.Contracts
{
    /// <summary>
    /// RestSharp wrapper for making rest requests
    /// </summary>
    public interface IRestClientHandler
    {
        T Execute<T>();
        T Execute<T>(string baseUrl);
        T Execute<T>(string baseUrl, HttpMethod httpMethod);
        T Execute<T>(Uri baseUri, Method method, IRestRequest restRequest);
        T ExecuteGet<T>(Uri baseUrl, IRestRequest restRequest);
    }
}
