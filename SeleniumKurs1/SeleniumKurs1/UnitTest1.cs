using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumKurs1;

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
    public void EnterGitHub()
    {
        _driver.Navigate().GoToUrl("https://github.com");
        Assert.That(_driver.Title, Does.Contain("GitHub"));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
        
        
    }
}