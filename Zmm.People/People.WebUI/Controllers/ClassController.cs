using People.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace People.WebUI.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(P_Class model)
        {
            return View();
        }
    }
}