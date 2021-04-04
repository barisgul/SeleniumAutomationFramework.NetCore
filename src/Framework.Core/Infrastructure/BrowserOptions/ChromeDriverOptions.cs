using OpenQA.Selenium.Chrome;

namespace Framework.Core.Infrastructure.BrowserOptions
{
    public class ChromeDriverOptions 
    {
        public static ChromeOptions GetChromeOptions()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "en");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

            return chromeOptions;
        }
    }
}
