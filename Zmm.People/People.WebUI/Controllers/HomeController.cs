using People.Models;
using People.Models.WebModel;
using People.WebUI.Filter;
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

        /// <summary>
        /// 这是登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Add()
        {
            new Exception();
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
            //验证模型
            //Validate(model);

            if (ModelState.IsValid)
            {
                model.uId = Guid.NewGuid();
                userBll.Add(model);
                return RedirectToAction("/Index");
            }
            return View(model);
        }

        /// <summary>
        /// 手动验证模型
        /// </summary>
        /// <param name="model"></param>
        private void Validate(P_User model)
        {
            if (model.uAddr == null || model.uAddr == string.Empty)
            {
                ModelState.AddModelError("Addr", "请输入收货地址.");
            }
            if (model.uAge == null || model.uAge > 100 || model.uAge <= 0)
            {
                ModelState.AddModelError("age", "年龄必须在0-100岁之间.");
            }

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


        /// <summary>
        /// 验证该用户是否已经存在
        /// </summary>
        /// <param name="uName"></param>
        /// <returns></returns>
        public JsonResult ExistsUsername(string uProvince, string uName)
        {
            var single = userBll.GetSingleByName(uName);
            if (single != null)
                return Json("该用户名已经存在", JsonRequestBehavior.AllowGet);
            else if (uProvince != "安徽省" || uProvince != "江苏省")
                return Json("必须是安徽省或者江苏省人士.", JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}