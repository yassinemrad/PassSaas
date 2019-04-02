

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
    public class TasksController : Controller
    {
        TasksService ts = new TasksService();
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
                        modules=item.modules,
                       
            });
        }
       
        List<TasksModels> fVm2 = fVM.ToList();
            return View(fVm2);

    }

        // GET: Tasks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        public ActionResult Create(TasksModels ta)
        {
                Tasks t = new Tasks();  
                t.name = ta.name;
                t.date = ta.date;
                t.description = ta.description;
            
                ts.Add(t);
                ts.Commit();
                
            return RedirectToAction("AllTasks");
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]

        // POST: Tasks/Edit/5

        public ActionResult Edit(int id, TasksModels task)
        {


            Tasks t = ts.GetById(id);
            t.id = task.id;
            t.name = task.name;
            t.description = task.description;
            t.date = task.date;
            ts.Update(t);
            ts.Commit();

            return View("Edit");


        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tasks/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TasksModels task)
        {
            Tasks t = ts.GetById(5);

            t.id = task.id;
            t.name = task.name;
            t.startDate = task.startDate;
            t.estimation = task.estimation;
            t.realDuration = task.realDuration;
            ts.Delete(t);
            ts.Commit();
            return RedirectToAction("Delete", new { id = id, saveChangesError = true });
        }
    }
}
