using System.Net;
using RestSharp;

namespace RestSharpTest1;

public class TestTworzeniaPosta : BaseTest
{
    [Test]
    public void TestTworzenia()
    {
        var request = new RestRequest("/posts",Method.Post); //request czyli dokladnie to co wysylamy oraz jaka metoda

        var nowyPost = new PostRequest //uzywamy post wiec chcemy cos dodac wiec musimy miec co dodac, w tym celu robimy nowy postrequest (z naszej klasy)
        {
            Title = "TestowyTytul",
            Body = "TestowanieAPI",
            UserId = 1
        };
        
        request.AddJsonBody(nowyPost); //musimy ulepic z tego jsona zeby moc go wyslac 
        var response = client.Execute<PostRequest>(request); //robimy odpowiedz do ktorej zlapiemy to co wypluje nam execute tego <postrequest> mowi ze wykonaj strzal i zapakuj w strukture tej klasy 
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        TestContext.Progress.WriteLine($"ID Nowego posta to {response.Data.Id}"); //wyciagamy id posta jak sie uda 
    }
}