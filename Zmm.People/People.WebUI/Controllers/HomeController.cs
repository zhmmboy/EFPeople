using People.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace People.WebUI.Controllers
{
    public class HomeController : Controller
    {
        BLL.UserBLL userBll = new BLL.UserBLL();

        // GET: Home
        public ActionResult Index()
        {
            int total = 0;
            var lst = userBll.GetList(1, 10, out total, 1).ToList();

            return View(lst);
        }

        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("参数为空.");
            }

            var single = userBll.GetSingle(id);
            return View(single);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(P_User model)
        {
            if (ModelState.IsValid)
            {
                var single = userBll.Update(model);

            }
            return View();
        }


        public ActionResult Delete()
        {
            return View();
        }
    }
}