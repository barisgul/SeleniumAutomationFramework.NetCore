using FluentAssertions;
using Framework.Core.Domain;  
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Trello.UiTest.Helpers;
using Trello.UiTest.Pages;

namespace Trello.UiTest.Steps
{
    [Binding, Scope(Feature ="Trello")]
    public class TrelloStepDefinitions : BasePage
    {
        private readonly LoginPage loginPage;
        private readonly TrelloMainPage trelloPage;
        private Credentials credentials;
        public TrelloStepDefinitions()
        {
            loginPage = new LoginPage(driver);
            trelloPage = new TrelloMainPage(driver);
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

        [StepDefinition(@"Trello dashboard should be open and '(.*)' menı should be visible")]
        public void GivenOpenTrelloApplicationBoard(string textToCheck)
        {
            bool isComponentLoaded = trelloPage.IsPageLoaded(textToCheck);
            isComponentLoaded.Should().BeTrue();
        }


        [StepDefinition(@"'(.*)' should be opened")]
        public void GivenApplicationBoardShouldBeOpened(string board)
        {
            trelloPage.IsPageLoaded(board).Should().BeTrue();
        }

        [StepDefinition(@"Click on '(.*)' in '(.*)' list")]
        public void GivenClickOnInList(string p0, string p1)
        {
            
        }

        [StepDefinition(@"Type '(.*)'")]
        public void GivenType(string p0)
        {
             
        }

        [StepDefinition(@"Click on '(.*)' button")]
        public void GivenClickOnButton(string p0)
        {
            
        }

        [StepDefinition(@"Card should be created")]
        public void GivenCardShouldBeCreated()
        {
            
        }
         
    }
}
