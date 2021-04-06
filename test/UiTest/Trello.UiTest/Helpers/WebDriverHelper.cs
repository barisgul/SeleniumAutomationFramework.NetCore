using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Trello.UiTest.Helpers
{
    public class WebDriverHelper
    { 
        private static IWebDriver driver { get; set; }
        public static void Init(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        [Obsolete]
        public static IWebElement WaitUntilElementClickable(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw ex;
            }
        }

        [Obsolete]
        public static void ClickAndWaitForPageToLoad(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var element = driver.FindElement(elementLocator);
                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw ex;
            }
        }
    }
}
