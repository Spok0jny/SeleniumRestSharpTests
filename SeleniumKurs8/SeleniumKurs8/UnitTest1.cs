using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumKurs8
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
            //Hover
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/hovers");
            IWebElement FirstImage = _driver.FindElement(By.XPath("(//div[@class='figure'])[1]")); //nawiasy pozwalaja nam zebrac wszystkie obrazki w kolekcje i z nich wyciagac po kolejnosci (liczonej od 1)
            Actions action = new Actions(_driver);
            action.MoveToElement(FirstImage).Perform();
            Thread.Sleep(500);

            IWebElement captionText = _driver.FindElement(By.XPath("(//div[@class='figcaption']/h5)[1]"));
            Assert.That(captionText.Text, Does.Contain("name: user1"));


            //Drag & Drop
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/drag_and_drop");
            IWebElement boxA = _driver.FindElement(By.Id("column-a"));
            IWebElement boxB = _driver.FindElement(By.Id("column-b"));

            string initialTextA = boxA.Text;
            string initialTextB = boxB.Text;


            action.DragAndDrop(boxA, boxB).Perform();
            Assert.That(initialTextA,Is.EqualTo(boxB.Text), "Boxes didn't change places");
            Assert.That(initialTextB,Is.EqualTo(boxA.Text), "Boxes didn't change places");
            TestContext.Progress.WriteLine("Boxes exchanged values");

        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Dispose();
        }
    }
}
