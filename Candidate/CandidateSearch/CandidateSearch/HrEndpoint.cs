using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateSearch
{
    internal class HrEndpoint
    {
        //Klasa zawierajaca metody do komunikacji z API HR, wykorzystująca klienta RestSharpa
        private RestClient client = null!;

        public HrEndpoint(RestClient client)
        {
            this.client = client;
        }

        public RestResponse<Candidate> CreateCandidate(Candidate payload)
        {
            var request = new RestRequest("/candidates", Method.Post);
            request.AddJsonBody(payload);
            return client.Execute<Candidate>(request);
        }

        public RestResponse<Candidate> UpdateCandidateFull(int id, Candidate payload)
        {
            var request = new RestRequest($"/candidates/{id}", Method.Put);
            request.AddJsonBody(payload);
            return client.Execute<Candidate>(request);
        }

        //Tu parametrem nie jest obiekt Candidate, tylko string z nowym statusem
        public RestResponse<Candidate> UpdateCandidateStatus(int id, string newStatus)
        {
            var request = new RestRequest($"/candidates/{id}", Method.Patch);
            var patchBody = new { Status = newStatus }; // Tworzymy anonimowy obiekt z nowym statusem, który zostanie wysłany w ciele żądania PATCH. Dzieki temu pozostale pola sa pomijane i podmienianyj est tylko status. Mozna tez zrobic new Candidate { Status = newStatus } ale to jest mniej eleganckie i wymaga zainicjalizowania pozostalych pol bo w innym wypadku beda nullami a my chcemy tylko zedytowac jedno pole
            request.AddJsonBody(patchBody);
            return client.Execute<Candidate>(request);

        }

        //Wyszukiwania
        public RestResponse<List<Candidate>> SearchSimple(string role, string status)
        {
            var request = new RestRequest("/candidates", Method.Get);
            request.AddQueryParameter("rola", role);
            request.AddQueryParameter("status", status);
            return client.Execute<List<Candidate>>(request);
        }

        public RestResponse<List<Candidate>> SearchAdvanced(CandidateFilter filter)
        {
            var request = new RestRequest("/candidates/search", Method.Post);
            request.AddJsonBody(filter);
            return client.Execute<List<Candidate>>(request);
        }



    }
}
