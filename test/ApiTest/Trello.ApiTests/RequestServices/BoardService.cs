using Framework.ApiHandler;
using Framework.ApiHandler.Contracts;
using Framework.ApiHandler.Implementations;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trello.ApiTests.Entites;
using Trello.ApiTests.Entites.Cards;
using Trello.ApiTests.Helpers;

namespace Trello.ApiTests.RequestServices
{
    public class BoardService : RestTestBase
    {
        IRestClientHandler restClientHandler;
        IRestRequest restRequest;
        public BoardService()
        {
            restClientHandler = new RestClientHandler();
            restRequest = new RestRequest();
        }

        public CreateBoardModel CreateBoard(string endpoint, Method method, string boardName)
        {
            string url = BaseUrl + endpoint;
            restRequest.AddQueryParameter("name", boardName);
            CreateBoardModel board = restClientHandler.Execute<CreateBoardModel>(new Uri(url), method, restRequest);

            return board;
        }

        /// <summary>
        /// returns a user's boards
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public List<UserBoards> GetUserBoards(string endpoint, Method method)
        {  
            string fullEndpoint = EndpointConstants.memberPath + EndpointConstants.userPath + EndpointConstants.boardsPath;
            string url = BaseUrl + fullEndpoint;
            List<UserBoards> boards = restClientHandler.Execute<List<UserBoards>>(new Uri(url), method, restRequest);

            return boards;
        }

        public IRestResponse DeleteBoard(string endpoint, Method method, string boardId)
        {
            string url = BaseUrl + endpoint +"/"+boardId;
            IRestResponse restResponse = restClientHandler.Execute(new Uri(url), method, restRequest);

            return restResponse;
        }
        

        /// <summary>
        /// return board id with name
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="boardName"></param>
        /// <returns></returns>
        public CustomBoardModel GetCustomBoard(string endpoint,string boardName)
        {
            CustomBoardModel customBoardModel = new CustomBoardModel();
            var boards = GetUserBoards(endpoint, Method.GET); 
            foreach (var item in boards)
            {
                if (item.name.Equals(boardName))
                {
                    customBoardModel.Name = item.name;
                    customBoardModel.Id = TryGetBoardId(item.shortUrl);
                    break;
                }
            }
            return customBoardModel;
        }
        private string TryGetBoardId(string shortUrl)
        {
            var items = shortUrl.Split('/');
            string boardId = items.Last();

            return boardId;
        }

        public List<CardsOnABoardModel> GetCardsOnABoard(string endpoint, string boardName)
        {
            CustomBoardModel customBoardModel = GetCustomBoard("/boards", boardName);
            string url = BaseUrl + endpoint + "/" + customBoardModel.Id + EndpointConstants.cardsPath;
            List<CardsOnABoardModel> cards = restClientHandler.Execute<List<CardsOnABoardModel>>(new Uri(url), Method.GET, restRequest);

            return cards;
        }


        public UpdateBoardModel UpdateBoardName(string endpoint, string boardId, Method method, string newName)
        {
            string url = BaseUrl + endpoint + "/" + boardId;
            restRequest.AddQueryParameter("name", newName);
            UpdateBoardModel updateBoardModel = restClientHandler.Execute<UpdateBoardModel>(new Uri(url), method, restRequest);

            return updateBoardModel;
        }
    }
}
