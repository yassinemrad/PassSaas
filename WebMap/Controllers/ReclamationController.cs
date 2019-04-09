
using DomainMap.Entities;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Security.Claims;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace WebMap.Controllers
{
    
    public class ReclamationController : Controller
    {
    

        ReclamationService rs = new ReclamationService();
        UserService us = new UserService();
        // GET: Reclamation
        public ActionResult Index()
        {

            User u = us.GetById(Int32.Parse(User.Identity.GetUserId()));
            if (u.Role.Equals("TeamMember") || u.Role.Equals("TeamLeader"))
            {
                return RedirectToAction("MyReclamation");
            }
            else
            {
                //ViewBag.rr = System.Web.Security.Roles.GetRolesForUser(User.Identity.Name);

                var r = rs.listRecNonLu();
                List<reclamationViewModel> l = new List<reclamationViewModel>();
                //Session["idU"] = User.Identity.GetUserId();
                // ViewBag.user = ConnClass.iu;

                foreach (var i in r)
                {
                    var a = us.GetById(i.user);
                    reclamationViewModel rv = new reclamationViewModel();
                    rv.id = i.id;
                    rv.description = i.description;
                    rv.objet = i.objet;
                    rv.username =a.FirstName;
                    rv.mail = a.UserName;
                    rv.date = i.date;
                    l.Add(rv);

                }

                return View(l);
            }
        }
        public ActionResult Traiter()
        {
         
            var r = rs.listRecLu();
            List<reclamationViewModel> l = new List<reclamationViewModel>();
            foreach (var i in r)
            {
                var a = us.GetById(i.user);
                reclamationViewModel rv = new reclamationViewModel();
                rv.user = i.user;
                rv.id = i.id;
                rv.description = i.description;
                rv.objet = i.objet;
                rv.username = a.FirstName;
                rv.date = i.date;
                l.Add(rv);

            }

            return View(l);
        }

        // GET: Reclamation/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Reclamation/Create
        public ActionResult Create()
        {
            ViewBag.user = User.Identity.GetUserId();
            return View();
        }

        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(int id, reclamationViewModel rec)
        {
            if (ModelState.IsValid)
            {
                reclamation r = new reclamation();
                r.etat = 1;
                r.objet = rec.objet;
                r.description = rec.description;
                r.date = DateTime.Now.ToString("dd-MM-yyyy");
                r.user = id;
                rs.Add(r);
                rs.Commit();

               
            }
            return RedirectToAction("MyReclamation");
        }

        // GET: Reclamation/Edit/5
        public ActionResult Edit(int id)
        {
            reclamation r = rs.GetById(id);
            if (r.etat.Equals(0))
            {
                TempData["erreur"] = "oui";
                return RedirectToAction("MyReclamation");
            }
            else
            {
                reclamationViewModel rvm = new reclamationViewModel();
                rvm.id = r.id;
                rvm.objet = r.objet;
                rvm.description = r.description;
                rvm.etat = r.etat;
                rvm.user = r.user;
                rvm.date = r.date;
                return View(rvm);
            }
        }
        // POST: Reclamation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, reclamationViewModel  rvm)
        {
            
            reclamation r = rs.GetById(id);
           
                r.objet = rvm.objet;
                r.description = rvm.description;
                r.date = DateTime.Now.ToString("dd-MM-yyyy");
                rs.Update(r);
                rs.Commit();


                return RedirectToAction("MyReclamation");
            }
        

        // GET: Reclamation/Delete/5
        public ActionResult Delete(int id)
        {
            reclamation r = rs.GetById(id);
            if (r.etat.Equals(0))
            {
                TempData["erreur"] = "oui";

                   
                return RedirectToAction("MyReclamation");
            }
            else
            {
                rs.Delete(r);
                rs.Commit();

                return RedirectToAction("MyReclamation");
            }
        }

        // POST: Reclamation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            // TODO: Add delete logic here

            return RedirectToAction("MyReclamation");

        }
        public ActionResult Traitement(int id,string mail,string suj )
        {
            reclamation r = rs.GetById(id);
            r.etat = 0;
            rs.Update(r);
            rs.Commit();
            var senderemail = new MailAddress("mehrezyassin.mrad@esprit.tn");
            var receiveremail = new MailAddress(mail);
            MailMessage mess = new MailMessage(senderemail, receiveremail);
            mess.BodyEncoding = Encoding.UTF8;
            var password = "yassine<3cyrine";
            

            //var body = string.Concat("Bonjour je suis votre Docteur Mr/Mme " + FindFirstNameOfUserById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId())) + " " + FindLastNameOfUserById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId())) + " , je voulais vous informer que je vous ai planifié un nouveau rendez-vous avec " + Request["NomMedecin"].ToString() + " Spécialisé en " + Request["Specialite"].ToString() + " veuillez consulter votre parcours et merci d'attendre la confirmation du docteur que je vous ai recommandé");
            var body = "your mail of  "+suj.ToUpper()+"  is treat";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

            //Host =,
            //  Port = 587,
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(senderemail.Address, password);


  


                mess.Subject = "Reclamation";
                mess.Body = body;


            try
            {
                smtp.Send(mess);


            }
            catch (Exception ex)
            {
                throw ex;  
            }





            return RedirectToAction("Index");
        }
        public ActionResult MyReclamation()
        {

           var r = rs.GetByUser(Int32.Parse(User.Identity.GetUserId()));
            ViewBag.us = Int32.Parse(User.Identity.GetUserId());
            List<reclamationViewModel> l = new List<reclamationViewModel>();
            foreach (var i in r)
            {
                reclamationViewModel rv = new reclamationViewModel();
                rv.id = i.id;
                rv.description = i.description;
                rv.objet = i.objet;
               
                rv.date = i.date;
                l.Add(rv);

            }
           // ViewBag.erreur = "oui";
            return View(l);
        }
    }

}
