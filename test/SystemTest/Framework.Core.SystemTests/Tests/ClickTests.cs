using Framework.Core.SystemTests.Models;
using Xunit;
using System;
using FluentAssertions;

namespace Framework.Core.SystemTests.Tests
{
    public class ClickTests : IDisposable
    {
        /// <summary>
        /// This class contains webdriver based system tests and run locally.
        /// For full library documentation https://dlaaal.com/Dlaaal-webApp/node_modules/selenium-webdriver/lib/test/data/
        /// </summary>
        private readonly ClickModel clickModel = new ClickModel();
        public ClickTests()
        {
            clickModel.GoTo();
        } 

        [Fact]
        [Trait("Category", "WebDriver.SystemTest")]
        public void ClickToNormalLink()
        {
           
            clickModel.ClickLinkNormal();
        }


        [Fact]
        [Trait("Category", "WebDriver.SystemTest")]
        public void ClickLinkOverflow()
        {
            clickModel.ClickLinkOwerFlow();
        }

        [Fact]
        [Trait("Category", "WebDriver.SystemTest")]
        public void Click_CanClickOnALinkAndFollowIt()
        {
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
