using Framework.Common.Entities;

namespace Framework.Common.Contracts
{
    public interface IAppSettingsManager
    {
        public SeleniumServiceSettings GetSeleniumServiceSettings();
        public RestServiceSettings GetRestServiceSettings();
    }
}
