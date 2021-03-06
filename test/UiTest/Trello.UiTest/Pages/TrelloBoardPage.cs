using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using Trello.UiTest.Helpers;

namespace Trello.UiTest.Pages
{
    public class TrelloBoardPage
    {
        private readonly IWebDriver driver;
        private readonly int timeout;
        Dictionary<string, int> boardListEnumarator;

        #region WebElements

        By boardMainTitleLocator = By.XPath(" //div[@class='board-main-content']//h1[text()='AssignmentBoard']");
        private IWebElement boardMainTitle => driver.FindElement(boardMainTitleLocator);
        private ReadOnlyCollection<IWebElement> allBoardlists => driver.FindElements(By.XPath("//div[@class='list js-list-content']"));
        private ReadOnlyCollection<IWebElement> addCardsPlusIcons => driver.FindElements(By.XPath("//span[@class='icon-sm icon-add']"));
        private ReadOnlyCollection<IWebElement> cardsInLists => driver.FindElements(By.XPath("//span[@class='icon-sm icon-add']"));
        private IWebElement txtCreateCard => driver.FindElement(By.XPath("//*[@placeholder='Enter a title for this card…']"));
        private IWebElement btnAddCard => driver.FindElement(By.XPath("//input[@value='Add card']"));

        By txtSearcLocator = By.XPath("//input[@placeholder='Jump to…']");
        #endregion

        #region Page Methods
        public TrelloBoardPage(IWebDriver driver, [Optional] int timeout)
        {
            this.driver = driver;
            this.timeout = timeout;
            boardListEnumarator = TrelloBoardHelper.InitBoardModel();
        }

        public bool IsBoardPageOpened(string boardName)
        {
            bool isBoardOpened = driver.FindElement(By.XPath("//h1[text() = '"+ boardName + "']")).Displayed;
            return isBoardOpened;
        }

        public void CreateCardInList(string cardName, string listName)
        {
            WebDriverHelper.WaitUntilElementClickable(driver, txtSearcLocator, timeout); 
            IWebElement addCardButton = addCardsPlusIcons[boardListEnumarator[listName]];
            addCardButton.Click();
            txtCreateCard.SendKeys(cardName);
            btnAddCard.Click();
            WebDriverHelper.ImplicitWait(driver, 1);
        }

        public bool BoardShouldBeCreated(string cardName)
        {
            return driver.FindElement(By.XPath("//span[@class='list-card-title js-card-name' and text()='"+ cardName + "']")).Enabled;
        }
        public bool CardShouldBeCreatedInList(string cardName, string listName)
        {
            WebDriverHelper.ImplicitWait(driver, 2);
            bool isCardExist = driver.FindElement(By.XPath("//span[text() = '" + cardName + "']")).Displayed;
            return isCardExist;
        }

        public bool CardShouldBeMoved(string card)
        {
            WebDriverHelper.ImplicitWait(driver, 2);
            bool isCardExist = driver.FindElement(By.XPath("//span[text() = '" + card + "']")).Displayed;
            return isCardExist;
        }

        internal bool CardShouldBeMovedToList(string card, string list)
        {
            WebDriverHelper.ImplicitWait(driver, 2); 
            IWebElement expedtedList = allBoardlists[boardListEnumarator[list]];

            var cardsInList = expedtedList.FindElements(By.XPath("//span[text()='"+card+"']"));

            cardsInList.Reverse(); 

            return cardsInList[0].Displayed;
        }

        #endregion
    }
}
