using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AcceptanceTesting
{
    public class TestFixtureBase
    {
        protected IWebDriver CurrentDriver { get; set; }

        [SetUp]
        public void Test_Setup()
        {
            CurrentDriver = Browser.Current;
        }



        [TearDown]
        public void Test_Teardown()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Status == TestStatus.Failed
                        && CurrentDriver is ITakesScreenshot)
                {
                    ((ITakesScreenshot)CurrentDriver).GetScreenshot().SaveAsFile(TestContext.CurrentContext.Test.FullName + ".jpg", ImageFormat.Jpeg);
                }
            }
            catch { }	// null ref exception occurs from accessing TestContext.CurrentContext.Result.Status property

            try
            {
                CurrentDriver.Quit();
            }
            catch { }
        }
    }
}
