using Framework.Core.Domain;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;

namespace Framework.Core.SystemTests.Models
{
    /// <summary>
    /// e2e System test model over an internal html file for selenium webdriver click methods
    /// </summary>
    public class ClickModel : BasePage
    { 
        public IWebElement LinkNormal => driver.FindElement(By.Id("normal")); 
        public IWebElement LinkOverflow => driver.FindElement(By.Id("overflowLink"));  

        public void GoToInternalPage()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                                                                           "\\Sources\\clicks.html";
            NavigateTo(path);
        }

        public void ClickLinkNormal()
        { 
            LinkNormal.Click();
        }

        public void ClickLinkOwerFlow()
        { 
            LinkOverflow.Click();
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        //public void Dispose()
        //{
        //    base.Dispose();
        //}
    }
}
