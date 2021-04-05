using Framework.Core.Infrastructure.Managers;
using System;

namespace Framework.Core.Domain
{
    public abstract class BasePage : PageManager, IDisposable
    {
        public BasePage()
        {
            Init();
        }

        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public virtual void Dispose()
        {
            driver.Close();
            driver.Quit(); 
        }
    }
}
