using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemberShip.Models;

namespace MemberShip.Controllers
{

    public class HomeController : Controller
    {

        //
        // GET: /Home/
        [Authorize]
        public ActionResult Home()
        {
            return View();
        }

        //
        // GET: /InformationApplicant/
        [Authorize]
        public ActionResult InformationApplicant()
        {
            return View();
        }

        //
        // GET: /InformationEmployer/
        [Authorize]
        public ActionResult InformationEmployer()
        {
            return View();
        }
    }
}
