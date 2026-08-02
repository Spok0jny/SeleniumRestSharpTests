using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final2
{
    internal class TodosEndpoint
    {
        private RestClient client = null!;
        public TodosEndpoint(RestClient client)
        {
            this.client = client;
        }

        public RestResponse<TodoRequest> GetTodo(int id)
        {
            var request = new RestRequest($"todos/{id}", Method.Get);
            return client.Execute<TodoRequest>(request);
        }

        public RestResponse<TodoRequest> CreateTodo(TodoRequest payload)
        {
            var request = new RestRequest("todos", Method.Post);
            request.AddJsonBody(payload);
            return client.Execute<TodoRequest>(request);
        }

       public RestResponse<TodoRequest> PatchTodo(int id, TodoRequest payload)
        {
            var request = new RestRequest($"todos/{id}", Method.Patch);
            request.AddJsonBody(payload);
            return client.Execute<TodoRequest>(request);
        }
        
        public RestResponse DeleteTodo(int id)
        {
            var request = new RestRequest($"todos/{id}", Method.Delete);
            return client.Execute(request);
        }

       



    }
}
