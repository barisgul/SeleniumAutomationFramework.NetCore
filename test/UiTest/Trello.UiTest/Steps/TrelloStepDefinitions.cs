using FluentAssertions;
using Framework.Core.Domain;
using SpecFlowProject1.Helpers;
using SpecFlowProject1.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject1.Steps
{
    [Binding, Scope(Feature ="Trello")]
    public class TrelloStepDefinitions : BasePage
    {
        LoginPage loginPage;
        TrelloBoardPage trelloPage;
        private Credentials credentials;
        public TrelloStepDefinitions()
        {
            loginPage = new LoginPage(driver);
            trelloPage = new TrelloBoardPage(driver);
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
        }

        [StepDefinition(@"Enter password")]
        public void EnterPassword()
        {
        }


        [StepDefinition(@"Click on Log in")]
        public void SignInToApplicaiton()
        { 
        }

        [StepDefinition(@"Open trello application board")]
        public void GivenOpenTrelloApplicationBoard()
        { 
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
