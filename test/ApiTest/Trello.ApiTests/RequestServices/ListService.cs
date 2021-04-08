using Framework.ApiHandler;
using Framework.ApiHandler.Contracts;
using Framework.ApiHandler.Implementations;
using RestSharp;
using System;
using System.Collections.Generic;
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
        
        /// <summary>
        /// default constructor
        /// </summary>
        public ListService()
        {
            restClientHandler = new RestClientHandler();
            restRequest = new RestRequest();
            boardService = new BoardService();
        }

        /// <summary>
        /// return all list on a board
        /// </summary>
        /// <param name="boardName"></param>
        /// <returns></returns>
        public List<BoardListModel> GetListsOnABoard(string boardName)
        {
            CustomBoardModel boardModel = boardService.GetCustomBoard(EndpointConstants.boardsPath, boardName);
            string baseUrl = BaseUrl + EndpointConstants.boardsPath +"/"+ boardModel.Id + EndpointConstants.listsPath ;
            List<BoardListModel> boardLists = restClientHandler.Execute<List<BoardListModel>>(new Uri(baseUrl), Method.GET, restRequest);

            return boardLists;
        }

        /// <summary>
        /// get expected board on a list
        /// </summary>
        /// <param name="boardListModels"></param>
        /// <param name="listName"></param>
        /// <returns></returns>
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
