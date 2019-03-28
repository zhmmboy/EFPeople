using People.Models;
using System.Web.Mvc;

namespace People.WebUI.Controllers
{
    public class TagController : Controller
    {
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext executingContext)
        {
            if(executingContext.HttpContext.User.Identity.IsAuthenticated)
            {
                executingContext.Result = new RedirectToRouteResult("Home", new System.Web.Routing.RouteValueDictionary() { { "", "" }, { "", "" }, { "", "" } });
            }
        }

        // GET: Tag
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(P_Tags model)
        {
            return View();
        }
    }
}