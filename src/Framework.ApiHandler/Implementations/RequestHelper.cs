using Framework.Common.Entities;
using RestSharp;

namespace Framework.ApiHandler.Implementations
{
    public class RequestHelper
    {  
        public static IRestRequest SetAuthentication(IRestRequest restRequest, RestServiceSettings restServiceSettings)
        { 
            restRequest.AddQueryParameter("key", restServiceSettings.Key);
            restRequest.AddQueryParameter("token", restServiceSettings.Token);

            return restRequest;
        }
    }
}
