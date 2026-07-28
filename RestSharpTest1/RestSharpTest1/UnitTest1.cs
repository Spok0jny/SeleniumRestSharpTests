using System.Net;
using RestSharp;


namespace RestSharpTest1;

public class Tests
{

    [Test]
    public void TestPobraniaPosta()
    {
        
        var client = new RestClient("https://jsonplaceholder.typicode.com");
        var request = new RestRequest("/posts/1", Method.Get);
        var response = client.Execute<Post>(request);
        // Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),"Status code nie jest 200");
        // Assert.That(response.Content, Does.Contain("\"id\": 1"), "Post o id 1 nie przyszedl");
        Assert.That(response.Data.Id, Is.EqualTo(1), "Id się nie zgadza");
        TestContext.WriteLine("Tytuł posta to:" + response.Data.Title);
        TestContext.Progress.WriteLine(response.Content);
        
    }
}