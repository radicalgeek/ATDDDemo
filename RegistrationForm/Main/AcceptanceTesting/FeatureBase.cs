using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AcceptanceTesting
{
    public class BaseSteps : TestFixtureBase
    {



        /// <summary>
        /// Shortcut property to Settings.CurrentSettings.Defaults for readability
        /// </summary>
       // protected DefaultValues.DefaultValues Default { get { return Settings.CurrentSettings.Defaults; } }

        protected BasePage NextPage { set { CurrentPage = value; } }

        protected BasePage CurrentPage
        {
            get { return (BasePage)ScenarioContext.Current["CurrentPage"]; }
            set { ScenarioContext.Current["CurrentPage"] = value; }
        }

        [BeforeScenario("UI")]
        public void BeforeScenario()
        {
            if (!ScenarioContext.Current.ContainsKey("CurrentDriver"))
            {
                Test_Setup();
                ScenarioContext.Current.Add("CurrentDriver", CurrentDriver);
            }
            else
            {
                CurrentDriver = (IWebDriver)ScenarioContext.Current["CurrentDriver"];
            }
        }

        [AfterScenario("UI")]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.ContainsKey("CurrentDriver"))
            {
                Test_Teardown();
                ScenarioContext.Current.Remove("CurrentDriver");
            }
        }
    }
}
