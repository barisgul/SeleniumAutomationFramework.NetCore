using Framework.Common;
using Framework.Core.Entites;
using Framework.Core.Infrastructure.BrowserOptions;
using Framework.Core.Infrastructure.Entites;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace Framework.Core.Infrastructure.Managers
{
    public class DriverFactory
    {
        private IWebDriver driver = null;

        /// <summary>
        /// Get driver by given browser
        /// </summary>
        /// <param name="driverModel"></param>
        /// <returns></returns>
        public IWebDriver GetDriver(DriverModel driverModel)
        {
            if (driverModel.ExecutionEnvironment.Equals(ExecutionEnvironment.LOCAL))
            {
                switch (driverModel.BrowserType)
                {
                    case BrowserType.NONE:
                        {
                            var exception = new ArgumentNullException(nameof(driverModel.BrowserType));
                            Logger.Error("At least one browser type should be configured. Please define a browser type in appsettings.json file!",exception);
                            throw exception;
                        }
                    case BrowserType.CHROME:
                        {
                            ChromeOptions options = ChromeDriverOptions.GetChromeOptions();
                            driver = new ChromeDriver(options);
                            Logger.Info(string.Format("{0} is configured as working browser", BrowserType.CHROME));
                            break;
                        }
                    case BrowserType.IE:
                        {
                            driver = new InternetExplorerDriver();
                            Logger.Info(string.Format("{0} is configured as working browser", BrowserType.IE));
                            break;
                        }
                    case BrowserType.FIREFOX:
                        {
                            driver = new FirefoxDriver();
                            Logger.Info(string.Format("{0} is configured as working browser", BrowserType.FIREFOX));
                            break;
                        }
                    default:
                        { 
                            break;
                        }
                }
            }
            else if (driverModel.ExecutionEnvironment.Equals(ExecutionEnvironment.REMOTE))
            {
                // Remote web driver factory should be implement with desired browser capabilities/options 
                // For this case it is not necessary
            }

            return driver;
        }
    }
}
