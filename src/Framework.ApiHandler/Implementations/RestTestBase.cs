using Framework.Common.Contracts;
using Framework.Common.Managers;

namespace Framework.ApiHandler.Implementations
{
    public class RestTestBase
    {
        IAppSettingsManager appSettingsManager;
        public string BaseUrl { get; set; }
        public RestTestBase()
        {
            appSettingsManager = new AppSettingsManager();
            BaseUrl = appSettingsManager.GetRestServiceSettings().BaseUrl;
        }
    }
}
