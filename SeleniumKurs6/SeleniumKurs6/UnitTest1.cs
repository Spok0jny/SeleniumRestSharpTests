using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumKurs6
{
    //Because we have LoginPage.cs class, we can use it in our tests, so we don't have to write the same code again and again, we can just use the methods from LoginPage.cs class
    public class Tests
    {
        private IWebDriver _driver; 



        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }



        [Test]
        public void Test1()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            LoginPage loginPage = new LoginPage(_driver); 
            loginPage.EnterLogin("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLoginButton();

            Assert.That(_driver.Url, Does.Contain("/secure"));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}
