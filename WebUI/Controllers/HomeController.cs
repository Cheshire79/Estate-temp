using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            //if (filterContext.ExceptionHandled)
            //{
            //    return;
            //}

            //filterContext.Result = View("Error");
            //ViewBag.Error = filterContext.Exception.Message;
            //filterContext.ExceptionHandled = true;
            //if (filterContext.ExceptionHandled)
            //{
            //    return;
            //}

            //filterContext.Result = View("Error");
            //ViewBag.Error = filterContext.Exception.Message;
            //filterContext.ExceptionHandled = true;


            string action;
            action = "Forbidden";
            HttpException httpException = filterContext.Exception as HttpException;

            if (httpException != null)
                switch (httpException.GetHttpCode())
                {
                    case 400:
                        // page not found
                        action = "BadRequest";
                        break;
                    case 404:
                        // server error
                        action = "NotFound";
                        break;
                    default:
                        action = "Forbidden";
                        break;
                }

            // clear error on server
            Server.ClearError();
            filterContext.ExceptionHandled = true;
            Response.Redirect(String.Format("~/Error/{0}/?message={1}", action, filterContext.Exception.Message));
           
        }
        public ActionResult Index()
        {

            throw new HttpException(404,"Mine");
            int x = 0;
            int y = 8 / x;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }       

    }
}