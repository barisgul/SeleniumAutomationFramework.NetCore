using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Trello.UiTest.Helpers;

namespace Trello.UiTest.Pages
{
    public class CardContainerPage
    {
        private readonly IWebDriver driver;
        private readonly int timeout;

        private IWebElement btnArchive => driver.FindElement(By.XPath("//span[text()='Archive']"));
        private IWebElement btnDelete => driver.FindElement(By.XPath("//span[text()='Delete']"));
        private IWebElement btnDeleteDanger => driver.FindElement(By.XPath("//input[@value='Delete']"));
        private IWebElement btnMove => driver.FindElement(By.XPath("//span[text() = 'Move']"));
        private IWebElement btnMoveAccept => driver.FindElement(By.XPath("//input[@value='Move']"));
        private IWebElement btnCloseActionModalView => driver.FindElement(By.XPath("//*[@id='chrome-container']/div[3]/div/div/a"));
        private IWebElement lblList => driver.FindElement(By.XPath("//select[@class='js-select-list']"));
        private IWebElement txtDescription => driver.FindElement(By.XPath("//a[text()='Add a more detailed description…']"));
       

        public CardContainerPage(IWebDriver driver, [Optional] int timeout)
        {
            this.driver = driver;
            this.timeout = timeout;
            TrelloBoardHelper.InitBoardModel();
        } 

        public void DeleteCard(string cardName)
        {
            ClickOnCardInList(cardName);
            WebDriverHelper.ImplicitWait(driver, 2);
            btnArchive.Click();
            btnDelete.Click();
            btnDeleteDanger.Click();
        }

        public void MoveCard(string descripton,string cardName, string listName)
        {
            ClickOnCardInList(cardName);
            WebDriverHelper.ImplicitWait(driver, 2);
            EnterDescription(descripton);
            btnMove.Click();
            SelectHelper.SelectByText(lblList, listName);
            driver.FindElement(By.XPath("//option[text()='" + listName + "']")).Click();
            btnMoveAccept.Click();            
            btnCloseActionModalView.Click();
        }

        public void EnterDescription(string text)
        {
            try
            {    
                txtDescription.Click();
                txtDescription.Click();
                driver.FindElement(By.XPath("//textarea[@class='field field-autosave js-description-draft description card-description']")).SendKeys("asdasd");
                  
                txtDescription.SendKeys(text);
            }
            catch (System.Exception ex)
            {
                
            }
        }

        private void ClickOnCardInList(string cardName)
        {
            driver.FindElement(By.XPath("//span[@class='list-card-title js-card-name' and text()='" + cardName + "']")).Click();
        }
    }
}
