using Framework.Core.Infrastructure.Managers;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.Core.Domain
{
    public abstract class BasePage : DriverManager
    { 
        public BasePage() 
        {
            Init();
        }

        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void WaitUntilElementToBe(ExpectedConditions conditions)
        {

        }
        public void Wait(TimeSpan timeSpan)
        {
            driver.Manage().Timeouts().ImplicitWait = timeSpan;
        }

        public void WaitForLoadingPage()
        {
            //driver.Manage().Timeouts().PageLoad;
        }

        public virtual void Dispose()
        {
            driver.Close();
            driver.Quit(); 
        }
    }
}
