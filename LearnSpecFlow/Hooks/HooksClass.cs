using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using BoDi;
using LearnSpecFlow.Reporting;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports;

namespace LearnSpecFlow.Hooks
{
    [Binding]
    public sealed class HooksClass : ExtentReport
    {
        private readonly IObjectContainer _container;

        public HooksClass(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("<<<<< Inside Before Test Run >>>>>");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("<<<<< Inside After Test Run >>>>>");
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("<<<<< Inside Before Feature >>>>>");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("<<<<< Inside After Feature >>>>>");
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("<<<<< Inside Before Scenario >>>>>");
            IWebDriver driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            _container.RegisterInstanceAs<IWebDriver>(driver);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("<<<<< Inside After Scenario >>>>>");
            var driver = _container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
            }
        }

        [BeforeScenarioBlock]
        public void BeforeScenarioBlock()
        {
            Console.WriteLine("<<<<< Inside Before Block >>>>>");
        }

        [AfterScenarioBlock]
        public void AfterScenarioBlock()
        {
            Console.WriteLine("<<<<< Inside After Block >>>>>");
        }

        [BeforeStep]
        public void BeforeStep()
        {
            Console.WriteLine("<<<<< Inside Before Step >>>>>");
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("<<<<< Inside After Step >>>>>");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            var driver = _container.Resolve<IWebDriver>();

            //When scenario passed...
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }

            //When scenario fails...
            if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
            }
        }
    }
}