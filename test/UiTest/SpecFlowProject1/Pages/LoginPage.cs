using Framework.Core.Domain;
using OpenQA.Selenium;

namespace SpecFlowProject1.Pages
{
    public class LoginPage : BasePage
    {
        public IWebElement linkLogin => driver.FindElement(By.XPath("//a[text()='Log in']"));
        public IWebElement txtUsername => driver.FindElement(By.Id("user"));
        public IWebElement btnLoginWithAtlassian => driver.FindElement(By.Id("login"));


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
    }
}
