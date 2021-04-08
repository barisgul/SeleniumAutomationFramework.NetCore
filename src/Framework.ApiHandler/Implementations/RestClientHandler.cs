using Framework.ApiHandler.Contracts;
using Framework.Common.Contracts;
using Framework.Common.Entities;
using Framework.Common.Managers;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace Framework.ApiHandler.Implementations
{
    public class RestClientHandler : IRestClientHandler
    {
        private readonly IAppSettingsManager appSettingsManager;
        private readonly RestServiceSettings restServiceSettings;
        private readonly IRestClient restClient;

        /// <summary>
        /// default constructor
        /// </summary>
        public RestClientHandler()
        {
            appSettingsManager = new AppSettingsManager();
            restServiceSettings = appSettingsManager.GetRestServiceSettings();
            restClient = new RestClient();
        }

       /// <summary>
       /// DI for mock
       /// </summary>
       /// <param name="appSettingsManager"></param>
       /// <param name="restClient"></param>
        public RestClientHandler(IAppSettingsManager appSettingsManager, IRestClient restClient)
        {
            this.restClient = restClient;
            this.appSettingsManager = appSettingsManager;
            restServiceSettings = appSettingsManager.GetRestServiceSettings();
        }

        /// <summary>
        /// Generic Execute method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseUri"> base api url</param>
        /// <param name="method">request method</param>
        /// <param name="restRequest">IRestRequest object</param>
        /// <returns></returns>
        public T Execute<T>(Uri baseUri, Method method, IRestRequest restRequest)
        {
            restClient.BaseUrl = baseUri;
            RequestHelper.SetAuthentication(restRequest, restServiceSettings);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.Method = method;
            restRequest.Timeout = restServiceSettings.Timeout;

            IRestResponse restResponse = restClient.Execute(restRequest);
            T deserializedModel = JsonConvert.DeserializeObject<T>(restResponse.Content);

            return deserializedModel;
        }

        /// <summary>
        /// Execute a rest method
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="method"></param>
        /// <param name="restRequest"></param>
        /// <returns></returns>
        public IRestResponse Execute(Uri baseUri, Method method, IRestRequest restRequest)
        {
            restClient.BaseUrl = baseUri;
            RequestHelper.SetAuthentication(restRequest, restServiceSettings);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.Method = method;
            restRequest.Timeout = restServiceSettings.Timeout;

            IRestResponse restResponse = restClient.Execute(restRequest);

            return restResponse;
        } 
         
    }
}
