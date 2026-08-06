using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumKurs6
{
    //BaseTest includes _driver, SetUp and TearDown to use in every test
    internal class BaseTest
    {
        protected IWebDriver _driver;
        protected string BaseUrl = "https://the-internet.herokuapp.com/login";

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }



        [TearDown]
        public void Teardown()
        {
            if(_driver != null)
            {
                _driver.Dispose();
            }

        }
    }
}
