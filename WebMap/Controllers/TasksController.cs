

using DomainMap.Entities;
using Microsoft.AspNet.Identity;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;

namespace WebMap.Controllers
{
    public class TasksController : Controller
    {
        TasksService ts = new TasksService();
        ModuleService ser = new ModuleService();

        // GET: Tasks
        public ActionResult AllTasks()
        {

            var task = ts.GetAll();
            List<TasksModels> fVM = new List<TasksModels>();

            foreach (var item in task)
            {

                fVM.Add(
                    new TasksModels
                    {

                        id = item.id,
                        name = item.name,
                        description = item.description,
                        date = item.date,
                        idmodul = item.idmodul,





                    });
            }

            List<TasksModels> fVm2 = fVM.ToList();
            return View(fVm2);

        }

        // GET: Tasks/Details/5
        public ActionResult Details(int id)
        {
            var task = ts.GetById(id);
            TasksModels tas = new TasksModels();
            tas.id = id;
            tas.description = task.description;
            tas.name = task.name;
            tas.date = task.date;



            return View(tas);

        }

        // GET: Tasks/Create
        public ActionResult Create(int id, TasksModels taa)
        {

            Tasks t = new Tasks();

            t.idmodul = taa.id = id;


            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        public ActionResult Create(TasksModels ta, int id)
        {

            Tasks t = new Tasks();
            t.name = ta.name;
            t.date = ta.date;
            t.description = ta.description;
            t.idmodul = ta.idmodul = id;
            t.dateAjout = ta.dateAjout = DateTime.Now;
            t.iduser = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ts.Add(t);
            ts.Commit();

            return RedirectToAction("AllTasks");
        }


        // GET: Tasks/Edit/5
        public ActionResult Edit(int id)
        {

            Tasks t = ts.GetById(id);
            TasksModels task = new TasksModels();
            task.name = t.name;
            task.description = t.description;
            task.date = t.date;

            return View(task);
        }

        [HttpPost]

        // POST: Tasks/Edit/5

        public ActionResult Edit(int id, TasksModels task)
        {

            var t = ts.GetById(id);
            t.name = task.name;
            t.description = task.description;
            t.date = task.date;
            ts.Update(t);
            ts.Commit();

            return RedirectToAction("AllTasks");

        }
        [HttpPost]
        // POST: Tasks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        // GET: Tasks/Delete/5
        public ActionResult Delete(int id, TasksModels task)
        {
            Tasks t = ts.GetById(id);


            ts.Delete(t);
            ts.Commit();
            return RedirectToAction("AllTasks");
        }
    }
}
