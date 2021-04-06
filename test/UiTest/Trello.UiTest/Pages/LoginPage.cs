using OpenQA.Selenium;
using System.Runtime.InteropServices;
using Trello.UiTest.Helpers;

namespace Trello.UiTest.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly int timeout;
        #region WEB ELEMENTS
        private IWebElement linkLogin => driver.FindElement(By.XPath("//a[text()='Log in']"));
        private IWebElement txtUsername => driver.FindElement(By.Id("user"));

        private By loginWithAttlassianLocator = By.XPath("//input[@id='login' and @value='Log in with Atlassian']");
        private IWebElement btnLoginWithAtlassian => driver.FindElement(loginWithAttlassianLocator);
        private IWebElement txtPassword => driver.FindElement(By.XPath("//input[@placeholder='Enter password']"));
        private IWebElement btnSubmitLogin => driver.FindElement(By.Id("login-submit"));
        #endregion

        #region PAGE METHODS
        public LoginPage(IWebDriver driver, [Optional] int timeout)
        {
            this.driver = driver;
            this.timeout = timeout;
        }

        public void ClickOnLogin()
        {
            linkLogin.Click();
        }

        public void SetUsername(string username)
        {
            txtUsername.Click();
            txtUsername.SendKeys(username);
            txtUsername.SendKeys(Keys.Tab);
        }

        public void ClickOnLoginWithAtlassian()
        { 
            WebDriverHelper.WaitUntilElementClickable(driver, loginWithAttlassianLocator, timeout);
            btnLoginWithAtlassian.Click();
        }

        public void SetPassword(string password)
        {
            txtPassword.SendKeys(password);
        }

        public void SubmitLogin()
        {
            btnSubmitLogin.Click();
        }
        #endregion
    }
}
