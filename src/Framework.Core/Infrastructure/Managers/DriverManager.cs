using Framework.Common;
using Framework.Core.Infrastructure.Entites;
using OpenQA.Selenium;
using System;

namespace Framework.Core.Infrastructure.Managers
{
    public class DriverManager : IDisposable
    {
        private readonly DriverFactory driverFactory;
        private IWebDriver webDriver; 
        private readonly DriverModel driverModel;
        public DriverManager(DriverModel driverModel)
        {
            this.driverModel = driverModel;
            driverFactory = new DriverFactory();
        }

        public IWebDriver CreateWebDriverInstance()
        {  
            webDriver = driverFactory.GetDriver(driverModel);
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
