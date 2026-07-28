using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    public class Tests
    {
        IWebDriver driver;

        //setup to metoda ktora wykonuje sie przed kazdym testem, mozna w niej zainicjalizowac zmienne, obiekty itp.
        [SetUp]
        public void Setup()
        {
           

            driver = new ChromeDriver(); //deklaracja i inicjalizacja obiektu ChromeDriver, ktory pozwala na automatyzacje przegladarki Chrome
            driver.Manage().Window.Position = new System.Drawing.Point(0, 0); //ustawienie pozycji okna przegladarki na lewy gorny rog ekranu
            driver.Manage().Window.Size = new System.Drawing.Size(1920,1080); //ustawienie rozmiaru okna przegladarki na 1920x1080

            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5); //ustawienie czasu oczekiwania na elementy w DOM, w tym przypadku 5 sekund
            driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(5); //ustawienie czasu oczekiwania na zaladowanie strony, w tym przypadku 5 sekund)

        }

        //kazda metoda oznaczona jako [Test] jest traktowana jako osobny test, mozna w niej sprawdzac rozne scenariusze, uzywac asercji itp.
        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
     
            string searchEntry = "Checkboxes"; //wartosc, ktora zostanie wpisana w pole wyszukiwania
   

            string title = "Checkboxes"; //wartosc, ktora powinna byc wyswietlana w tytule strony po wyszukaniu
            driver.FindElement(By.XPath($".//*[text()='{title}']")).Click(); //znalezienie elementu na stronie za pomoca selektora XPath, w tym przypadku elementu <title>

            string entryURL = "https://the-internet.herokuapp.com/checkboxes"; //wartosc, ktora powinna byc wyswietlana w adresie URL po wyszukaniu
            Assert.That(entryURL, Is.EqualTo(driver.Url), "Nie znaleziono URL"); //sprawdzenie, czy aktualny adres URL jest rowny oczekiwanemu adresowi URL
          
        }

        //[TearDown] to metoda ktora wykonuje sie po kazdym tescie, mozna w niej zwalniac zasoby, zamykac polaczenia itp.
        [TearDown]
        public void TearDown()
        {
            driver.Quit(); //zamkniecie przegladarki i zwolnienie zasobow, ktore byly uzywane przez obiekt driver
            driver.Dispose(); //zwolnienie zasobow uzywanych przez obiekt driver, np. pamieci, uchwytow do plikow itp.

        }

    }
}
