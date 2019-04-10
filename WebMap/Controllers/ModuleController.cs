using DomainMap.Entities;
using Microsoft.AspNet.Identity;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;

namespace WebMap.Controllers
{
    public class ModuleController : Controller
    {
        ModuleService md = new ModuleService();
        TasksService to = new TasksService();
        // GET: Module
        public ActionResult Index()
        {
            var modu = md.GetAll();


            List<ModuleModels> fVM = new List<ModuleModels>();

            foreach (var item in modu)
            {

                fVM.Add(
                    new ModuleModels
                    {

                        id = item.id,
                        nom = item.nom,


                    });
            }

            List<ModuleModels> fVm2 = fVM.ToList();
            return View(fVm2);

        }

        // GET: Module/Details/5
        public ActionResult Details(int id)
        {
            int b = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var mod = md.GetById(id);
         
            Tasks y = new Tasks();
            var tr = to.GetById(y.idmodul);
            ModuleModels tas = new ModuleModels();
            tas.id = id;
         //   tas.nomtask = tr.name;
           
            tas.iduser = mod.iduser = b;
            tas.nom = mod.nom;


            return View(tas);
        }
        public ActionResult AllTasksModule()
        {
            Tasks t = new Tasks();
            Module po = new Module();
            var mod = md.GetById(po.id);

            var task = to.GetAll();
            List<TasksModels> fVM = new List<TasksModels>();

            foreach (var item in task)
            {
                DateTime da1 = item.date;
                DateTime da2 = item.dateAjout;
                TimeSpan ts = da1.Date - da2.Date;
                int differenceInDays = ts.Days;
                int s = da1.Date.Subtract(DateTime.Now.Date).Days;

                string b = "0 mois et " + differenceInDays + " jours";
                string er = "0 mois et " + differenceInDays + " jours";
                if (differenceInDays > 30 && s > 30)
                {
                    int div = differenceInDays / 30;
                    int d = differenceInDays - div * 30;
                    string m = div + " mois et " + d + " jours";
                    //le rest
                    int a = s / 30;
                    int p = s - a * 30;
                    string i = a + " mois et " + p + " jours";

                    fVM.Add(
                        new TasksModels
                        {

                            id = item.id,
                            name = item.name,
                           
                            description = item.description,
                            date = item.date,

                            diff = m,




                        });
                }
                else
                {
                    fVM.Add(
                        new TasksModels
                        {

                            id = item.id,
                            name = item.name,
                         
                            description = item.description,
                            date = item.date,

                            diff = b,




                        });

                }
            }


            List<TasksModels> fVm2 = fVM.Where(e => e.idmodul == mod.id).ToList();
            return View(fVm2);

        }


        // GET: Module/Create
        public ActionResult Create(FormCollection collection)
        {

            return View();
        }

        // POST: Module/Create
        [HttpPost]
        public ActionResult Create(ModuleModels mod)
        {
            UserService us = new UserService();
            Module m = new Module();
      

            User ui = new User();
            var Affect = md.GetAll();
            int b = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());

            ModuleModels t = new ModuleModels();
            // dropdownlist users
            var pro = us.GetAll().Where(e=>e.Id != b);
            ViewData["proKey"] = new SelectList(pro, "iduser", "LastName");
            var x = us.GetAll().Where(e => e.Id != b).
               Select(w => new SelectListItem
               {
                   Text = w.LastName + " " + w.FirstName,

                   Value = w.Id.ToString()
               });

            t.Users = x;
            m.nom = mod.nom;
            m.iduser = m.iduser = b;

            md.Add(m);
            md.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult Affect(ModuleModels mod)
        {
          

            return RedirectToAction("Index");
        }

        // GET: Module/Edit/5
        public ActionResult Edit(int id)
        {

            Module t = md.GetById(id);
            ModuleModels task = new ModuleModels();
            t.nom = task.nom;


            return View(task);
        }

        // POST: Module/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ModuleModels mod)
        {
            var t = md.GetById(id);
            t.nom = mod.nom;
            
            md.Update(t);
            md.Commit();

            return RedirectToAction("Index");
        }

        // GET: Module/Delete/5
        public ActionResult Delete(int id)
        {
            Module t = md.GetById(id);


            md.Delete(t);
            md.Commit();
            return RedirectToAction("Index");
        }

        // POST: Module/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
