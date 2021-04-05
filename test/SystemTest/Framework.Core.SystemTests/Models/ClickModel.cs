﻿using Framework.Core.Domain;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;

namespace Framework.Core.SystemTests.Models
{
    public class ClickModel : BasePage
    { 
        public IWebElement LinkNormal => driver.FindElement(By.Id("normal")); 
        public IWebElement LinkOverflow => driver.FindElement(By.Id("overflowLink"));  

        public ClickModel()
        {
        } 
        public void GoTo()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                                                                           "\\Sources\\clicks.html";
            NavigateTo(path);
        }

        public void ClickLinkNormal()
        { 
            LinkNormal.Click();
        }

        public void ClickLinkOwerFlow()
        { 
            LinkOverflow.Click();
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}