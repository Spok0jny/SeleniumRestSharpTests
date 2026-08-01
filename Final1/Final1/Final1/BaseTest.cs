using RestSharp;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text;

namespace Final1
{
    //BaseTest jest klasą bazową dla testów, która konfiguruje klienta RestSharp do komunikacji z API.
    internal class BaseTest
    {
        protected RestClient client = null!; // Klient RestSharp do komunikacji z API, zapis null! oznacza, że zmienna zostanie zainicjalizowana później, w metodzie Setup. (Żeby nie było ostrzeżenia o niezainicjalizowanej zmiennej)
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new RestClientOptions("https://jsonplaceholder.typicode.com")
            {
                Timeout = TimeSpan.FromMilliseconds(5000)
            };
            client = new RestClient(options); // Inicjalizacja klienta RestSharp z określonymi opcjami, w tym bazowym adresem URL i limitem czasu.
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            client?.Dispose(); // Zwalnianie zasobów klienta RestSharp po zakończeniu testów, jeśli klient został zainicjalizowany. ? oznacza sprawdzenie, czy klient nie jest null przed wywołaniem metody Dispose, jeśli jest to nic nie zrobi (w sensie ten Dispose)
        }

    }
}
