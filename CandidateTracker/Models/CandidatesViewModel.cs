﻿using Candidates.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CandidateTracker.Models
{
    public class CandidatesViewModel
    {
        public IEnumerable<Candidate> Candidates { get; set; }
    }
}