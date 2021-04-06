using OpenQA.Selenium;
using Trello.UiTest.Helpers;

namespace Trello.UiTest.Pages
{
    public class TrelloBoardPage 
    {
        private readonly IWebDriver driver;
        private readonly By byLblBoard = By.XPath("//span[@class='_3qwe2tMMFonNvf' and text() = 'Boards']");
        private IWebElement  lblBoards => driver.FindElement(byLblBoard);
        

        public TrelloBoardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        [System.Obsolete]
        public bool IsPageLoaded(string text)
        {
            WebDriverHelper.WaitUntilElementClickable(byLblBoard, 25);
            var boarText = lblBoards.Text;

            return boarText.Equals(text);
        } 
    }
}
