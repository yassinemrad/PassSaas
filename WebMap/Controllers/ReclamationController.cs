
using DomainMap.Entities;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;
using Microsoft.AspNet.Identity;

namespace WebMap.Controllers
{
    public class ReclamationController : Controller
    {
        

        ReclamationService rs = new ReclamationService();
        // GET: Reclamation
        public ActionResult Index()
        {
            var r = rs.listRecNonLu();
            List<reclamationViewModel> l = new List<reclamationViewModel>();
            foreach(var i in r)
            {
                reclamationViewModel rv = new reclamationViewModel();
                rv.id = i.id;
                rv.description = i.description;
                rv.objet = i.objet;
                rv.user = i.user;
                rv.date = i.date;
                l.Add(rv);
                
            }
           
            return View(l);
        }
        public ActionResult Traiter()
        {
           
            var r = rs.listRecLu();
            List<reclamationViewModel> l = new List<reclamationViewModel>();
            foreach (var i in r)
            {
                reclamationViewModel rv = new reclamationViewModel();
                rv.id = i.id;
                rv.description = i.description;
                rv.objet = i.objet;
                rv.user = i.user;
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
            return View();
        }

        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(reclamationViewModel rec)
        {
           
            reclamation r = new reclamation();
            r.etat = 1;
            r.objet = rec.objet;
            r.description = rec.description;
            r.date= DateTime.Now.ToString("dd-MM-yyyy");
           // r.user = User.Identity.GetUserId;
            rs.Add(r);
            rs.Commit();
            return RedirectToAction("MyReclamation");
        }

        // GET: Reclamation/Edit/5
        public ActionResult Edit(int id)
        {
            reclamation r = rs.GetById(id);
            if (r.etat.Equals(0))
            {
                TempData["erreur"] = "oui";

                //   ViewBag.erreur ="oui";
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

                //   ViewBag.erreur ="oui";
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
        public ActionResult Traitement(int id)
        {
            reclamation r = rs.GetById(id);
            r.etat = 0;
            rs.Update(r);
            rs.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult MyReclamation()
        {
            var r = rs.GetByUser("yassin.mrad@yahoo.fr");
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
