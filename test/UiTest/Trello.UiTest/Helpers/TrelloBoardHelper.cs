using System.Collections.Generic;

namespace Trello.UiTest.Helpers
{
    public static class TrelloBoardHelper
    { 
        public static Dictionary<string, int> InitBoardModel()
        {
            Dictionary<string, int> boardList = new Dictionary<string, int>();

            boardList.Add("To Do", 0);
            boardList.Add("Doing", 1);
            boardList.Add("Blocked", 2);
            boardList.Add("Done", 3);

            return boardList;
        }
    }
}
