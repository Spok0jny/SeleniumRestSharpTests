using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final1
{
    //zadaniem tej klasy jest obsługa endpointu /posts w API. Zawiera metody do wykonywania operacji CRUD (Create, Read, Update, Delete) na postach.
    internal class PostsEndpoint
    {
        private RestClient client = null!; // Klient RestSharp do komunikacji z API, zapis null! oznacza, że zmienna zostanie zainicjalizowana w konstruktorze. Nie jest on dziedziczony z Basetest bo to jest klasa endpointu, a nie testu. Klient jest przekazywany z klasy testowej do tej klasy endpointu.

        public PostsEndpoint(RestClient client)  //konstruktor klasy PostsEndpoint, który przyjmuje obiekt RestClient jako parametr. Ten klient jest używany do wykonywania żądań HTTP do API.
        {
            this.client = client;
        }
        //Get - zwracamy RestResponse<PostRequest> bo chcemy dostać odpowiedź z serwera w formacie PostRequest
        public RestResponse<PostRequest> GetPost(int postId)
        {
            var request = new RestRequest($"/posts/{postId}", Method.Get);
            var response = client.Execute<PostRequest>(request);
            return response;
        }

        //Post - wysylamy go i zwracamy RestResponse
        public RestResponse<PostRequest> CreatePost(PostRequest newPost)
        {
            var request = new RestRequest("/posts", Method.Post);
            request.AddJsonBody(newPost);
            return client.Execute<PostRequest>(request);
        }
        //Put
        public RestResponse<PostRequest> UpdatePost(int postId, PostRequest payload)
        {
            var request = new RestRequest($"/posts/{postId}", Method.Put);
            request.AddJsonBody(payload);
            return client.Execute<PostRequest>(request);
        }
        //Delete bez <PostRequest> bo delete nie zwraca nic w odpowiedzi
        public RestResponse DeletePost(int postId)
        {
            var request = new RestRequest($"/posts/{postId}", Method.Delete);
            return client.Execute(request);
        }
    }
}
