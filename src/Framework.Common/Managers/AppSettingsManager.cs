using Framework.Common.Contracts;
using Framework.Common.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Framework.Common.Managers
{
    public class AppSettingsManager : IAppSettingsManager
    {
        private readonly IConfigurationBuilder builder;
        const string selenimServices = "SeleniumServices";
        const string restServices = "RestServices";
        public AppSettingsManager()
        {
            builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        }

        public RestServiceSettings GetRestServiceSettings()
        {
            return new RestServiceSettings
            {
                BaseUrl = builder.Build().GetSection(restServices).GetSection("ApiUrl").Value,
                Timeout = long.Parse(builder.Build().GetSection(restServices).GetSection("Timeout").Value)
            };
        }

        public SeleniumServiceSettings GetSeleniumServiceSettings()
        {
            return new SeleniumServiceSettings
            {
                Browser = builder.Build().GetSection(selenimServices).GetSection("Browser").Value.ToUpper(),
                ExecutionEnvironment = builder.Build().GetSection(selenimServices).GetSection("ExecutionEnvironment").Value.ToUpper(),
                ApplicationUrl = builder.Build().GetSection(selenimServices).GetSection("ApplicationUrl").Value,
                HeadlessMode = builder.Build().GetSection(selenimServices).GetSection("HeadlessMode").Value,
                Timeout = long.Parse(builder.Build().GetSection(selenimServices).GetSection("Timeout").Value)
            };
        }
    }
}
