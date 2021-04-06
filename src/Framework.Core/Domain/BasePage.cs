using Framework.Core.Infrastructure.Managers;

namespace Framework.Core.Domain
{
    public abstract class BasePage : DriverManager
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
            driver.Quit(); 
        }
    }
}
