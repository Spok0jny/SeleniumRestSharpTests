using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final2
{
    internal class BaseTest
    {
        protected RestClient client = null!;

        

        [OneTimeSetUp]
        public void SetUp()
        {
            var options = new RestClientOptions("https://jsonplaceholder.typicode.com")
            { 
                Timeout = TimeSpan.FromMilliseconds(5000)
            };

            client = new RestClient(options);
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            client?.Dispose();
        }
    }
}
