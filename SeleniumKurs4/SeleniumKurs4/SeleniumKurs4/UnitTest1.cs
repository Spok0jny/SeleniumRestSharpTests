using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SeleniumKurs4
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
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/1");
            _driver.FindElement(By.XPath("//div[@id='start']/button")).Click();

            // 1. Tworzymy obiekt WebDriverWait, który będzie pilnował naszego sterownika (_driver) 
            // i pozwalał mu czekać na zdarzenia maksymalnie do 10 sekund.
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            // 2. Używamy metody Until, która przyjmuje funkcję zwrotną (lambde d).
            // d to w tym przypadku po prostu skrót od "driver" (instancja IWebDriver przekazana w tle przez WebDriverWait).
            IWebElement finishDiv = wait.Until(d =>
            {
                // 3. Wewnątrz lambdy szukamy elementu na stronie dokładnie tak samo, jak na zwykłym driverze.
                IWebElement element = d.FindElement(By.Id("finish"));

                // 4. Stawiamy warunek (skroconym if'em):
                // Jeśli element jest widoczny (Displayed) ORAZ jego tekst nie jest pusty (!string.IsNullOrEmpty)...
                // ...to zwracamy ten element (przypisujemy go do zmiennej finishDiv).
                // W przeciwnym razie zwracamy null, co sygnalizuje metodzie Until, że ma próbować ponownie (aż minie 10 sekund).
                return (element.Displayed && !string.IsNullOrEmpty(element.Text)) ? element : null;


                // 1. Znajdujemy element
                //IWebElement element = d.FindElement(By.Id("finish"));

                // 2. Tworzymy sobie osobne zmienne z warunkami (tak jak chciałeś!)
                //bool isDisplayed = element.Displayed;
                //bool isNotEmpty = !string.IsNullOrEmpty(element.Text);
                //bool isCorrectText = (element.Text == "Hello World!");

                // 3. Sprawdzamy, czy wszystko pasuje i decydujemy, co zwrócić
                //if (isDisplayed && isNotEmpty && isCorrectText)
                //{
                //    return element; // Zwracamy element, bo test spełnił warunki!
                //}
                //else
                //{
                //    return null;    // Zwracamy null, więc WebDriverWait wie, że ma czekać dalej!
                //}

            });

            Assert.That(finishDiv.Text, Is.EqualTo("Hello World!"), "The text in the finish div is not as expected.");

        }


        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
            
        }
    }
}
