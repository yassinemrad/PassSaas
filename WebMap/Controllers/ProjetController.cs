using DomainMap.Entities;
using Rotativa;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;
using Projet = DomainMap.Entities.Projet;

namespace WebMap.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class ProjetController : Controller
    {
        ProjetService PS = new ProjetService();

        public ProjetController()
        {
            service = new ProjetService();
           
        }
        // GET: Projet
        public ActionResult Index()
        {
            List<ProjetModels> lists = new List<ProjetModels>();
            foreach (var item in PS.GetAll())
            {
                ProjetModels dvm = new ProjetModels();
                dvm.id = item.id;

                dvm.name = item.name;

                dvm.description = item.description;
                dvm.endDate = item.endDate;
                dvm.startDate = item.startDate;
                dvm.modules = item.modules;
                dvm.Budget = item.Budget;

                dvm.Photo = item.Photo;

                dvm.cathegory =item.cathegory;
                //dvm.Etat.Equals(item.Etat);
                lists.Add(dvm);

            }
            return View(lists);
        }
        [HttpPost]
        public ActionResult Index(string searchString)
        {

            List<WebMap.Models.ProjetModels> lists = new List<WebMap.Models.ProjetModels>();
            foreach (var item in PS.GetAll())
            {
                WebMap.Models.ProjetModels dvm = new WebMap.Models.ProjetModels();
                dvm.name = item.name;
                dvm.description = item.description;
                dvm.startDate = item.startDate;
                dvm.endDate = item.endDate;
                dvm.Budget = item.Budget;

                dvm.Photo = item.Photo;

                dvm.cathegory = item.cathegory;
                //dvm.Etat.Equals(item.Etat);
                lists.Add(dvm);

            }
            // return View(lists);
            if (!String.IsNullOrEmpty(searchString))
            {
                lists = lists.Where(m => m.name.Contains(searchString)).ToList();
            }
           

            return View(lists);
        }


        // GET: Projet/Details/5
        public ActionResult Details(int id)
        {
            var pr = PS.GetById(id);

        
            WebMap.Models.ProjetModels bvm = new WebMap.Models.ProjetModels();
            //bvm.cathegory = (WebMap.Models.Cathegory)pr.cathegory;

            bvm.name = pr.name;
            bvm.description = pr.description;
            bvm.Photo = pr.Photo;
            bvm.startDate = pr.startDate;
            bvm.endDate = pr.endDate;
            bvm.Budget = pr.Budget;

            bvm.cathegory = pr.cathegory;

            return View(bvm);
        }

        // GET: Projet/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Projet/Create
        [HttpPost]
        public ActionResult Create(DomainMap.Entities.Projet DVM, HttpPostedFileBase Image)
        {


            DomainMap.Entities.Projet d = new DomainMap.Entities.Projet() { cathegory = DVM.cathegory };



            //d.cathegory = DVM.cathegory;
            d.id = DVM.id;
            d.name = DVM.name;

            d.startDate = DVM.startDate;
            d.endDate = DVM.endDate;
            d.description = DVM.description;
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            d.Photo = Image.FileName;
            d.Budget = DVM.Budget;


            PS.Add(d);
            PS.Commit();
            return RedirectToAction("Index");
        }

        // GET: Projet/Edit/5
        public ActionResult Edit(int id)
        {
            var bib = PS.GetById(id);


            WebMap.Models.ProjetModels bvm = new WebMap.Models.ProjetModels();
            bvm.name = bib.name;
            bvm.description = bib.description;
            bvm.startDate = bib.startDate;
            bvm.endDate = bib.endDate;
            bvm.Budget = bib.Budget;
            bvm.Photo = bib.Photo;

            bvm.cathegory.Equals(bib.cathegory);

            return View(bvm);
        }

        // POST: Projet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, WebMap.Models.ProjetModels DVM, HttpPostedFileBase Image)
        {
            Projet d = PS.GetById(id);


            d.id = DVM.id;
            d.name= DVM.name;
            d.description = DVM.description;
            d.startDate = DVM.startDate;
            d.endDate = DVM.endDate;
            d.Budget = DVM.Budget;
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            d.Photo =Image.FileName;

            //d.Photo =DVM.Photo;
            d.cathegory = (DomainMap.Entities.Cathegory)DVM.cathegory;






            PS.Update(d);
            PS.Commit();
            return RedirectToAction("Index");
        }

        // GET: Projet/Delete/5
        public ActionResult Delete(int id)
        {
            var bib = PS.GetById(id);


            WebMap.Models.ProjetModels bvm = new WebMap.Models.ProjetModels();
            //DomainMap.Entities.Projet d = new DomainMap.Entities.Projet() { cathegory = bib.cathegory };

            //bvm.cathegory = bib.cathegory;
            //bvm.id = bib.id;

            bvm.name = bib.name;
            bvm.startDate = bib.startDate;
            bvm.endDate = bib.endDate;
            bvm.description = bib.description;
            bvm.Budget = bib.Budget;

            bvm.cathegory.Equals(bib.cathegory);


            return View(bvm);
        }

        // POST: Projet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, WebMap.Models.ProjetModels DVM)
        {
            Projet d = PS.GetById(id);
            //DVM.cathegory = d.cathegory;
            DVM.id = d.id;
            DVM.name = d.name;
            DVM.description = d.description;
            DVM.startDate = d.startDate;
            DVM.endDate = d.endDate;
            DVM.cathegory.Equals(d.cathegory);
            //DomainMap.Entities.Projet dd = new DomainMap.Entities.Projet() { cathegory = d.cathegory };
            DVM.Budget = d.Budget;

            PS.Delete(d);
            PS.Commit();
            return RedirectToAction("Index");
        }
        IProjetService service = null;

        public ActionResult DelivredProject()
        {
            ViewBag.delproj = service.getDelivredProject();
            return View();
        }
        public ActionResult NonDelivredProject()
        {
            ViewBag.nondelproj = service.getNonDelivredProject();
            return View();
        }
        public ActionResult MostExpensiveProject()
        {
            ViewBag.expproj = service.getMostExpensiveProject();
            return View();
        }
        public ActionResult ProjectInGivenTime(String From, String To)
        {
            DateTime fromd = Convert.ToDateTime(From);
            DateTime tod = Convert.ToDateTime(To);
            ViewBag.projet = service.getProjectInDate(fromd, tod);
            return View();
        }
        // GET: Projet/Create

        public ActionResult MyCalendar()
        {
            return View();
        }
       
        public JsonResult GetProjets()
        {
            var Projets = PS.GetAll();
            
            return new JsonResult { Data = Projets, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }
        public ActionResult PrintDetails()
        {
          
            var report = new ActionAsPdf("Index");
            return report;
        }
    }
}
