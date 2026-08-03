using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using RestSharp;

namespace CandidateSearch
{
    internal class HrTests : BaseTest
    {
        private HrEndpoint hrEndpoint = null!;
        private List<int> idsToDelete = new();

        [OneTimeSetUp]
        public void InitEndpoint()
        {
            hrEndpoint = new HrEndpoint(client);
        }

        [Test]
        public void ShouldCreateCandidateLifecycle()
        {
            var newCandidate = new Candidate
            {
                Name = "Jan",
                Role = "Tester",
                Status = "New"
            };

            var createResponse = hrEndpoint.CreateCandidate(newCandidate);
            Assert.That(createResponse.Data, Is.Not.Null);
            Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            var createdCandidateId = createResponse.Data.Id;


            var updatedCandidate = new Candidate
            {
                Name = "Jan Kowalski",
                Role = "Senior Tester",
                Status = "goat"
            };

            var updateResponse = hrEndpoint.UpdateCandidateFull(createdCandidateId, updatedCandidate);
            Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var statusUpdateResponse = hrEndpoint.UpdateCandidateStatus(createdCandidateId, "Cozzi Cozack");
            Assert.That(statusUpdateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));


        }

        [Test]
        public void ShouldTestSearchingMethods()
        {
            var filter = new CandidateFilter
            {
                RequiredSkills = new() { "C#", "Selenium" },
                MinExperienceYears = 3,
                MaxSalary = 10000,
            };

            hrEndpoint.SearchSimple("Tester", "New");

            hrEndpoint.SearchAdvanced(filter);

        }

    }
}
