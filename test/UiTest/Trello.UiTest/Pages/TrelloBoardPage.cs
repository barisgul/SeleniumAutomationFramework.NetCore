using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using Trello.UiTest.Helpers;

namespace Trello.UiTest.Pages
{
    public class TrelloBoardPage
    {
        private readonly IWebDriver driver;
        private readonly int timeout;
        By boardMainTitleLocator = By.XPath(" //div[@class='board-main-content']//h1[text()='AssignmentBoard']");
        private IWebElement boardMainTitle => driver.FindElement(boardMainTitleLocator);
        private ReadOnlyCollection<IWebElement> addCards => driver.FindElements(By.XPath("//span[text()='Add a card']"));
        private IWebElement txtCreateCard => driver.FindElement(By.XPath("//*[@placeholder='Enter a title for this card…']"));
        private IWebElement btnAddCard => driver.FindElement(By.XPath("//input[@value='Add card']"));
        private IWebElement btnArchive => driver.FindElement(By.XPath("//span[text()='Archive']"));
        private IWebElement btnDelete => driver.FindElement(By.XPath("//span[text()='Delete']"));
        private IWebElement btnDeleteDanger => driver.FindElement(By.XPath("//input[@value='Delete']"));



        public TrelloBoardPage(IWebDriver driver, [Optional] int timeout)
        {
            this.driver = driver;
            this.timeout = timeout;
        }

        public bool IsBoardPageOpened(string boardName)
        {
            bool isBoardOpened = driver.FindElement(By.XPath(" //div[@class='board-main-content']//h1[text()='"+boardName+"']")).Displayed;
            return isBoardOpened;
        }

        public void CreateToDoCard(string cardName)
        {
            addCards[0].Click();
            txtCreateCard.SendKeys(cardName);
            btnAddCard.Click();
        }

        public bool BoardShouldBeCreated(string cardName)
        {
            return driver.FindElement(By.XPath("//span[@class='list-card-title js-card-name' and text()='"+ cardName + "']")).Enabled;
        }

        public void DeleteCard(string cardName)
        {
            driver.FindElement(By.XPath("//span[@class='list-card-title js-card-name' and text()='" + cardName + "']")).Click();
            WebDriverHelper.ForceWait(2);
            btnArchive.Click();
            btnDelete.Click();
            btnDeleteDanger.Click();
        }
    }
}
