using FluentAssertions;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.UnitTestProvider;
using Trello.ApiTests.Entites;
using Trello.ApiTests.RequestServices;

namespace Trello.ApiTests.Steps
{
    [Binding, Scope(Feature ="TrelloBoard")]
    public class TrelloBoardSteps
    {
        private readonly IUnitTestRuntimeProvider testRuntimeProvider;
        IRestResponse restResponse;
        BoardService boardService;
        private string boardName; 
        CreateBoardModel createBoardModel;
        UpdateBoardModel updatedBoardModel;
        RestModel restModel;
        List<UserBoards> userBoards;
        CustomBoardModel customBoardModel;
        bool isBoardExist = false;
        public TrelloBoardSteps(IUnitTestRuntimeProvider testRuntimeProvider)
        {
            boardService = new BoardService();
            this.testRuntimeProvider = testRuntimeProvider;
        }
        [Given(@"As a developer I want to create a board named '(.*)'")]
        public void GivenAsADeveloperIWantToCreateABoardNamed(string boardName)
        {
            //Arrange
            this.boardName = boardName;
        }

        [Given(@"Call '(.*)' endpoint with '(.*)' method")]
        public void GivenCallEndpointWith(string endpoint, Method method)
        {
            createBoardModel = boardService.CreateBoard(endpoint, method, boardName);
        } 
        

        [Given(@"'(.*)' should be created")]
        public void GivenShouldBeCreated(string boardName)
        {
            //assertion
            createBoardModel.name.Should().Be(boardName);
        }

        [Given(@"I make a rest request with below criteria")]
        public void GivenIPrepareARestRequestAsBelow(Table table)
        {
            restModel = table.CreateInstance<RestModel>();
            userBoards = boardService.GetUserBoards(restModel.Endpoint, restModel.Method);
        }

        [Then(@"Board information should return")]
        public void ThenBoardInformationShouldReturn()
        {
            userBoards.Should().NotBeNull();
            userBoards.Count.Should().BeGreaterThan(0);
        }

        [Given(@"As a developer i want to rename '(.*)' board")]
        public void GivenAsADeveloperIWantToRenameBoardAs(string bName)
        {
            //get board id
            customBoardModel = boardService.GetCustomBoard("/boards", bName); 
        }

        [Given(@"Call '(.*)' endpoint with '(.*)' method for update '(.*)' board as '(.*)'")]
        public void UpdateBoard(string endpoint, Method method, string oldName, string newName)
        {
            if (customBoardModel.Id != null)
                updatedBoardModel = boardService.UpdateBoardName(endpoint, customBoardModel.Id, method, newName);
            else 
                testRuntimeProvider.TestIgnore(string.Format("This step will be ignore because {0} does not exist on trello", oldName));
        }

        [Given(@"board should be renamed as '(.*)'")]
        public void GivenBoardShouldBeRenamedAs(string boardName)
        {
            //assert
            if (customBoardModel.Id != null)
                updatedBoardModel.name.Should().Be(boardName);
            else
                testRuntimeProvider.TestIgnore(string.Format("This step will be ignore because {0} does not exist on trello", boardName));            
        }

        [Given(@"As a developer i want to remove a board named '(.*)'")]
        public void GivenAsADeveloperIWantToRemoveABoardNamed(string bName)
        {
            //Get board id 
            customBoardModel = boardService.GetCustomBoard("/boards", bName); 
        }

        [Given(@"Call '(.*)' endpoint with '(.*)' method for deletiton")]
        public void DeleteBoard(string endpoint, Method method)
        {
            if (customBoardModel.Id != null)
                restResponse = boardService.DeleteBoard(endpoint, method, customBoardModel.Id);
            else
                testRuntimeProvider.TestIgnore(string.Format("This step will be ignore because board does not exist on trello"));             
        }

        [Given(@"Board should be deleted")]
        public void GivenBoardShouldBeDeleted()
        {
            //assert
            if (customBoardModel.Id != null)
                restResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            else
                testRuntimeProvider.TestIgnore(string.Format("This step will be ignore because {0} does not exist on trello", boardName));            
        }
    }
}
