using FluentAssertions;
using Framework.Core.Domain;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Trello.UiTest.Helpers;
using Trello.UiTest.Pages;

namespace Trello.UiTest.Steps
{
    [Binding, Scope(Feature = "Login")]
    public class LoginSteps : BasePage
    {
        Credentials credentials;
        private readonly LoginPage loginPage;
        private readonly TrelloMainPage trelloMainPage;
        public LoginSteps()
        {
            loginPage = new LoginPage(driver, timeout);
            trelloMainPage = new TrelloMainPage(driver, timeout);
        }

        [StepDefinition(@"Open trello application on '(.*)'")]
        public void OpenApplicaiton(string url)
        {
            NavigateTo(url);
        }

        [StepDefinition(@"Click on login")]
        public void ClickOnLogin()
        {
            loginPage.ClickOnLogin();
        }

        [StepDefinition(@"Enter username")]
        public void EnterUsername(Table table)
        {
            credentials = table.CreateInstance<Credentials>();
            loginPage.SetUsername(credentials.UserName);
        }

        [StepDefinition(@"Click on 'Log in with Atlassian'")]
        public void ClickOnAttlassianLogin()
        {
            loginPage.ClickOnLoginWithAtlassian();
        }

        [StepDefinition(@"Enter password")]
        public void EnterPassword()
        {
            loginPage.SetPassword(credentials.Password);
        }


        [StepDefinition(@"Click on Log in")]
        public void SignInToApplicaiton()
        {
            loginPage.SubmitLogin();
        }

        [StepDefinition(@"Trello dashboard should be open and '(.*)' menu should be visible")]
        public void GivenOpenTrelloApplicationBoard(string textToCheck)
        {
            bool isComponentLoaded = trelloMainPage.IsPageLoaded(textToCheck);
            isComponentLoaded.Should().BeTrue();
        }

        [StepDefinition(@"Click on logout button")]
        public void ClickOnLogut()
        {
            trelloMainPage.LogOut();
        }

        [StepDefinition(@"Logout should be succeded")]
        public void EnsureSuccesLogout()
        {
            trelloMainPage.IsLoggedOutSuccessfully().Should().BeTrue();
        }
    }
}
