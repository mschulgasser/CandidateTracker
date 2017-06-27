using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidates.Data
{
    public class CandidatesRepository
    {
        private string _connectionString;
        public CandidatesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddCandidate(Candidate c)
        {
            using(var context = new CandidateTrackerDBDataContext(_connectionString))
            {
                c.Status = (int)CandidateStatus.Pending;
                context.Candidates.InsertOnSubmit(c);
                context.SubmitChanges();
            }
        }
        public IEnumerable<Candidate> GetCandidates(CandidateStatus status)
        {
            using (var context = new CandidateTrackerDBDataContext(_connectionString))
            {
                return context.Candidates.Where(c => c.Status == (int)status).ToList();
            }
        }
        public Candidate GetCandidate(int id)
        {
            using (var context = new CandidateTrackerDBDataContext(_connectionString))
            {
                return context.Candidates.FirstOrDefault(c => c.Id == id);
            }
        }
        public void ChangeStatus(int candidateId, CandidateStatus status)
        {
            using (var context = new CandidateTrackerDBDataContext(_connectionString))
            {
                context.ExecuteCommand("UPDATE Candidates SET Status = {0} WHERE Id = {1}", status, candidateId);
            }
        }
        public int GetCount(CandidateStatus status)
        {
            using (var context = new CandidateTrackerDBDataContext(_connectionString))
            {
                int result = context.Candidates.Where(c => c.Status == (int)status).Count();
                return result;
            }
        }
    }
}
