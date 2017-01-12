using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MemberShip.Models;

namespace MemberShip.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        KursovikTP db = new KursovikTP();

        //
        // GET: /Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // Post: /Account/Login
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Login, model.Password))
                {
                    AccountController ac = new AccountController();
                    FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        CheckTime(model.Login);
                        return RedirectToAction("Home", "Home");
                    }
                }
            }
            // Появление этого сообщения означает наличие ошибки; повторное отображение формы
            ModelState.AddModelError("", "Имя пользователя или пароль указаны неверно.");
            return View(model);
        }

        public void CheckTime(string Login)
        {
            using (KursovikTP db = new KursovikTP()) {
                var user = (from u in db.People
                            where u.Login == Login
                            select u).SingleOrDefault();
                var role = (from r in db.Role
                            where r.idRole == user.idRole
                            select r).SingleOrDefault();
                var date = DateTime.Now;
                if (role.NameRole == "Applicant")
                {
                    int result = DateTime.Compare(date.Date, user.Applicant.TimeAction.Date);
                    if (result > 0)
                    {
                        user.idRole = 4;
                        editStatus(user.Login, role.NameRole);
                    }
                }
                else if (role.NameRole == "Employer")
                {
                    int result = DateTime.Compare(date.Date, user.Employer.TimeAction.Date);
                    if (result > 0)
                    {
                        user.idRole = 4;
                        editStatus(user.Login, role.NameRole);
                    }
                }
                db.SaveChanges();
            }
        }

        public void editStatus(string Login, string role)
        {
            using (KursovikTP db = new KursovikTP()) {
                var user = (from u in db.People
                            where u.Login == Login
                            select u).SingleOrDefault();
                if (role == "Applicant")
                {
                    var resume = user.Applicant.Resume;
                    foreach (var rm in resume)
                    {
                        rm.Status = 0;
                    }
                }
                else if (role == "Employer")
                {
                    var jobs = user.Employer.Jobs;
                    foreach (var jb in jobs)
                    {
                        jb.Status = 0;
                    }
                }
                db.SaveChanges();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Home", "Home");
        }
    }
}
