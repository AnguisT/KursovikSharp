using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemberShip.Models;

namespace MemberShip.Controllers
{
    public class EmployerController : Controller
    {
        private KursovikTP db = new KursovikTP();

        //
        // GET: /Jobs/
        public ActionResult ListJobs()
        {
            var jobs = db.Jobs.Include(r => r.Employer);
            return View(jobs.ToList());
        }

        [HttpPost]
        public ViewResult ListJobs(string search)
        {
            var jobs = db.Jobs.Include(r => r.Employer);
            if (!String.IsNullOrEmpty(search))
            {
                jobs = jobs.Where(a => a.NameJobs.Contains(search));
            }
            return View(jobs.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Jobs jobs = db.Jobs.Find(id);
            if (jobs == null)
            {
                return HttpNotFound();
            }
            return View(jobs);
        }

        [Authorize(Roles="Employer")]
        public ActionResult CreateJobs()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJobs(Jobs jobs, string Login)
        {
            DateTime dt = DateTime.Now;
            jobs.TimeCreation = dt;
            var idEmployer = SearchId(Login);
            jobs.idEmployer = idEmployer;
            if (ModelState.IsValid)
            {
                db.Jobs.Add(jobs);
                db.SaveChanges();
                return RedirectToAction("Home", "Home");
            }
            return View(jobs);
        }

        public int SearchId(string login)
        {
            var people = (from p in db.People
                          where p.Login == login
                          select p).FirstOrDefault();
            return people.idPeople;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
