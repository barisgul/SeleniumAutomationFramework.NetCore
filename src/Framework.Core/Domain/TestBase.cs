using Framework.Common;
using Framework.Core.Infrastructure.Managers;
using System;

namespace Framework.Core.Domain
{
    public abstract class TestBase : DriverManager, IDisposable
    { 
        /// <summary>
        /// default constructor
        /// </summary>
        public TestBase() 
        {
            Logger.Info(string.Format("{0} Test/s Started", this.GetType().Name));
            Init();
        }

        /// <summary>
        /// Navigates to url
        /// </summary>
        /// <param name="url"></param>
        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Call dispose method. In test class works like TearDown
        /// </summary>
        public void Dispose()
        { 
            driver.Quit();
            Logger.Info("Dispose methode initialized. Selenium WebDriver closed!");
            Logger.Info(string.Format("{0} Test/s Finished", this.GetType().Name));
        }
    }
}
