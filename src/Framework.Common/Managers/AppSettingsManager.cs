using Framework.Common.Contracts;
using Framework.Common.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Framework.Common.Managers
{
    public class AppSettingsManager : IAppSettingsManager
    {
        private readonly IConfigurationBuilder builder;
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
                BaseUrl = builder.Build().GetSection("RestServices").GetSection("ApiUrl").Value,
                Timeout = long.Parse(builder.Build().GetSection("RestServices").GetSection("Timeout").Value)
            };
        }

        public SeleniumServiceSettings GetSeleniumServiceSettings()
        {
            return new SeleniumServiceSettings
            {
                Browser = builder.Build().GetSection("SeleniumServices").GetSection("Browser").Value.ToUpper(),
                ExecutionEnvironment = builder.Build().GetSection("SeleniumServices").GetSection("ExecutionEnvironment").Value.ToUpper(),
                ApplicationUrl = builder.Build().GetSection("SeleniumServices").GetSection("ApplicationUrl").Value,
                HeadlessMode = builder.Build().GetSection("SeleniumServices").GetSection("HeadlessMode").Value,
                Timeout = long.Parse(builder.Build().GetSection("SeleniumServices").GetSection("Timeout").Value)
            };
        }
    }
}
