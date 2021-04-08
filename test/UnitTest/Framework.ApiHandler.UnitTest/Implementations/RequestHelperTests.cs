using AutoFixture;
using FluentAssertions;
using Framework.ApiHandler.Implementations;
using Framework.Common.Entities;
using RestSharp;
using Xunit;

namespace Framework.ApiHandler.UnitTest.Implementations
{
    public class RequestHelperTests
    {
        Fixture fixture;
        public RequestHelperTests()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void SetAuthentication_WhenCalled_ShouldReturRestRespone()
        {
            //Arrange
            RestServiceSettings restServiceSettings = fixture.Build<RestServiceSettings>().Create();
            restServiceSettings.Key = "FakeKey";
            restServiceSettings.Token = "FakeToken";

            IRestRequest fakeRestRequest = new RestRequest();

            //Act
            var result = RequestHelper.SetAuthentication(fakeRestRequest, restServiceSettings);
            var parameters = result.Parameters;

            //Assert
            result.Parameters.Should().NotBeNull();
            parameters[0].Value.Should().Be(restServiceSettings.Key);
            parameters[1].Value.Should().Be(restServiceSettings.Token);
        }
    }
}
