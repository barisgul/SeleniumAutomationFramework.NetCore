using Framework.Core.Infrastructure.Entites;
using Framework.Core.Infrastructure.Managers;
using Moq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Framework.ApiHandler.UnitTest
{
    public class DriverFactoryTests
    {
        Mock<IWebDriver> mockDriver;
        public DriverFactoryTests()
        {
            mockDriver = new Mock<IWebDriver>();
        }

        [Fact]
        public void test()
        {
            DriverFactory driverFactory = new DriverFactory();
            var tmp = driverFactory.GetDriver(ExecutionEnvironment.LOCAL, Core.Entites.BrowserType.CHROME);
        }
    }
}
