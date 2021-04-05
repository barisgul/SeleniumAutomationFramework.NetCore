using Framework.ApiHandler.Contracts;
using Newtonsoft.Json;
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

        public T ExecuteGet<T>( Uri baseUrl, IRestRequest restRequest)
        {
            IRestClient restClient = new RestClient();
            restClient.BaseUrl = baseUrl;

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.Method = Method.GET;
            restRequest.Timeout = 5000;

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
