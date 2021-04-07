using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Trello.UiTest.Helpers
{
    public static class SelectHelper
    {  
        public static void SelectByIndex(IWebElement element, int index)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByIndex(index);
        }

        public static void SelectByText(IWebElement element, string text)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }

        public static void SelectByValue(IWebElement element, string value)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }
    }
}
