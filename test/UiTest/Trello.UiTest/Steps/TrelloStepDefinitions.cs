using FluentAssertions;
using Framework.Core.Domain;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Trello.UiTest.Helpers;
using Trello.UiTest.Pages;

namespace Trello.UiTest.Steps
{
    [Binding, Scope(Feature = "Trello")] 
    public class TrelloStepDefinitions : BasePage
    {
        private readonly LoginPage loginPage;
        private readonly TrelloMainPage trelloMainPage;
        TrelloBoardPage trelloBoardPage;
        private Credentials credentials;
        public TrelloStepDefinitions()
        {
            loginPage = new LoginPage(driver, timeout);
            trelloMainPage = new TrelloMainPage(driver, timeout);
            trelloBoardPage = new TrelloBoardPage(driver, timeout);
        }

        [Given(@"Open trello application on '(.*)'")]
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


        [When(@"Click on Log in")]
        public void SignInToApplicaiton()
        {
            loginPage.SubmitLogin();
        }

        [Then(@"Trello dashboard should be open and '(.*)' menu should be visible")]
        public void GivenOpenTrelloApplicationBoard(string textToCheck)
        {
            bool isComponentLoaded = trelloMainPage.IsPageLoaded(textToCheck);
            isComponentLoaded.Should().BeTrue();
        }


        [StepDefinition(@"Click to '(.*)' on dashboard")]
        public void GivenApplicationBoardShouldBeOpened(string board)
        {
            trelloMainPage.ClickOnBoard(board);
        }

        [StepDefinition(@"'(.*)' should be opened")]
        public void GivenClickOnInList(string board)
        {
            trelloBoardPage.IsBoardPageOpened(board).Should().BeTrue();
        }


        [StepDefinition(@"Create '(.*)' in '(.*)' list")]
        public void GivenClickOnInList(string cardName, string p1)
        {
            trelloBoardPage.CreateToDoCard(cardName);
        }

        [StepDefinition(@"'(.*)' card should be created")]
        public void GivenCardShouldBeCreated(string cardName)
        {
            trelloBoardPage.IsBoardPageOpened(cardName).Should().BeTrue();
        }

        [StepDefinition(@"Delete '(.*)' in '(.*)' list")]
        public void GivenDeleteInList(string cardName, string p1)
        {
            trelloBoardPage.DeleteCard(cardName);
        }

        [StepDefinition(@"'(.*)' card should be deleted")]
        public void GivenCardShouldBeDeleted(string cardName)
        {
            ScenarioContext.Current.Pending();
        }



    }
}
