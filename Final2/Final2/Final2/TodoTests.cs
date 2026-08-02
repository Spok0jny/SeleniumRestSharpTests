using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Final2
{
    internal class TodoTests : BaseTest
    {
        private TodosEndpoint api = null!;
        private List<int> IdsToDelete = new();

        [OneTimeSetUp]
        public void Setup()
        {
            api = new TodosEndpoint(client);
        }

        [Test]
        public void PostAndGet()
        {
            var NewPost = new TodoRequest
            {
                UserId = 1,
                Title = "Restsharp project",
                Completed = false
            };

            var createResponse = api.CreateTodo(NewPost);
            Assert.That(createResponse.Data, Is.Not.Null, "There is no data for createResponse");
            var CreatedPostId = createResponse.Data.Id;
            IdsToDelete.Add(CreatedPostId);

            var getResponse = api.GetTodo(CreatedPostId);
            Assert.That(getResponse.Data, Is.Not.Null, "There is no data for getResponse");

            Assert.Multiple(() =>
            {
                Assert.That(getResponse.Data.Id, Is.EqualTo(CreatedPostId), "The Id of the created post does not match the Id of the retrieved post");
                Assert.That(getResponse.Data.UserId, Is.EqualTo(NewPost.UserId), "The UserId of the created post does not match the UserId of the retrieved post");
                Assert.That(getResponse.Data.Title, Is.EqualTo(NewPost.Title), "The Title of the created post does not match the Title of the retrieved post");
                Assert.That(getResponse.Data.Completed, Is.EqualTo(NewPost.Completed), "The Completed status of the created post does not match the Completed status of the retrieved post");
            });


            var PatchedNewPost = new TodoRequest
            {
                Title = "Restsharp project - completed",
                Completed = true
            };

            api.PatchTodo(CreatedPostId, PatchedNewPost);
            var getResponseAfterPatch = api.GetTodo(CreatedPostId);
            Assert.That(getResponseAfterPatch.Data, Is.Not.Null);

            //Assert.Multiple grupuje asserty, aby wszystkie błędy były wyświetlane w jednym raporcie, zamiast przerywać test po pierwszym niepowodzeniu.
            Assert.Multiple(() =>
            {    
                Assert.That(getResponseAfterPatch.Data, Is.Not.Null, "There is no data for getResponseAfterPatch");
                Assert.That(getResponseAfterPatch.Data.Title, Is.EqualTo(PatchedNewPost.Title), "The Title of the patched post does not match the Title of the retrieved post after patch");
                Assert.That(getResponseAfterPatch.Data.Completed, Is.EqualTo(true), "The Completed status is not true");
            });
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            foreach (var id in IdsToDelete)
            {
                var DeleteResposne = api.DeleteTodo(id);
                Assert.That(DeleteResposne.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                TestContext.Out.WriteLine($"Deleted Todo with Id: {id}");
            }
        }

    }
}