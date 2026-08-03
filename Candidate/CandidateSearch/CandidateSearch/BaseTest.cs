using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateSearch
{
    //Klasa bazowa dla testów, zawierająca konfigurację klienta RestSharpa
    internal class BaseTest
    {
        protected RestClient client = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new RestClientOptions("http://localhost:5000") //im just testing code it's not actually running on localhost, but you can change it to your actual API URL cheers
            {
                ThrowOnAnyError = true,
                Timeout = TimeSpan.FromMilliseconds(5000)
            };
            client = new RestClient(options);
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            client?.Dispose();
            
        }

    }
}
