using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Candidates.Data;

namespace CandidateTracker
{
    public class LayoutDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
                var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
                filterContext.Controller.ViewBag.Pending = repo.GetCount(CandidateStatus.Pending);
                filterContext.Controller.ViewBag.Accepted = repo.GetCount(CandidateStatus.Accepted);
                filterContext.Controller.ViewBag.Rejected = repo.GetCount(CandidateStatus.Rejected);
                base.OnActionExecuting(filterContext);
        }
    }
}