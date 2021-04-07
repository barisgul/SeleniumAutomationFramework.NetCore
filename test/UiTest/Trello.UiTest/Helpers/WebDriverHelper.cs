using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Trello.UiTest.Helpers
{
    public class WebDriverHelper
    {

        public static void ForceWait(int timeout = 10)
        {
            Thread.Sleep(timeout);
        }

         /// <summary>
         /// Wait Until Element To Be Clickable
         /// </summary>
         /// <param name="driver"></param>
         /// <param name="elementLocator"></param>
         /// <param name="timeout"></param>
         /// <returns></returns>
        public static IWebElement WaitUntilElementClickable(IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw ex;
            }
        }

        /// <summary>
        /// Wait until element vanished
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="elementLocator"></param>
        /// <param name="timeout"></param>
        public static void WaitUntilElementVanished(IWebDriver driver, By elementLocator, int timeout = 10)
        {   
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));

                while (driver.FindElement(elementLocator).Enabled == true)
                {
                    return;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw ex;
            }
        }

        /// <summary>
        /// Click and wait for page load
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="elementLocator"></param>
        /// <param name="timeout"></param>
        public static void ClickAndWaitForPageToLoad(IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var element = driver.FindElement(elementLocator);
                element.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw ex;
            }
        }
    }
}
