using Framework.Core.Domain;
using OpenQA.Selenium;
using SpecFlowProject1.Helpers;

namespace SpecFlowProject1.Pages
{
    public class TrelloBoardPage : BasePage
    {
        public IWebElement  lblBoardName => driver.FindElement(By.XPath("//*[@id='content']/div/div[1]/div[1]/div[2]/h1"));
        public IWebElement  linkLogin => driver.FindElement(By.XPath("//a[text()='Log in']"));
        public IWebElement  txtUsername => driver.FindElement(By.Id("user"));
        public IWebElement  btnLoginWithAtlassian => driver.FindElement(By.Id("login"));


        public void Navigate(string url)
        {
            NavigateTo(url);
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

        public bool IsPageLoaded(string text)
        {
            var tmp = driver.FindElement(By.XPath("//*[@id='content']/div/div[1]/div[1]/div[2]/h1"));
            var boarText = lblBoardName.Text;

            return boarText.Equals(text);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
