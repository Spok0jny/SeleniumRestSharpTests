using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ParametryLogowanie
{
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TestCase("ZlyUser", "SuperSecretPassword!")]
        [TestCase("tomsmith", "ZleHaslo")]
        public void InvalidLoginTest(string username, string password)
        //{
        //    driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
        //    IWebElement usernameInput = driver.FindElement(By.Id("username"));
        //    IWebElement passwordInput = driver.FindElement(By.Id("password"));
        //    IWebElement loginButton = driver.FindElement(By.ClassName("radius"));


        //    usernameInput.SendKeys(username);
        //    passwordInput.SendKeys(password);
        //    loginButton.Click();
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        //    IWebElement errorMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("flash")));

        //    Assert.That(errorMessage.Displayed, Is.True, "Error message is not displayed for invalid login.");


        //}
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.ClassName("radius")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement errorMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("flash")));
            Assert.That(errorMessage.Displayed, Is.True, "Error message is not displayed for invalid login.");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();

        }
    }
}
