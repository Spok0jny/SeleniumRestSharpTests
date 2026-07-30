using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RestSharpTest1
{
    public class E2ECycle : BaseTest
    {
        [Test]
        public void EndToEndCycle()
        {

            //Post
        
            var request = new RestRequest("/posts", Method.Post);

            var NewPost = new PostRequest
            {
                Title = "Megatitle",
                Body = "Megabody",
                UserId = 12
            };
            request.AddJsonBody(NewPost);
            var response = client.Execute<PostRequest>(request);
            Assert.That(response.Data, Is.Not.Null);
            var createdPostId = response.Data.Id;

            //PUT
            var requestPut = new RestRequest($"/posts/{createdPostId}", Method.Put);
            var updatedPost = new PostRequest
            {
                Title = "Updated Title",
                Body = "Updated Body",
                UserId = 12
            };
            requestPut.AddJsonBody(updatedPost);
            var responsePut = client.Execute<PostRequest>(requestPut);
            Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            //GET
            var requestGet = new RestRequest($"/posts/{createdPostId}", Method.Get);
            var responseGet = client.Execute<PostRequest>(requestGet);
            Assert.That(responseGet.Data, Is.Not.Null);
            Assert.That(responseGet.Data.Title, Is.EqualTo("Updated Title"),"Title is not equal to \"Updated Title\"");

            //DELETE
            var requestDelete = new RestRequest($"/posts/{createdPostId}", Method.Delete); 
            requestDelete.AddQueryParameter("force", "true");

            var responseDelete = client.Execute(requestDelete);
            Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.OK));


            //GET after DELETE
         
            var responseGetAfterDelete = client.Execute<PostRequest>(requestGet);
            Assert.That(responseGetAfterDelete.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Status code is not equal to 404 Not Found");

        }
    }
}
