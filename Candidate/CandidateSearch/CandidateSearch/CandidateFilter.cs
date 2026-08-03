using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateSearch
{
    //Filtr do wyszukiwania kandydatów przez API
    internal class CandidateFilter
    {
        public List<string> RequiredSkills { get; set; } = null!;
        public int MinExperienceYears { get; set; }
        public int MaxSalary { get; set; }
        public bool WillingToRelocate { get; set; }

    }
}
