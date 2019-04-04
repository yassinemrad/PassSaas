using DomainMap.Entities;
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
            return View();
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
            Module m = new Module();
            m.nom = mod.nom;
            md.Add(m);
            md.Commit();

            return RedirectToAction("Index");
        }

        // GET: Module/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Module/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Module/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
