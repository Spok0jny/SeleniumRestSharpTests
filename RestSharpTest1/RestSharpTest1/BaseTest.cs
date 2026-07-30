using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpTest1
{
    public class BaseTest
    {
        protected RestClient client = null!; // Use null-forgiving operator to indicate that the client will be initialized in the Setup method
        [OneTimeSetUp]
        public void Setup()
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
            client?.Dispose(); // Dispose of the client if it has been initialized, if no just ignore it
        }

    }
}
