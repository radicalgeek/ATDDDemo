using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RegistrationForm.Tests.Acceptance.Pages
{
    public class RegistrationPage : BasePage
    {
        public override string DefaultTitle { get { return "Register - My ASP.NET MVC Application"; } }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement UserNameTextBox;

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordTextBox;

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        public IWebElement ConfirmPasswordTextBox;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement SubmitButton;

        internal void PopulateUserNameTextBox(string userName)
        {
            UserNameTextBox.SendKeys(userName);
        }

        internal void PopulatePasswordTextBox(string password)
        {
            PasswordTextBox.SendKeys(password);
        }

        internal void PopulateConfirmPasswordTextBox(string password)
        {
            ConfirmPasswordTextBox.SendKeys(password);
        }

        internal BasePage SubmitForm()
        {
            SubmitButton.Click();
            BasePage returnPage;
            try
            {
                returnPage = GetInstance<IndexPage>(Driver);
            }
            catch
            {
                returnPage = GetInstance<RegistrationPage>(Driver);
            }
            return returnPage;
        }
    }
}
