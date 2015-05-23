using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Controllers.api;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewOrder()
        {
            ViewBag.Message = "Your application description page.";
            var order = new Orders();
            return View(order);
        }

    }
}