using Framework.Core.Domain;
using Trello.UiTest.Pages;

namespace Trello.UiTest.Steps
{
    public class LoginSteps : BasePage
    {
        private readonly LoginPage loginPage;
        public LoginSteps()
        {
            loginPage = new LoginPage(driver);
        }
    }
}
