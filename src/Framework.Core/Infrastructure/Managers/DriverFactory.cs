using Framework.Core.Entites;
using OpenQA.Selenium;
using System;

namespace Framework.Core.Infrastructure.Managers
{
    public class DriverFactory : IDisposable
    {
        private IWebDriver driver;
        public DriverFactory()
        {
            driver = null;
        }

        public IWebDriver GetDriver(BrowserType browserType)
        {
            if (browserType.Equals(BrowserType.CHROME))
            {
                throw new NotImplementedException();
                //return driver
            }

            if (browserType.Equals(BrowserType.FIREFOX))
            {
                throw new NotImplementedException();
                //return driver
            }

            throw new NotImplementedException();
        }

        public void Dispose()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
