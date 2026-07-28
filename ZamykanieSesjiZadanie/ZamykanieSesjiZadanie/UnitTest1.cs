using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ZamykanieSesjiZadanie
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
        public void Sprzątacz()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
            driver.FindElement(By.LinkText("Click Here")).Click();

            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);

        }

        [TearDown] 
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
