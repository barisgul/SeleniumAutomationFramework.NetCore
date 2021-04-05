using Framework.Common;
using Framework.Core.Entites;
using Framework.Core.Infrastructure.Entites;
using OpenQA.Selenium;
using System;

namespace Framework.Core.Infrastructure.Managers
{
    public class DriverManager : IDisposable
    {
        private readonly DriverFactory driverFactory;
        private IWebDriver webDriver;
        private readonly BrowserType browserType;
        private readonly ExecutionEnvironment environment;
        private readonly DriverModel driverModel;
        public DriverManager(ExecutionEnvironment environment, BrowserType browserType)
        {
            this.browserType = browserType;
            this.environment = environment;
            driverModel = new DriverModel
            {
                BrowserType = browserType,
                ExecutionEnvironment = environment
            };
            driverFactory = new DriverFactory();
        }

        public IWebDriver CreateWebDriverInstance()
        {  
            webDriver = driverFactory.GetDriver(environment, browserType);
            Logger.Info(string.Format("Selenium {0} created successfully", webDriver));
            return webDriver;
        }

        public void Dispose()
        {
            webDriver.Quit();
            webDriver.Close();
            Logger.Info("Dispose methode initialized. Selenium WebDriver closed!");
        }
    }
}
