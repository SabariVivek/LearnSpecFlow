using OpenQA.Selenium;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace LearnSpecFlow.StepDefinitions
{
    [Binding]
    public class DataDrivenTesting
    {
        private IWebDriver driver;

        public DataDrivenTesting(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given(@"User should launch the application")]
        public void GivenUserShouldLaunchTheApplication()
        {
            driver.Url = "https://magento.softwaretestingboard.com/customer/account/login";
        }

        [Given(@"User should enter the value as ""([^""]*)"" and ""([^""]*)""")]
        public void GivenUserShouldEnterTheValueAsAnd(string username, string password)
        {
            driver.FindElement(By.XPath("//input[@id='email']")).SendKeys(username);
            driver.FindElement(By.XPath("//input[@title='Password']")).SendKeys(password);
        }

        [When(@"User clicks on Login Button")]
        public void WhenUserClicksOnLoginButton()
        {
            driver.FindElement(By.XPath("//button[@class='action login primary']")).Click();
        }

        [Then(@"Verify the output with ""([^""]*)"" data")]
        public void ThenVerifyTheOutputWithData(string valid)
        {
            if (valid.Equals("Valid"))
            {
                String pageIdentifier = driver.FindElement(By.XPath("//*[@data-ui-id='page-title-wrapper']")).Text;
                Assert.AreEqual(pageIdentifier, "My Account");
            }
            else if (valid.Equals("InValid"))
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                String pageIdentifier = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-bind,'message.text')]"))).Text;
                if (!pageIdentifier.Contains("incorrect"))
                    Assert.Fail();
            }
        }
    }
}
