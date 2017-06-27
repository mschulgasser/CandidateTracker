using Candidates.Data;
using CandidateTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCandidate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCandidate(Candidate c)
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            repo.AddCandidate(c);
            return Redirect("/");
        }
        public ActionResult Pending()
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            var vm = new CandidatesViewModel();
            vm.Candidates = repo.GetCandidates(CandidateStatus.Pending);
            return View(vm);
        }
        public ActionResult Accepted()
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            var vm = new CandidatesViewModel();
            vm.Candidates = repo.GetCandidates(CandidateStatus.Accepted);
            return View(vm);
        }
        public ActionResult Rejected()
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            var vm = new CandidatesViewModel();
            vm.Candidates = repo.GetCandidates(CandidateStatus.Rejected);
            return View(vm);
        }
        public ActionResult Details(int id)
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            var vm = new DetailsViewModel();
            vm.Candidate = repo.GetCandidate(id);
            return View(vm);
        }
        public ActionResult UpdateStatus(int id, CandidateStatus status)
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            repo.ChangeStatus(id, status);
            return Json(new {pending = repo.GetCount(CandidateStatus.Pending),
                accepted = repo.GetCount(CandidateStatus.Accepted),
                rejected = repo.GetCount(CandidateStatus.Rejected)});
        }
    }
}