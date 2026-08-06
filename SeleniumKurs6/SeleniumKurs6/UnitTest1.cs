using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumKurs6
{
    //Because we have LoginPage.cs class, we can use it in our tests, so we don't have to write the same code again and again, we can just use the methods from LoginPage.cs class
    //Combining it with BaseTest.cs we can only have an acutal Test in a test class
    internal class Tests : BaseTest
    {
        
    
        [Test]
        public void Test1()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            LoginPage loginPage = new LoginPage(_driver); 
            loginPage.EnterLogin("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLoginButton();

            Assert.That(_driver.Url, Does.Contain("/secure"));
        }

      
    }
}
