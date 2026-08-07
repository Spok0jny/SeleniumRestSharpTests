using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Module10
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
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            IWebElement loginButton = _driver.FindElement(By.CssSelector("button[type='submit']"));

            js.ExecuteScript("arguments[0].click()", loginButton);

            var pageTitle = js.ExecuteScript("return document.title;");
           
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Dispose();
        }
    }
}
