using AutoFixture;
using FluentAssertions;
using Framework.ApiHandler.Contracts;
using Framework.ApiHandler.Implementations;
using Framework.Common.Contracts;
using Framework.Common.Entities;
using Moq;
using RestSharp;
using System;
using System.Net;
using Xunit;

namespace Framework.ApiHandler.UnitTest.Implementations
{
    public class RestClientHandlerTests
    {
        Mock<IAppSettingsManager> mockSettingManager;
        Mock<IRestClient> mockRestClient;
        Mock<IRestClientHandler> mockRestClientHandler;
        Fixture fixture;
        RestClientHandler restClientHandler;
        public RestClientHandlerTests()
        {
            mockSettingManager = new Mock<IAppSettingsManager>();
            mockRestClient = new Mock<IRestClient>();
            mockRestClientHandler = new Mock<IRestClientHandler>();
            fixture = new Fixture();
        }

        [Fact]
        public void Execute_WhenCalled_ShouldExecuteRestRequest()
        {
            //Arrange (also known as Given)
            RestServiceSettings fakeSettings = fixture.Build<RestServiceSettings>().Create();
            
            mockSettingManager.Setup(x => x.GetRestServiceSettings()) //create a stub
                .Returns(fakeSettings);

            IRestResponse restResponse = new RestResponse
            {
                ResponseStatus = ResponseStatus.Completed,
                StatusCode = HttpStatusCode.OK, 
                ContentType = "applicaiton/json"
            };
            
            mockRestClient.Setup(x => x.Execute(It.IsAny<RestRequest>())).Returns(restResponse); //create a stub

            //Act (also knpwn as When)
            restClientHandler = new RestClientHandler(mockSettingManager.Object, mockRestClient.Object);
            var result = restClientHandler.Execute<RestResponse>(new Uri("https://fakeUri"), Method.GET, new RestRequest());

            //Assert (also known as Then)
            result.Should().BeNull();
        }
    }
}
