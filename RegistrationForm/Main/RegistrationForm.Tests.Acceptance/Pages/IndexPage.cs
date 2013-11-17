using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RegistrationForm.Tests.Acceptance.Pages
{
    public class IndexPage : BasePage
    {
        public static string URL = "/";
        public override string DefaultTitle { get { return "Home Page - My ASP.NET MVC Application"; } }

        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement LoginButton;

        [FindsBy(How = How.LinkText, Using = "Log off")]
        public IWebElement LogoutButton;

        [FindsBy(How = How.Id, Using = "registerLink")]
        public IWebElement RegisterButton;

        internal void IsLoginButtonAvaliable()
        {
            if (LoginButton == null)
                throw new Exception("Unable to find the Login button on the page");

            AssertElementText(LoginButton, "Log in", "login button");
        }

        internal RegistrationPage ClickRegisterButton()
        {
            RegisterButton.Click();
            return GetInstance<RegistrationPage>(Driver);
        }

        internal void IsLogoutButtonAvaliable()
        {
            if (LogoutButton == null)
                throw new Exception("Unable to find the Logout button on the page");

            Assert.AreEqual("Log off", LogoutButton.Text);
        }
    }
}
