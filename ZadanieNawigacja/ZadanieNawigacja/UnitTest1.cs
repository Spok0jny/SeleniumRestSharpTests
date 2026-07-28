using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ZadanieNawigacja
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.Manage().Window.Position = new System.Drawing.Point(0, 0);


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5); 
        }

        [Test]
        public void TestNawigacji()
        {
            string stronaGlowna = "https://the-internet.herokuapp.com/";
            driver.Navigate().GoToUrl(stronaGlowna);

            IWebElement checkBoxyNazwa = driver.FindElement(By.LinkText("Checkboxes"));
            checkBoxyNazwa.Click();

            Assert.That(driver.Url, Does.Contain("/checkboxes"));

            driver.Navigate().Back();

            Assert.That(driver.Title, Is.EqualTo("The Internet"));
    

            driver.Navigate().Refresh();
            driver.Navigate().Forward();

        }

        [TearDown] 
        public void TearDown() { 
            driver.Quit();
        }
    }
}
