using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ZadanieCheckboxySeams
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
        public void VerifyCheckboxIsChecked()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
            IWebElement drugiCheckBox = driver.FindElement(By.XPath("//input[@type='checkbox'][2]"));
            bool isChecked = drugiCheckBox.Selected;
            Assert.That(isChecked, Is.True, "Drugi checkbox nie jest zaznaczony.");

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
