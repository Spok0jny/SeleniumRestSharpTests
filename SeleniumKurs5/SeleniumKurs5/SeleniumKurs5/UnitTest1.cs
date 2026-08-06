using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumKurs5
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
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/nested_frames");
            IWebElement topFrame = _driver.FindElement(By.Name("frame-top"));
            _driver.SwitchTo().Frame(topFrame);
            IWebElement minorRightFrame = _driver.FindElement(By.Name("frame-right"));
            _driver.SwitchTo().Frame(minorRightFrame);

            IWebElement textElement = _driver.FindElement(By.TagName("body"));
            Assert.That(textElement.Text, Is.EqualTo("RIGHT"));

            _driver.SwitchTo().DefaultContent();

            _driver.SwitchTo().Frame("frame-bottom");
            Assert.That(_driver.FindElement(By.TagName("body")).Text, Is.EqualTo("BOTTOM"), "Expected text for bottom frame not found");

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}
