using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace LearnSpecFlow.StepDefinitions
{
    [Binding]
    public class RepeatedSteps
    {
        private IWebDriver driver;

        public RepeatedSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"User should launch the application in edge browser")]
        public void GivenUserShouldLaunchTheApplicationInEdgeBrowser()
        {
            driver.Url = "https://magento.softwaretestingboard.com/customer/account/login";
        }

        [Given(@"User should enter the value for Username and Password as ""([^""]*)"" and ""([^""]*)""")]
        public void GivenUserShouldEnterTheValueForUsernameAndPasswordAsAnd(string username, string password)
        {
            driver.FindElement(By.XPath("//input[@id='email']")).SendKeys(username);
            driver.FindElement(By.XPath("//input[@title='Password']")).SendKeys(password);
        }

        [When(@"User clicks on SignIn Button")]
        public void WhenUserClicksOnSignInButton()
        {
            driver.FindElement(By.XPath("//button[@class='action login primary']")).Click();
        }

        [Then(@"The application should navigate the user to the My Account page")]
        public void ThenTheApplicationShouldNavigateTheUserToTheMyAccountPage()
        {
            String pageIdentifier = driver.FindElement(By.XPath("//*[@data-ui-id='page-title-wrapper']")).Text;
            Assert.AreEqual(pageIdentifier, "My Account");
            driver.Close();
        }

        [Then(@"The application should not navigate the user to the My Account page")]
        public void ThenTheApplicationShouldNotNavigateTheUserToTheMyAccountPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            String pageIdentifier = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-bind,'message.text')]"))).Text;
            Console.WriteLine(pageIdentifier);
            if (!pageIdentifier.Contains("incorrect"))
                Assert.Fail();
            driver.Quit();
        }
    }
}
