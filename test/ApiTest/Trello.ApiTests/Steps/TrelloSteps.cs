using FluentAssertions;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Trello.ApiTests.Entites;
using Trello.ApiTests.RequestServices;

namespace Trello.ApiTests.Steps
{
    [Binding]
    public class TrelloSteps
    {
        BoardService boardService;
        RestModel restModel;
        List<UserBoards> boards;
        public TrelloSteps()
        {
            boardService = new BoardService();
        } 
        [Given(@"I make a rest request with below criteria")]
        public void GivenIPrepareARestRequestAsBelow(Table table)
        {
            restModel = table.CreateInstance<RestModel>();
            boards = boardService.GetUserBoard(restModel.Endpoint,restModel.Method);
        } 

        [Then(@"Board information should return")] 
        public void ThenBoardInformationShouldReturn()
        {
            boards.Should().NotBeNull();
        }
    }
}
