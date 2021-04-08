using Framework.ApiHandler;
using Framework.ApiHandler.Contracts;
using Framework.ApiHandler.Implementations;
using RestSharp;
using System;
using System.Collections.Generic;
using Trello.ApiTests.Entites.Cards;
using Trello.ApiTests.Entites.Lists;
using Trello.ApiTests.Helpers;

namespace Trello.ApiTests.RequestServices
{
    public class CardService : RestTestBase
    {

        IRestClientHandler restClientHandler;
        IRestRequest restRequest;
        ListService listService;

        /// <summary>
        /// defaultc constructor
        /// </summary>
        public CardService()
        {
            restClientHandler = new RestClientHandler();
            restRequest = new RestRequest();
            listService = new ListService();
        }

        /// <summary>
        /// Create a new card on a list
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="method"></param>
        /// <param name="cardName"></param>
        /// <param name="boardListModel"></param>
        /// <returns></returns>
        public CreateNewCardModel CreateANewCardOnAList(string endpoint, Method method, string cardName, BoardListModel boardListModel)
        {
            restRequest.AddQueryParameter("name", cardName);
            restRequest.AddQueryParameter("idList", boardListModel.id);
            string baseUrl = BaseUrl + EndpointConstants.cardsPath;
            CreateNewCardModel createNewCardModel = restClientHandler.Execute<CreateNewCardModel>(new Uri(baseUrl), method, restRequest);

            return createNewCardModel;
        }

        /// <summary>
        /// Returns all cards on a list
        /// </summary>
        /// <param name="boardName"></param>
        /// <returns></returns>
        public List<CardsOnAListModel> GetCardsOnAList(string boardName)
        {
            var listsOnCard = listService.GetListsOnABoard(boardName);
            var expectedList = listService.SelectExpectedList(listsOnCard, "To Do");

            string baseUrl = BaseUrl + EndpointConstants.listsPath + "/" + expectedList.id +EndpointConstants.cardsPath ;
            List<CardsOnAListModel> cardsOnAListModels = restClientHandler.Execute<List<CardsOnAListModel>>(new Uri(baseUrl), Method.GET, restRequest);

            return cardsOnAListModels;
        }

        /// <summary>
        /// Returns card on a list for card name and idCard info
        /// </summary>
        /// <param name="cardsOnAListModels"></param>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public CardsOnAListModel SelectExpedtedCardFromList(List<CardsOnAListModel> cardsOnAListModels, string cardName)
        {
            CardsOnAListModel cardsOnAListModel = null;
            foreach (var item in cardsOnAListModels)
            {
                if (item.name.Equals(cardName))
                {
                    cardsOnAListModel = item;
                    break;
                }
            }
            return cardsOnAListModel;
        }

        /// <summary>
        /// Add description to a card on a list
        /// </summary>
        /// <param name="cardOnAlist"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public UpdateACardModel UpdateACardOnAList(CardsOnAListModel cardOnAlist, string description)
        {
            restRequest.AddQueryParameter("desc", description);
            
            string baseUrl = BaseUrl + EndpointConstants.cardsPath + "/" + cardOnAlist.id;

            UpdateACardModel updateACardModel = restClientHandler.Execute<UpdateACardModel>(new Uri(baseUrl), Method.PUT, restRequest);

            return updateACardModel;
        }

        /// <summary>
        /// Archive a card on a board
        /// </summary>
        /// <param name="cardsOnAListModel"></param>
        internal void CloseCardAsComplete(CardsOnAListModel cardsOnAListModel)
        {
            restRequest.AddQueryParameter("closed", "true");
            string baseUrl = BaseUrl + EndpointConstants.cardsPath + "/" + cardsOnAListModel.id;
            IRestResponse response = restClientHandler.Execute(new Uri(baseUrl), Method.PUT, restRequest);
        }

        /// <summary>
        /// Delete a card on a board
        /// </summary>
        /// <param name="cardsOnAListModel"></param>
        /// <returns></returns>
        internal IRestResponse DeleteCardOnABoard(CardsOnAListModel cardsOnAListModel)
        { 
            string baseUrl = BaseUrl + EndpointConstants.cardsPath + "/" + cardsOnAListModel.id;
            IRestResponse response = restClientHandler.Execute(new Uri(baseUrl), Method.DELETE, restRequest);

            return response;
        }
    }
}
