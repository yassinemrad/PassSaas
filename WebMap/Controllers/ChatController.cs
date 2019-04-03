using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hanssens.Net;
using Microsoft.AspNet.Identity;

namespace WebMap.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Chat()
        {
            
            //localStorage.setItem("a", "a");
            ViewBag.user = User.Identity.GetUserId();
           
            return View();
        }
    }
}