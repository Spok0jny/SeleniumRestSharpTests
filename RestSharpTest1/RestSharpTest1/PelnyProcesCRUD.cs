using System.Net;
using RestSharp;

namespace RestSharpTest1;

public class PelnyProcesCRUD : BaseTest
{
    [Test]
    public void TestCRUD()
    {
        var request = new RestRequest("/posts", Method.Post); //request czyli nasz endpoint i jaka metoda walimy

        var NowyPost = new PostRequest //pakujemy dane w klase 
        {
            Title = "Megatytul",
            Body = "Megabody",
            UserId = 10
        };
        
        request.AddJsonBody(NowyPost); //zmieniamy to na jsona bo tylko jsona mozemy wyslac executem
        
        var response = client.Execute<PostRequest>(request); //robimy zmienna response ktora przechowuje pdpowiedz po execucie requesta do tego dorzucamy PostRequest po execucie zeby zapakowac te odpowiedz do konkretnej klasy 
        
        Assert.That(response.StatusCode,Is.EqualTo(HttpStatusCode.Created)); //sprawdzamy czy sie utworzylo
        
        var newId = response.Data.Id; //zapisujemy id utworzonego posta 
        var requestGet = new RestRequest($"/posts/{newId}", Method.Get); //wyciagamy getem ten post i potem dla niego robimy execute
        var responseGet = client.Execute<PostRequest>(requestGet);
        Assert.That(responseGet.Data.Title,Is.EqualTo(response.Data.Title)); //3 asercje sprawdzajace czy get wyciagnal to samo co wsadzilismy postem
        Assert.That(responseGet.Data.UserId,Is.EqualTo(response.Data.UserId));
        Assert.That(responseGet.Data.Body,Is.EqualTo(response.Data.Body));

    }
}