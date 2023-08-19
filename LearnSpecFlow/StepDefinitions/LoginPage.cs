using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LearnSpecFlow.StepDefinitions
{
    [Binding]
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"User should launch the application in the edge browser")]
        public void GivenUserShouldLaunchTheApplicationInTheEdgeBrowser()
        {
            driver.Url = "https://magento.softwaretestingboard.com/customer/account/login";
        }

        [Given(@"User should enter the value for Username as ""([^""]*)"" and Password as ""([^""]*)""")]
        public void GivenUserShouldEnterTheValueForUsernameAsAndPasswordAs(string username, string password)
        {
            driver.FindElement(By.XPath("//input[@id='email']")).SendKeys(username);
            driver.FindElement(By.XPath("//input[@title='Password']")).SendKeys(password);
        }

        [When(@"User clicks on the SignIn Button")]
        public void WhenUserClicksOnTheSignInButton()
        {
            driver.FindElement(By.XPath("//button[@class='action login primary']")).Click();
        }

        [Then(@"The application should navigate the user to My Account page")]
        public void ThenTheApplicationShouldNavigateTheUserToMyAccountPage()
        {
            String pageIdentifier = driver.FindElement(By.XPath("//*[@data-ui-id='page-title-wrapper']")).Text;
            Assert.AreEqual(pageIdentifier, "My Account");
            driver.Close();
        }

        [Then(@"The application should not navigate the user to My Account page")]
        public void ThenTheApplicationShouldNotNavigateTheUserToMyAccountPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            String pageIdentifier = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-bind,'message.text')]"))).Text;
            Console.WriteLine(pageIdentifier);
            if (!pageIdentifier.Contains("incorrect"))
                Assert.Fail();
        }
    }
}
