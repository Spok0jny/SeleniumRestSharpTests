using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumKurs2;

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
        _driver.Navigate().GoToUrl("https://github.com/login");
        _driver.FindElement(By.Id("login_field")).SendKeys("testingseleniumwebdriver");
        _driver.FindElement(By.Id("password")).SendKeys("secret1234");
        // _driver.FindElement(By.CssSelector("input[value='Sign in']")).Click();

        _driver.FindElement(By.XPath("//input[@value='Sign in']"));

    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}