using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using NUnit.Framework;

namespace Final1
{
    //nie dziedziczymy bo BaseTest bo to juzj est zawarte w PostsEndpoint
    internal class ZaawansowaneZadanie : BaseTest
    {
        private PostsEndpoint api = null!;
       
       

        //tworzymy listę do przechowywania id postów do usunięcia
        private List<int> idsToDelete = new List<int>();
        [OneTimeSetUp]
        public void InitApi()
        {
            // Tutaj pudełko zostaje wypełnione obiektem z przekazanym klientem sieciowym
            api = new PostsEndpoint(client);
        }


        [Test]
        public void CrudTest()
        {
            //Tworzymy nowy post
            var nowyPost = new PostRequest
            {
                Title = "Nowy post",
                Body = "To jest treść nowego posta",
                UserId = 1
            };
            var response = api.CreatePost(nowyPost);
            Assert.That(response.Data, Is.Not.Null);
            int newPostId = response.Data.Id;
            idsToDelete.Add(newPostId);


            // Aktualizujemy ten post
            var updatedPost = new PostRequest
            {
                Title = "Zaktualizowany post",
                Body = "To jest zaktualizowana treść posta",
                UserId = 1
            };
            api.UpdatePost(newPostId, updatedPost);
            // Weryfikacja
            var getResponse = api.GetPost(newPostId);
            Assert.That(getResponse.Data, Is.Not.Null);
            Assert.That(getResponse.Data.Title, Is.EqualTo("Zaktualizowany post"));


        }

        [OneTimeTearDown]
        public void Clean()
        {
            //foreach do przejechania i usunięcia wszystkich postów, które zostały dodane w teście, dla każdego sprawdzamy czy odpowiedź z API jest 200 i wypisujemy informację o usunięciu posta

            foreach (var id in idsToDelete)
            {
                var deleteResponse = api.DeletePost(id);
                Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                TestContext.Out.WriteLine($"Usunięto post o id: {id}");
            }

           
        }
    }
}
