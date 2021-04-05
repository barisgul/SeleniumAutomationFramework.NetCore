using Framework.Core.Infrastructure.Managers;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.Core.Domain
{
    public abstract class BasePage : PageManager, IDisposable
    {
        public BasePage()
        {
            Init();
        }

        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void NavigateToSinglePage()
        {
            driver.Navigate().GoToUrl(seleniumServiceSettings.ApplicationUrl);
        }

        public void WaitUntilElementToBe(ExpectedConditions conditions)
        {

        }

        public virtual void Dispose()
        {
            driver.Close();
            driver.Quit(); 
        }
    }
}
