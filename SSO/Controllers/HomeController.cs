using SSO.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSO.Controllers
{
    public class HomeController : Controller
    {
        [SSOAuthorize]
        public ActionResult Index()
        {
            return View();
        }
        [SSOAuthorize]
        public ActionResult Home()
        {
            return View();
        }
    }
}