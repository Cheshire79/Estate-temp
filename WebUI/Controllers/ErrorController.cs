using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WebUI.Mapper;

namespace WebUI.Controllers
{

    public class ErrorController : Controller
    {
        private IMapper _mapper;
        static int _count;
        public ErrorController(IMapperFactoryWEB mapperFactory)
        {
            _count++;
           _mapper = mapperFactory.CreateMapperWEB();

        }
        public ActionResult BadRequest(string message)
        {
             Response.StatusCode = 400;
            return View();
        }

        public ActionResult NotFound(string message)
        {
                Response.StatusCode = 404;
            ViewBag.Error = message + _count;
            return View();
        }

        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View();
        }
    }
}