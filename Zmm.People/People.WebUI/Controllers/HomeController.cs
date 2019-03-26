using People.Models;
using People.Models.WebModel;
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
        
        public ActionResult UploadFile()
        {
            var ff = System.Web.HttpContext.Current.Request.Files;

            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add(P_User model)
        {
            if (ModelState.IsValid)
            {
                model.uId = Guid.NewGuid();
                userBll.Add(model);
                return RedirectToAction("/Index");
            }
            return View();
        }

        [HttpPost]
        public JsonResult Index(string uId)
        {
            if (string.IsNullOrEmpty(uId))
            {
                return new JsonResult() { Data = new { message = "fail" } };
            }
            else
            {
                var single = userBll.GetSingle(uId);
                userBll.Delete(single);

                return new JsonResult() { Data = new { message = "success" } };
            }
        }

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
            ViewData["flag"] = "000000";
            ViewBag.success = true;
            if (ModelState.IsValid)
            {
                var single = userBll.Update(model);
            }

            return View();
            //return RedirectToAction("/Index");
        }
    }
}