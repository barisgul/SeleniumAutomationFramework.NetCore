using FluentAssertions;
using Framework.Core.Domain;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Trello.UiTest.Helpers;
using Trello.UiTest.Pages;

namespace Trello.UiTest.Steps
{
    [Binding, Scope(Feature = "TrelloCards")]
    public class TrelloStepDefinitions : TestBase
    {
        private readonly LoginPage loginPage;
        private readonly TrelloMainPage trelloMainPage;
        private readonly TrelloBoardPage trelloBoardPage;
        private readonly CardContainerPage cardContainerPage;
        private Credentials credentials;
        public TrelloStepDefinitions()
        {
            loginPage = new LoginPage(driver, timeout);
            trelloMainPage = new TrelloMainPage(driver, timeout);
            trelloBoardPage = new TrelloBoardPage(driver, timeout);
            cardContainerPage = new CardContainerPage(driver, timeout);
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

            //Assertion
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
            //Assertion
            trelloBoardPage.IsBoardPageOpened(board).Should().BeTrue();
        }


        [StepDefinition(@"Create '(.*)' in '(.*)' list")]
        public void GivenClickOnInList(string cardName, string listName)
        {
            trelloBoardPage.CreateCardInList(cardName, listName);
        }

        [StepDefinition(@"'(.*)' card should be created in '(.*)' list")]
        public void GivenCardShouldBeCreated(string cardName, string listName)
        {
            //Assertion
            trelloBoardPage.CardShouldBeCreatedInList(cardName, listName).Should().BeTrue();
        }

        [StepDefinition(@"Delete '(.*)' in '(.*)' list")]
        public void GivenDeleteInList(string cardName, string listName)
        {
            cardContainerPage.DeleteCard(cardName);
        }

        [StepDefinition(@"Enter '(.*)' to description and Move '(.*)' to '(.*)' list")]
        public void MoveToList(string description, string cardName, string listName)
        {
            cardContainerPage.MoveCard(description, cardName, listName);
        }

        [StepDefinition(@"'(.*)' card should be moved")]
        public void CardShouldBeMoved(string card)
        {
            //Assertion
            trelloBoardPage.CardShouldBeMoved(card).Should().BeTrue();
        }

        [StepDefinition(@"'(.*)' card should be moved to '(.*)' list")]
        public void CardShouldBeMovedToList(string card, string list)
        {
            //Assertion
            trelloBoardPage.CardShouldBeMovedToList(card, list).Should().BeTrue();
        }

    }
}
