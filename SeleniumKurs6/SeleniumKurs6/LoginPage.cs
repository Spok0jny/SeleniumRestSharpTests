using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumKurs6
{
    //Class that represents the login page, it contains locators and methods to interact with the page
    internal class LoginPage
    {
        private IWebDriver _driver; //We need to have a reference to the driver, so we can use it to find elements and interact with the page

        public LoginPage(IWebDriver driver) //Constructor that takes the driver as a parameter, so we can use it to find elements and interact with the page
        {
            _driver = driver; //We assign the driver to the private field, so we can use it in the methods of this class
        } 

        //Locators using => because we want to find the element only when we need it, not when the page object is created
        // = tries to find the element when the page object is created, which can cause issues if the element is not yet created (like in LoginPage constructor), => works only after we call the method that uses the locator, so it will find the element when we need it, not when the page object is created (such as EnterLogin, EnterPassword, ClickLoginButton etc.) 
        private IWebElement UsernameField => _driver.FindElement(By.Id("username")); 
        private IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

        //Metody
        public void EnterLogin(string username)
        {
            UsernameField.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public void ClickLoginButton() 
        {
            LoginButton.Click();
        }



    }
}
