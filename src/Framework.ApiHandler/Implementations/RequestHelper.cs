using Framework.Common.Contracts;
using Framework.Common.Entities;
using Framework.Common.Managers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ApiHandler.Implementations
{
    internal class RequestHelper
    { 
        public RequestHelper()
        { 
        }
        public static void PrepareRequest(IRestRequest restRequest, Method method)
        {            
            restRequest.AddHeader("Content-Type", "application/json");

            if (method.Equals(Method.POST) || method.Equals(Method.PUT))
            {
                restRequest.RequestFormat = DataFormat.Json;
            }   
        }

        internal static IRestRequest SetAuthentication(IRestRequest restRequest, RestServiceSettings restServiceSettings)
        { 
            restRequest.AddQueryParameter("key", restServiceSettings.Key);
            restRequest.AddQueryParameter("token", restServiceSettings.Token);

            return restRequest;
        }
    }
}
