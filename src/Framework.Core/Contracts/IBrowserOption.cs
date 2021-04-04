using Framework.Core.Infrastructure.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Contracts
{
    internal interface IBrowserOption
    {
        object GetOptions();
    }
}
