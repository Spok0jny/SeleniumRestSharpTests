using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ChallengingDOM
{
    public class Tests
    {
        IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/challenging_dom");
            IWebElement redButton = driver.FindElement(By.XPath("//a[contains(@class,'button alert')]"));
            redButton.Click();
        }
        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/challenging_dom");
            IWebElement Iuvaret7DeleteBtn = driver.FindElement(By.XPath("//tr[contains(.,'Iuvaret7')]/a[contains(.,'delete')]"));
            Iuvaret7DeleteBtn.Click();
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
