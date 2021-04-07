using Framework.ApiHandler.Contracts;
using Framework.Common.Contracts;
using Framework.Common.Entities;
using Framework.Common.Managers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net.Http;

namespace Framework.ApiHandler.Implementations
{
    public class RestClientHandler : IRestClientHandler
    {
        private readonly IAppSettingsManager appSettingsManager;
        private readonly RestServiceSettings restServiceSettings;
        public RestClientHandler()
        {
            appSettingsManager = new AppSettingsManager();
            restServiceSettings = appSettingsManager.GetRestServiceSettings();
        }
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

        public T Execute<T>(Uri baseUri, Method method, IRestRequest restRequest)
        {
            IRestClient restClient = new RestClient
            {
                BaseUrl = baseUri
            };
            RequestHelper.SetAuthentication(restRequest, restServiceSettings);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.Method = method;
            restRequest.Timeout = restServiceSettings.Timeout;

            IRestResponse restResponse = restClient.Execute(restRequest);
            T deserializedModel = JsonConvert.DeserializeObject<T>(restResponse.Content);

            return deserializedModel;
        }

        public T ExecuteGet<T>(Uri baseUri, IRestRequest restRequest)
        {
            IRestClient restClient = new RestClient
            {
                BaseUrl = baseUri
            };
            RequestHelper.SetAuthentication(restRequest, restServiceSettings);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.Method = Method.GET;
            restRequest.Timeout = restServiceSettings.Timeout;
           

            IRestResponse restResponse = restClient.Execute(restRequest);
            T deserializedModel = JsonConvert.DeserializeObject<T>(restResponse.Content);

            return deserializedModel;
        }

        public T ExecutePost<T>(Uri baseUrl, IRestRequest restRequest)
        {
            IRestClient restClient = new RestClient();
            restClient.BaseUrl = baseUrl;

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.Method = Method.POST;
            restRequest.RequestFormat = DataFormat.Json;
            //restRequest.AddBody(JsonConvert.SerializeObject(T));

            IRestResponse restResponse = restClient.Execute(restRequest);
            T t = JsonConvert.DeserializeObject<T>(restResponse.Content);

            return t; 
        }
    }
}
