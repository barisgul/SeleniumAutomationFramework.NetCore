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
        public static IWebDriver driver { get; set; } 
        public readonly SeleniumServiceSettings seleniumServiceSettings;
        private readonly DriverModel driverModel;
        public PageManager()
        {
            appSettingsManager = new AppSettingsManager();
            seleniumServiceSettings = appSettingsManager.GetSeleniumServiceSettings();
            driverModel = new DriverModel
            {
                ExecutionEnvironment = ExecutionEnvironment,
                BrowserType = BrowserType
            };
        }

        public void Init()
        { 
            driverManager = new DriverManager(driverModel);
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
