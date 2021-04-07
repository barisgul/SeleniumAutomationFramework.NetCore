using Framework.Common;
using Framework.Core.Infrastructure.Managers;
using System;

namespace Framework.Core.Domain
{
    public abstract class BasePage : DriverManager, IDisposable
    { 
        public BasePage() 
        {
            Logger.Info(string.Format("{0} Test/s Started", this.GetType().Name));
            Init();
        }

        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Dispose()
        { 
            driver.Quit();
            Logger.Info("Dispose methode initialized. Selenium WebDriver closed!");
            Logger.Info(string.Format("{0} Test/s Finished", this.GetType().Name));
        }
    }
}
