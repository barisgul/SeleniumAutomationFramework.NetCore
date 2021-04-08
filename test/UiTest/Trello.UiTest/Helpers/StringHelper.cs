using System;
using System.Linq;

namespace Trello.UiTest.Helpers
{
    public static class StringHelper
    {
        private static Random random = new Random();

        /// <summary>
        /// Create random text
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
