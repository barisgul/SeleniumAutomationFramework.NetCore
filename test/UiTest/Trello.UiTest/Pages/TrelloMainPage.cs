using FluentAssertions;
using OpenQA.Selenium;
using System.Runtime.InteropServices;
using Trello.UiTest.Helpers;

namespace Trello.UiTest.Pages
{
    public class TrelloMainPage 
    {
        private readonly IWebDriver driver;
        private readonly int timeout;

        #region WebElements
        private readonly By byLblBoard = By.XPath("//span[@class='_3qwe2tMMFonNvf' and text() = 'Boards']");
        private IWebElement  lblBoards => driver.FindElement(byLblBoard);
        private IWebElement btnProfile => driver.FindElement(By.XPath("//button[@aria-label='Open member menu']"));
        private IWebElement btnLogout => driver.FindElement(By.XPath("//span[text()='Log out']"));
        private IWebElement btnLogoutSubmit => driver.FindElement(By.Id("logout-submit"));

        By lblLogoutSuccessMessageLocator = By.XPath("//div[@class='layout-centered-content']/h1");
        private IWebElement lblLogoutSuccessMessage => driver.FindElement(lblLogoutSuccessMessageLocator);
        private IWebElement divBoardName => driver.FindElement(By.XPath("//div[@title='ChallangeTeam']"));
        #endregion

        #region Page Methods 

        public TrelloMainPage(IWebDriver driver, [Optional] int timeout)
        {
            this.driver = driver;
            this.timeout = timeout;
        }
         
        public bool IsPageLoaded(string text)
        {
            WebDriverHelper.WaitUntilElementClickable(driver,byLblBoard, timeout);
            var boarText = lblBoards.Text;

            return boarText.Equals(text);
        } 

        public void LogOut()
        {
            btnProfile.Click();
            btnLogout.Click();
            btnLogoutSubmit.Click();            
        }

        public bool IsLoggedOutSuccessfully()
        {
            const string successLogoutText = "Thanks for using";
             
            WebDriverHelper.WaitUntilElementClickable(driver, lblLogoutSuccessMessageLocator, timeout);
            return lblLogoutSuccessMessage.Text.Contains(successLogoutText);
        }

        public void ClickOnBoard(string boardName)
        { 
            WebDriverHelper.ClickAndWaitForPageToLoad(driver, By.XPath("//div[@title='" + boardName + "']"), timeout);
        }
        #endregion
    }
}
