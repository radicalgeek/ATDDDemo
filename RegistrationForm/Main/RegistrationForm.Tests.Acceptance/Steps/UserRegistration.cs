using NUnit.Framework;
using RegistrationForm.Tests.Acceptance.Pages;
using TechTalk.SpecFlow;
using RegistrationForm.Tests.Acceptance;
using RegistrationForm.Controllers;
using System.Net;
using System;

namespace RegistrationForm.Tests.Acceptance.Steps
{
    [Binding]
    public class UserRegistration : BaseSteps
    {

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            CurrentPage = (BasePage)BasePage.LoadIndexPage(CurrentDriver, BasePage.BaseUrl);
        }

        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            CurrentPage.As<IndexPage>().IsLoginButtonAvaliable();
        }

        [When(@"I click the register button")]
        public void WhenIClickTheRegisterButton()
        {
            NextPage = CurrentPage.As<IndexPage>().ClickRegisterButton();
        }

        [When(@"fill of the registration form with the following details")]
        public void WhenFillOfTheRegistrationFormWithTheFollowingDetails(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<RegistrationPage>().PopulateUserNameTextBox(form.UserName + new Random(DateTime.Now.Second + DateTime.Now.Minute).Next(1, 9999).ToString());
            CurrentPage.As<RegistrationPage>().PopulatePasswordTextBox(form.Password);
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(form.ConfirmPassword);
        }

        [When(@"I submit the form")]
        public void WhenISubmitTheForm()
        {
            NextPage =  CurrentPage.As<RegistrationPage>().SubmitForm();

        }

        [Then(@"I redirected to the home page")]
        public void ThenIRedirectedToTheHomePage()
        {
            CurrentPage.Is<IndexPage>();
        }

        [Then(@"I will be logged in")]
        public void ThenIWillBeLoggedIn()
        {
            CurrentPage.As<IndexPage>().IsLogoutButtonAvaliable();
        }

        [Then(@"I will see the message (.*)")]
        public void ThenIWillSeeTheMessage(string message)
        {
            CurrentPage.IsTextOnPage(message);
        }


    }
}
