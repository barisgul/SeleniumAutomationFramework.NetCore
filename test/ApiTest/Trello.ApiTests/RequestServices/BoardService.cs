using Framework.ApiHandler.Contracts;
using Framework.ApiHandler.Implementations;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Trello.ApiTests.Entites;

namespace Trello.ApiTests.RequestServices
{
    public class BoardService : RestTestBase
    {
        const string user = "barisgul8";
        private readonly string endpoint;

        IRestClientHandler restClientHandler;
        IRestRequest restRequest;
        public BoardService()
        {
            restClientHandler = new RestClientHandler();
            restRequest = new RestRequest();
        }

        public List<UserBoards> GetUserBoard(string endpoint, Method method)
        {
            string url = BaseUrl + endpoint;
            List<UserBoards> boards = restClientHandler.Execute<List<UserBoards>>(new Uri(url), method, restRequest);

            return boards;
        }

        public Board GetBoard(string boardId)
        {
            Board board = restClientHandler.Execute<Board>(new Uri("https://api.trello.com/1/boards/mVQHHfp3/"), Method.GET, restRequest);

            return board;
        }
    }
}
