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
    public class ApplicantController : Controller
    {
        private KursovikTP db = new KursovikTP();

        //
        // GET: /Applicant/
        public ActionResult ListResume()
        {
            var resume = db.Resume.Include(r => r.Applicant);
            return View(resume.ToList());
        }

        [HttpPost]
        public ViewResult ListResume(string search)
        {
            var resume = db.Resume.Include(r => r.Applicant);
            if (!String.IsNullOrEmpty(search))
            {
                resume = resume.Where(a => a.Position.Contains(search));
            }
            return View(resume.ToList());
        }

        //
        // GET: /Applicant/Details/5
        public ActionResult Details(int id = 0)
        {
            Resume resume = db.Resume.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        //
        // GET: /Applicant/Create
        [Authorize(Roles="Applicant")]
        public ActionResult CreateResume()
        {
            return View();
        }

        //
        // POST: /Applicant/Create
        [HttpPost]
        [Authorize(Roles = "Applicant")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateResume(Resume resume, string Login)
        {
            DateTime dt = DateTime.Now;
            resume.TimeCreation = dt;
            var idApplicant = SearchId(Login);
            resume.idApplicant = idApplicant;
            if (ModelState.IsValid)
            {
                db.Resume.Add(resume);
                db.SaveChanges();
                return RedirectToAction("Home", "Home");
            }
            return View(resume);
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