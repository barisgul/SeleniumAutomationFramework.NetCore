using Framework.ApiHandler;
using Framework.ApiHandler.Contracts;
using Framework.ApiHandler.Implementations;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Trello.ApiTests.Entites;
using Trello.ApiTests.Entites.Lists;
using Trello.ApiTests.Helpers;

namespace Trello.ApiTests.RequestServices
{
    public class ListService : RestTestBase
    {
        IRestClientHandler restClientHandler;
        IRestRequest restRequest;
        BoardService boardService;
        public ListService()
        {
            restClientHandler = new RestClientHandler();
            restRequest = new RestRequest();
            boardService = new BoardService();
        }

        public List<BoardListModel> GetListsOnABoard(string boardName)
        {
            CustomBoardModel boardModel = boardService.GetCustomBoard(EndpointConstants.boardsPath, boardName);
            string baseUrl = BaseUrl + EndpointConstants.boardsPath +"/"+ boardModel.Id + EndpointConstants.listsPath ;
            List<BoardListModel> boardLists = restClientHandler.Execute<List<BoardListModel>>(new Uri(baseUrl), Method.GET, restRequest);

            return boardLists;
        }

        public BoardListModel SelectExpectedList(List<BoardListModel> boardListModels, string listName)
        {
            BoardListModel boardListModel = null;
            foreach (var item in boardListModels)
            {
                if (item.name.Equals(listName))
                {
                    boardListModel = item;
                    break;
                }
            }

            return boardListModel;
        }

    }
}
