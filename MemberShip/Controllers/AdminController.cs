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
    public class AdminController : Controller
    {
        private KursovikTP db = new KursovikTP();

        //
        // GET: /Admin/
        [Authorize(Roles = "Admin")]
        public ActionResult ListPeople()
        {
            var people = db.People.Include(a => a.Role).Include(a => a.Employer).Include(a => a.Applicant);
            return View(people.ToList());
        }

        //
        // GET: /Admin/CreateApplicant
        [Authorize(Roles = "Admin")]
        public ActionResult CreateApplicant()
        {
            return View();
        }

        //
        // POST: /Admin/CreateApplicant
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateApplicant(Applicant applicant, string Login, string Password, string FirstName, string SecondName, string MiddleName)
        {
            AddPeople(Login, Password, FirstName, SecondName, MiddleName, "Applicant");
            var speople = (from p in db.People
                      where p.Login == Login
                      select p).SingleOrDefault();
            applicant.idApplicant = speople.idPeople;
            if (ModelState.IsValid)
            {
                db.Applicant.Add(applicant);
                db.SaveChanges();
                return RedirectToAction("ListPeople", "Admin");
            }
            return View(applicant);
        }

        //
        // GET: /Admin/CreateEmployer
        [Authorize(Roles = "Admin")]
        public ActionResult CreateEmployer()
        {
            return View();
        }

        //
        // POST: /Admin/CreateEmployer
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployer(Employer employer, string Login, string Password, string FirstName, string SecondName, string MiddleName)
        {
            AddPeople(Login, Password, FirstName, SecondName, MiddleName, "Employer");
            var speople = (from p in db.People
                           where p.Login == Login
                           select p).SingleOrDefault();
            employer.idEmployer = speople.idPeople;
            if (ModelState.IsValid)
            {
                db.Employer.Add(employer);
                db.SaveChanges();
                return RedirectToAction("ListPeople", "Admin");
            }
            return View(employer);
        }

        //
        // GET: /Admin/ExtendTime
        [Authorize(Roles = "Admin")]
        public ActionResult ExtendTime()
        {
            return View();
        }

        //
        // POST: /Admin/ExtendTime
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExtendTime(string Login, DateTime Time)
        {
            var user = (from u in db.People
                        where u.Login == Login
                        select u).SingleOrDefault();
            if (user.Applicant != null)
            {
                var role = (from r in db.Role
                            where r.NameRole == "Applicant"
                            select r).SingleOrDefault();
                user.Applicant.TimeAction = Time;
                user.idRole = role.idRole;
                var resume = user.Applicant.Resume;
                foreach (var rm in resume)
                {
                    rm.Status = 1;
                }
            }
            else if (user.Employer != null)
            {
                var role = (from r in db.Role
                            where r.NameRole == "Employer"
                            select r).SingleOrDefault();
                user.Employer.TimeAction = Time;
                user.idRole = role.idRole;
                var jobs = user.Employer.Jobs;
                foreach (var jb in jobs)
                {
                    jb.Status = 1;
                }
            }
            db.SaveChanges();
            return RedirectToAction("Home", "Home");
        }

        public void editStatus(string Login)
        {

        }

        public void AddPeople(string Login, string Password, string FirstName, string SecondName, string MiddleName, string namerole)
        {
            People people = new People();
            people.Login = Login;
            people.Password = Password;
            people.FirstName = FirstName;
            people.SecondName = SecondName;
            people.MiddleName = MiddleName;
            var role = (from r in db.Role
                        where r.NameRole == namerole
                        select r).SingleOrDefault();
            people.idRole = role.idRole;
            db.People.Add(people);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}