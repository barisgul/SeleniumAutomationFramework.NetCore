using OpenQA.Selenium;

namespace SpecFlowProject1.Pages
{
    public class TrelloBoardPage 
    {
        private readonly IWebDriver driver;
        public IWebElement  lblBoardName => driver.FindElement(By.XPath("//*[@id='content']/div/div[1]/div[1]/div[2]/h1"));

        public TrelloBoardPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public bool IsPageLoaded(string text)
        {
            var boarText = lblBoardName.Text;

            return boarText.Equals(text);
        } 
    }
}
