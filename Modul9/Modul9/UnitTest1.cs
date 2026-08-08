using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Xsl;

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

            foreach (string window in _driver.WindowHandles)
            {
                if (window != originalWindow)
                {
                    _driver.SwitchTo().Window(window);
                    break;
                }
            }

            Assert.That(_driver.FindElement(By.TagName("h3")).Text, Is.Not.Null);

            //_driver.FindElement(By.Id("iammakingerrorhere")); module 11 screenshots

        }


        //module11 screenshots
        public void TakeScreenshot(string name)
        {
            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();

            
            string filePath = $@"C:\Tests\Error_{name}.png";

            ss.SaveAsFile(filePath);
            TestContext.Progress.WriteLine($"Screenshot zapisany w: {filePath}");
        }

        [TearDown]
        public void CleanUp()
        {
            //module11 screenshiots
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string testName = TestContext.CurrentContext.Test.Name;
                TakeScreenshot(testName);
            }

            _driver.Dispose();
        }
    }
}
