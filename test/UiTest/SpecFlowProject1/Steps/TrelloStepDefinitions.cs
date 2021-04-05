using FluentAssertions;
using SpecFlowProject1.Helpers;
using SpecFlowProject1.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject1.Steps
{
    [Binding, Scope(Feature ="Trello")]
    public class TrelloStepDefinitions : IDisposable
    {
        TrelloBoardPage trelloPage = new TrelloBoardPage();
        private Credentials credentials;
        public TrelloStepDefinitions()
        {
             
        }

        [StepDefinition(@"Open trello application on '(.*)'")]
        public void OpenApplicaiton(string url)
        {
            trelloPage.Navigate(url);
        }

        [StepDefinition(@"Click on login")]
        public void ClickOnLogin()
        {
            trelloPage.ClickOnLogin();
        }

        [StepDefinition(@"Enter username")]
        public void EnterUsername(Table table)
        {
            credentials = table.CreateInstance<Credentials>();
            trelloPage.SetUsername(credentials.UserName);
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

        public void Dispose()
        {
            trelloPage.Dispose();
        }
    }
}
