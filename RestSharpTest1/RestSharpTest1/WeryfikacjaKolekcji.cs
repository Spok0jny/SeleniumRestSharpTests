using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace RestSharpTest1
{
    public class WeryfikacjaKolekcji : BaseTest
    {
        //Krok Create
        [Test]
        public void CollectionVerification()
        {
            var request = new RestRequest("/posts", Method.Post);

            var NewPost = new PostRequest //Tworzymy nowy obiekt z danymi do nowego posta
            {
                Title = "Megatitle",
                Body = "Megabody",
                UserId = 11
            };

            request.AddJsonBody(NewPost); //zmieniamy obiekt na JSON i dodajemy do requestu
            var response = client.Execute<PostRequest>(request); // Wysyłamy request i odbieramy response, który jest pakowany do obiektu PostRequest
            Assert.That(response.StatusCode,Is.EqualTo(HttpStatusCode.Created), "Status code is not 201 Created (the post was not created)");

            var createdId = response.Data.Id;

            //Krok Read (Single)

            // getResponse to "paczka" od serwera (klasa RestResponse). Zawiera status HTTP, nagłówki I nasze dane w polu .Data
            var getRequest = new RestRequest($"/posts/{createdId}", Method.Get);
            var getResponse = client.Execute<PostRequest>(getRequest);

            // Musimy użyć .Data, bo sięgamy do środka "paczki" po konkretny obiekt
            Assert.That(getResponse.Data.UserId,Is.EqualTo(response.Data.UserId), "User ID does not match");
            Assert.That(getResponse.Data.Title, Is.EqualTo(response.Data.Title), "Title does not match");
            Assert.That(getResponse.Data.Body, Is.EqualTo(response.Data.Body), "Body does not match");


            //Krok Read (List)
            var getAllRequest = new RestRequest("/posts",Method.Get);
            var getAllResponse = client.Execute<List<PostRequest>>(getAllRequest); // Tak jak wyzej, odbieramy response i pakujemy do listy obiektów PostRequest 

            Assert.That(getAllResponse.Data, Is.Not.Null, "Response data is null");
            // FirstOrDefault "wyciąga" z listy jeden czysty obiekt. To nie jest już "paczka" z serwera, tylko surowy obiekt typu PostRequest
            var createdPostInList = getAllResponse.Data.FirstOrDefault(x => x.Id == createdId); // Szukamy w liście posta o tym samym ID co stworzony post
            // Lambda (funkcja strzalkowa) czyli dziala to tak, ze element x jest tymczasowy wymyslony przez nas bo lambda przelatuje po calej kolekcji i sprawdza czy x.Id jest rowne createdId, jesli tak to zwraca ten element, jesli nie to zwraca null
            Assert.That(createdPostInList, Is.Not.Null, "Created post not found in the list"); // Jesli nie zostal stwrozony to FirstOrDefault zwroci null, wiec sprawdzamy czy nie jest null
             // Tu NIE piszemy .Data, bo createdPostInList to już jest "goły" obiekt klasy PostRequest, 
             // a nie odpowiedź od serwera (RestResponse). Dostał "rozpakowane" dane prosto z listy.
            Assert.That(createdPostInList.Title, Is.EqualTo(NewPost.Title), "Title does not match in the list");
            
            

        }
    }
}
