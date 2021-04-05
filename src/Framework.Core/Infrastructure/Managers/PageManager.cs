using Framework.Common.Contracts;
using Framework.Common.Entities;
using Framework.Common.Managers;
using Framework.Core.Entites;
using Framework.Core.Infrastructure.Entites;
using Framework.Core.Infrastructure.Utils;
using OpenQA.Selenium;

namespace Framework.Core.Infrastructure.Managers
{
    public class PageManager
    {
        private IAppSettingsManager appSettingsManager;
        private DriverManager driverManager;  
        public IWebDriver driver { get; set; } 
        public readonly SeleniumServiceSettings seleniumServiceSettings; 
        public PageManager()
        {
            appSettingsManager = new AppSettingsManager();
            seleniumServiceSettings = appSettingsManager.GetSeleniumServiceSettings();
        }

        public void Init()
        { 
            driverManager = new DriverManager(ExecutionEnvironment, BrowserType);
            driver = driverManager.CreateWebDriverInstance();
            driver.Manage().Window.FullScreen();
            driver.Manage().Window.Maximize();
        }

        private BrowserType BrowserType
        {
            get
            {
                return EnumConverter.StringToEnum<BrowserType>(seleniumServiceSettings.Browser);
            }
        }
        private ExecutionEnvironment ExecutionEnvironment
        {
            get
            {
                return EnumConverter.StringToEnum<ExecutionEnvironment>(seleniumServiceSettings.ExecutionEnvironment);
            }
        }         
    }
}
