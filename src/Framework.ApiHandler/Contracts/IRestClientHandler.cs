using RestSharp;
using System; 

namespace Framework.ApiHandler.Contracts
{
    /// <summary>
    /// RestSharp wrapper for making rest requests
    /// </summary>
    public interface IRestClientHandler
    {  
        IRestResponse Execute(Uri baseUri, Method method, IRestRequest restRequest);
        T Execute<T>(Uri baseUri, Method method, IRestRequest restRequest); 
    }
}
