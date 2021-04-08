using FluentAssertions;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.UnitTestProvider;
using Trello.ApiTests.Entites;
using Trello.ApiTests.Entites.Cards;
using Trello.ApiTests.Entites.Lists;
using Trello.ApiTests.RequestServices;

namespace Trello.ApiTests.Steps
{
    [Binding, Scope(Feature = "TrelloCard")] 
    public class TrelloCardSteps
    {
        private readonly IUnitTestRuntimeProvider testRuntimeProvider;
        IRestResponse restResponse;
        CardService cardService;
        BoardService boardService;
        ListService listService;
        RestModel restModel;
        BoardListModel boardListModel;
        List<CardsOnAListModel> cardsOnAListModels;
        CardsOnAListModel cardsOnAListModel;
        List<CardsOnABoardModel> cardsOnABoard;
        CreateNewCardModel newCardModel;

        string boardName;
        public TrelloCardSteps(IUnitTestRuntimeProvider testRuntimeProvider)
        {
            cardService = new CardService();
            listService = new ListService();
            boardService = new BoardService();
            this.testRuntimeProvider = testRuntimeProvider;
        }

        [Given(@"As a developer I want to get cards from '(.*)'")]
        public void GivenAsADeveloperIWantToGetCardsFrom(string board)
        {
            boardName = board;
        }

        [Given(@"Call '(.*)' endpoint with '(.*)' method")]
        public void GivenCallEndpointWithMethod(string endpoint, string method) 
        {
            cardsOnABoard = boardService.GetCardsOnABoard(endpoint, boardName);
        }

        [Given(@"Board cards should return")]
        public void GivenBoardCardsShouldReturn()
        {
            cardsOnABoard.Should().NotBeEmpty();
            cardsOnABoard.Count.Should().BeGreaterThan(0);
        }

        [Given(@"As a developer I want to create a card on '(.*)' board in '(.*)' list")]
        public void GivenAsADeveloperIWantToCreateACardOnBoard(string board, string list)
        {
            var boardLists = listService.GetListsOnABoard(board); //get lists of board
            boardListModel = listService.SelectExpectedList(boardLists, list); //get list that card will be created on
            this.boardName = board;
        }

        [Given(@"Call '(.*)' endpoint with '(.*)' method for creating '(.*)' on '(.*)' list")]
        public void GivenCallEndpointWithMethodForCreatingOnList(string endpoint, Method method, string cardName, string p3)
        {
            newCardModel= cardService.CreateANewCardOnAList(endpoint,method,cardName, boardListModel);
        }

        [Given(@"'(.*)' card should be created")]
        public void GivenCardShouldBeCreated(string card)
        {
            newCardModel.name.Should().Be(card);
        }

        [Given(@"As a developer I want to move a card to Done on '(.*)' board")]
        public void GivenAsADeveloperIWantToMoveACardToDone(string board)
        {
            cardsOnAListModels = cardService.GetCardsOnAList(board);            
        }

        [Given(@"Call '(.*)' with '(.*)' method for change the description of '(.*)' on '(.*)' list")]
        public void GivenCallWithMethodForChangeTheDescriptionOf(string endpoint, Method method, string card,string list)
        {
            cardsOnAListModel = cardService.SelectExpedtedCardFromList(cardsOnAListModels, card);
            cardService.UpdateACardOnAList(cardsOnAListModel, "ThisCardModified");
        }

        [Given(@"Call '(.*)' endpoint with '(.*)' for moving '(.*)' card from '(.*)' to '(.*)'")]
        public void GivenCallEndpointWithForMovingCardFromTo(string p0, string p1, string p2, string p3, string p4)
        {
            cardService.CloseCardAsComplete(cardsOnAListModel);
        }
         

        [Given(@"Call '(.*)' with '(.*)' method for delete the '(.*)'")]
        public void GivenCallWithMethodForDeleteThe(string endpoint, Method method, string card)
        {
            cardsOnAListModels = cardService.GetCardsOnAList(boardName);
            cardsOnAListModel = cardService.SelectExpedtedCardFromList(cardsOnAListModels, card);
            restResponse = cardService.DeleteCardOnABoard(cardsOnAListModel);
        }

        [Given(@"'(.*)' card should be deleted")]
        public void GivenCardShouldBeDeleted(string card)
        {
            restResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}
