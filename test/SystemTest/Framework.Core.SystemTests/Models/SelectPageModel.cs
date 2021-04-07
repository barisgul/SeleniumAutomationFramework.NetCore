using Framework.Core.Domain;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;

namespace Framework.Core.SystemTests.Models
{
    public class SelectPageModel : BasePage
    {
        public IWebElement SelectTwo => driver.FindElement(By.XPath("//*[@id='selectWithoutMultiple']/option[2]"));
        public IWebElement LinkRoquefort => driver.FindElement(By.XPath("//*[@id='selectWithMultipleEqualsMultiple']/option[text() = 'Roquefort']"));
        public IWebElement RandomMultipleOne => driver.FindElement(By.XPath("//*[@id='selectWithRandomMultipleValue']/option[text() = 'one']"));

        public void GoToInternalPage()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                                                                           "\\Sources\\selectPage.html";
            NavigateTo(path);
        }

        public void ClickSelectTwo()
        {
            SelectTwo.Click();
        }

        public void ClickLinkLinkRoquefort()
        {
            LinkRoquefort.Click();
        }

        public void ClickRandomMultipleOne()
        {
            RandomMultipleOne.Click();
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public void Dispose()
        {
            base.Dispose();
        }
    }
}
