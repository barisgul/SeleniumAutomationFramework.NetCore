using OpenQA.Selenium;

namespace Trello.UiTest.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        #region WEB ELEMENTS
        private IWebElement linkLogin => driver.FindElement(By.XPath("//a[text()='Log in']"));
        private IWebElement txtUsername => driver.FindElement(By.Id("user"));
        private IWebElement btnLoginWithAtlassian => driver.FindElement(By.XPath("//input[@id='login' and @value='Log in with Atlassian']"));
        private IWebElement txtPassword => driver.FindElement(By.XPath("//input[@placeholder='Enter password']"));
        private IWebElement btnSubmitLogin => driver.FindElement(By.Id("login-submit"));
        #endregion

        #region PAGE METHODS
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
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
