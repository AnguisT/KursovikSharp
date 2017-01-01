using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemberShip.Models;

namespace MemberShip.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        //
        // GET: /Home/
        public ActionResult Home()
        {
            return View();
        }

        //
        // GET: /InformationApplicant/
        public ActionResult InformationApplicant()
        {
            return View();
        }

        //
        // GET: /InformationEmployer/
        public ActionResult InformationEmployer()
        {
            return View();
        }
    }
}
