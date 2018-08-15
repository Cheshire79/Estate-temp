
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebUI.Binders;
using WebUI.Models.UsersSearch;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(UsersSearchResult), new UsersSearchResultBinder());
        }
        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    //Exception exception = Server.GetLastError();
        //    //Response.Clear();

            

        //    //string action;
        //    //action = "BadRequest";
        //    //    HttpException httpException = exception as HttpException;

        //    //    if (httpException != null)
        //    //switch (httpException.GetHttpCode())
        //    //{
        //    //   case 400:
        //    //        // page not found
        //    //        action = "BadRequest";
        //    //        break;
        //    //    case 404:
        //    //        // server error
        //    //        action = "NotFound";
        //    //        break;
        //    ////    default:
        //    ////        action = "General";
        //    ////        break;
        //    //}

        //    //// clear error on server
        //    //Server.ClearError();

        //    //Response.Redirect(String.Format("~/Error/{0}/?message={1}", action, exception.Message));
        //}
    }
}
