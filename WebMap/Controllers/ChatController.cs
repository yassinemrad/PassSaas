using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainMap.Entities;
using Microsoft.AspNet.Identity;
using ServiceMap;

namespace WebMap.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        UserService us = new UserService();
    
        ConnClass cc = new ConnClass();
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Chat()
        {

      
           User u = us.GetById(Int32.Parse(User.Identity.GetUserId()));

            ConnClass.iu = Int32.Parse(User.Identity.GetUserId());
            ViewBag.userr = User.Identity.GetUserId();
          ViewBag.user = u.FirstName.ToString();
            ViewBag.user2= Int32.Parse(User.Identity.GetUserId());
            System.Web.HttpContext.Current.Session["us"] = Int32.Parse(User.Identity.GetUserId());
            
            return View();
        }
    }
}