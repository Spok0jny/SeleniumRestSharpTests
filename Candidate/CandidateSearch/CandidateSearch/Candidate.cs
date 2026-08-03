using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateSearch

{
    //Klasa reprezentująca kandydata
    internal class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
