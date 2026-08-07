using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Modul9
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
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com");
            string originalWindow = _driver.CurrentWindowHandle;


            _driver.FindElement(By.LinkText("JavaScript Alerts")).Click();

            

            _driver.FindElement(By.XPath("//button[text()='Click for JS Alert']")).Click();

            IAlert alert = _driver.SwitchTo().Alert();

            Assert.That(alert.Text, Is.Not.Null);
            string alertText = alert.Text;
            alert.Accept();

            Assert.That(_driver.FindElement(By.Id("result")).Text, Is.Not.Null);

            _driver.Navigate().Back();

            _driver.FindElement(By.LinkText("Multiple Windows")).Click();
            _driver.FindElement(By.XPath("//a[@href='/windows/new']")).Click();

            foreach(string window in _driver.WindowHandles)
            {
                if(window != originalWindow)
                {
                    _driver.SwitchTo().Window(window);
                    break;
                }
            }

            Assert.That(_driver.FindElement(By.TagName("h3")).Text, Is.Not.Null);


        }


        [TearDown]
        public void CleanUp()
        {
            _driver.Dispose();
        }
    }
}
