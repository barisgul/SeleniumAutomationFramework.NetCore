using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ApiHandler.Implementations
{
    internal class RequestHelper
    {
        public static void PrepareRequest(IRestRequest restRequest, Method method)
        {            
            restRequest.AddHeader("Content-Type", "application/json");

            if (method.Equals(Method.POST) || method.Equals(Method.PUT))
            {
                restRequest.RequestFormat = DataFormat.Json;
            }
                
        }
    }
}
