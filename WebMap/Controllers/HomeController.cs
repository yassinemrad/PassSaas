using ServiceMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace WebMap.Controllers
{
    public class HomeController : Controller
    {
        UserService us = new UserService();
        public ActionResult Index()
        {
            var u = us.GetById(Int32.Parse(User.Identity.GetUserId()));
            ViewBag.img = u.image;
            ViewBag.nom = u.FirstName;
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