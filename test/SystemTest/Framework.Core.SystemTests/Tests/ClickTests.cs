using Framework.Core.SystemTests.Models;
using Xunit;
using System;
using FluentAssertions;
using Framework.Common;

namespace Framework.Core.SystemTests.Tests
{
    public class ClickTests : IDisposable
    {
        /// <summary>
        /// This class contains webdriver based system tests and runs locally.
        /// For full library documentation https://dlaaal.com/Dlaaal-webApp/node_modules/selenium-webdriver/lib/test/data/
        /// </summary>
        private readonly ClickModel clickModel = new ClickModel();
        public ClickTests()
        {             
            clickModel.GoToInternalPage();
        } 

        [Fact]
        [Trait("Category", "WebDriver.SystemTest")]
        public void ClickToNormalLink()
        {
            Logger.Info("ClickToNormalLink test started");
            clickModel.ClickLinkNormal();
        }


        [Fact]
        [Trait("Category", "WebDriver.SystemTest")]
        public void ClickLinkOverflow()
        {
            Logger.Info("ClickLinkOverflow test started");
            clickModel.ClickLinkOwerFlow();
        }

        [Fact]
        [Trait("Category", "WebDriver.SystemTest")]
        public void Click_CanClickOnALinkAndFollowIt()
        {
            Logger.Info("Click_CanClickOnALinkAndFollowIt test started");
            clickModel.ClickLinkNormal();

            string pageTitle = clickModel.GetPageTitle();

            pageTitle.Should().Contain("xhtmlTest"); 
        }

        public void Dispose()
        {
            clickModel.Dispose();
        }
    }
}
