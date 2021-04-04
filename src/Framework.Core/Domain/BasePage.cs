using Framework.Core.Infrastructure.Managers;
using System;

namespace Framework.Core.Domain
{
    public class BasePage : PageManager, IDisposable
    {
        public BasePage()
        {
            Init();
        }

        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
