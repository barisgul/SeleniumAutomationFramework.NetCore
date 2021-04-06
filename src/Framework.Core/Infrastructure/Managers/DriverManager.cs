using Framework.Common;
using Framework.Common.Contracts;
using Framework.Common.Managers;
using Framework.Core.Entites;
using Framework.Core.Infrastructure.Entites;
using Framework.Core.Infrastructure.Utils;
using OpenQA.Selenium;
using System;

namespace Framework.Core.Infrastructure.Managers
{
    public class DriverManager : IDisposable
    {
        private readonly IAppSettingsManager appSettingsManager;
        private readonly DriverFactory driverFactory;
        public IWebDriver driver; 
        private DriverModel driverModel;
        public int timeout { get; set; } 

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="driverModel"></param>
        public DriverManager()
        {
            appSettingsManager = new AppSettingsManager(); //create appsettingsmanager instance
            driverFactory = new DriverFactory();           //create driverFactory instance
            SetDriverModel();                              //set driver behaviorals like browserType, Environment
        }

        private void SetDriverModel()
        {
            string browser = appSettingsManager.GetSeleniumServiceSettings().Browser;
            string executionEnv = appSettingsManager.GetSeleniumServiceSettings().ExecutionEnvironment;
            int timeout = appSettingsManager.GetSeleniumServiceSettings().Timeout;
            
            driverModel = new DriverModel
            {
                BrowserType = EnumConverter.StringToEnum<BrowserType>(browser),
                ExecutionEnvironment = EnumConverter.StringToEnum<ExecutionEnvironment>(executionEnv) 
            };

            this.timeout = timeout;
        }

        /// <summary>
        /// Initialize driver factory and create web driver instance
        /// </summary>
        public void Init()
        {
            driver = driverFactory.GetDriver(driverModel);
            Logger.Info(string.Format("Selenium {0} initialized successfully", driver));
            driver.Manage().Window.FullScreen();
            driver.Manage().Window.Maximize();
        }
         
        public void Dispose()
        {
            driver.Quit();
            Logger.Info("Dispose methode initialized. Selenium WebDriver closed!");
        }
    }
}
