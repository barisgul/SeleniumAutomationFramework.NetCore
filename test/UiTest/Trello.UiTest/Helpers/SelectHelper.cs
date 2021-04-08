using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Trello.UiTest.Helpers
{
    public static class SelectHelper
    {  
        /// <summary>
        /// Select By Option Index
        /// </summary>
        /// <param name="element"></param>
        /// <param name="index"></param>
        public static void SelectByIndex(IWebElement element, int index)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByIndex(index);
        }

        /// <summary>
        /// Select by option text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void SelectByText(IWebElement element, string text)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }

        /// <summary>
        /// Select by option value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectByValue(IWebElement element, string value)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }
    }
}
