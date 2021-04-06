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

        public IWebDriver GetDriver(DriverModel driverModel)
        {
            if (driverModel.ExecutionEnvironment.Equals(ExecutionEnvironment.LOCAL))
            {
                switch (driverModel.BrowserType)
                {
                    case BrowserType.NONE:
                        {
                            throw new ArgumentNullException(nameof(driver));
                        }
                    case BrowserType.CHROME:
                        {
                            ChromeOptions options = ChromeDriverOptions.GetChromeOptions();
                            driver = new ChromeDriver(options);
                            break;
                        }
                    case BrowserType.IE:
                        {
                            driver = new InternetExplorerDriver();
                            break;
                        }
                    case BrowserType.FIREFOX:
                        {
                            driver = new FirefoxDriver();
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
                // Remote web driver factory should be implement with desired browser capabilities/options.
                // For this case it is not obligated
            }

            return driver;
        }
    }
}
