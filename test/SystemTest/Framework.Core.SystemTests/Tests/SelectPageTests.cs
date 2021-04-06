using FluentAssertions;
using Framework.Common;
using Framework.Core.SystemTests.Models;
using System;
using Xunit;

namespace Framework.Core.SystemTests.Tests
{
    public class SelectPageTests : IDisposable
    {
        SelectPageModel selectPageModel; 
        public SelectPageTests()
        {
            selectPageModel = new SelectPageModel();
            selectPageModel.GoToInternalPage();
        }

        [Fact]
        [Trait("Category", "WebDriver.SystemTest")]
        public void ClickSelectTwo()
        {
            selectPageModel.ClickSelectTwo();
        }

        [Fact]
        [Trait("Category", "WebDriver.SystemTest")]
        public void ClickLinkLinkRoquefort()
        {
            selectPageModel.ClickLinkLinkRoquefort();
        }

        [Fact]
        [Trait("Category", "WebDriver.SystemTest")]
        public void ClickRandomMultipleOne()
        {
            selectPageModel.ClickLinkLinkRoquefort();
        }

        [Fact]
        [Trait("Category", "WebDriver.SystemTest")]
        public void Click_CanClickOnButtonAndFollowIt()
        {
            Logger.Info("Click_CanClickOnALinkAndFollowIt test started");
            selectPageModel.ClickSelectTwo();

            string pageTitle = selectPageModel.GetPageTitle();

            pageTitle.Should().Contain("Multiple Selection");
        }


        public void Dispose()
        {
            selectPageModel.Dispose();
        }
    }
}
