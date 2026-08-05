using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
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
            var usernameField = _driver.FindElement(By.Id("username"));
            Assert.That(usernameField.Displayed, Is.True, "Username field is not displayed.");


            usernameField.SendKeys("testing...");
            usernameField.Clear();
            usernameField.SendKeys("tomsmith");

            var passwordField = _driver.FindElement(By.Id("password"));
            Assert.That(passwordField.Displayed, Is.True, "Password field is not displayed.");

            Assert.That(passwordField.GetAttribute("type"), Is.EqualTo("password"), "Password field type is not 'password'.");
            var loginButton = _driver.FindElement(By.XPath("//i[@class='fa fa-2x fa-sign-in']"));


            Assert.That(loginButton.Text, Is.EqualTo("Login"), "Login button text is not 'Login'.");
            loginButton.Click();
        }


        [TearDown]
        public void TearDown() 
        {
            _driver.Dispose();
            _driver.Quit();
        }
    }
}
