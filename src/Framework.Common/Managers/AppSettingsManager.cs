using Framework.Common.Contracts;
using Framework.Common.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

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

        public SeleniumServices SeleniumServices { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public RestServices RestServices { get => throw new System.NotImplementedException(); }

        
        public string Browser { get => builder.Build().GetSection("SeleniumServices").GetSection("Browser").Value.ToUpper(); }
        public string ExecutionEnvironment { get => builder.Build().GetSection("SeleniumServices").GetSection("ExecutionEnvironment").Value.ToUpper(); }
    }
}
