

using DomainMap.Entities;
using Microsoft.AspNet.Identity;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;

namespace WebMap.Controllers
{
    public class TasksController : Controller
    {
        TasksService ts = new TasksService();
        ModuleService ser = new ModuleService();
        UserService us = new UserService();
        ProjetService pr = new ProjetService();

        public string FindNameModuleById(int id)
        {

            string y = ser.GetById(id).nom;
            return y;
        }
        public string FindMailOfUserById(int id)
        {

            string y = us.GetById(id).Email;
            return y;
        }
        public string FindPasswordOfUserById(int id)
        {

            string y = us.GetById(id).Password;
            return y;
        }
        public string FindFirstNameOfUserById(int id)
        {

            string y = us.GetById(id).FirstName;
            return y;
        }
        public string FindLastNameOfUserById(int id)
        {

            string y = us.GetById(id).LastName;
            return y;
        }
        // GET: Tasks
        public ActionResult AllTasks(string searchString)
        {

            var task = ts.GetAll();
            List<TasksModels> fVM = new List<TasksModels>();

            foreach (var item in task)
            {
                DateTime da1 = item.date;
                DateTime da2 = item.dateAjout;
                TimeSpan ts = da1.Date - da2.Date;
                int differenceInDays = ts.Days;
                int  s=da1.Date.Subtract(DateTime.Now.Date).Days;
                
                string b =  "0 mois et " + differenceInDays + " jours";
                string er = "0 mois et " + differenceInDays + " jours";
                if (differenceInDays > 30 && s>30)
                {
                    int div = differenceInDays / 30;
                    int d = differenceInDays - div * 30;
                    string m = div + " mois et " + d + " jours";
                    //le rest
                    int a = s / 30;
                    int p = s - a * 30;
                    string i = a + " mois et " +p + " jours";

                    fVM.Add(
                        new TasksModels
                        {

                            id = item.id,
                            name = item.name,
                            nuser = FindFirstNameOfUserById(item.iduser) + " " + FindLastNameOfUserById(item.iduser),
                            description = item.description,
                            date = item.date,

                            diff = m,
                            rest = i,



                        });
                }
                else {
                    fVM.Add(
                        new TasksModels
                        {

                            id = item.id,
                            name = item.name,
                            nuser = FindFirstNameOfUserById(item.iduser) + " " + FindLastNameOfUserById(item.iduser),
                            description = item.description,
                            date = item.date,

                            diff = b,
                            rest = er,



                        });
                    /*
                      if (differenceInDays == 3)
                      {
                        Tasks tt = new Tasks();

                          var senderemail = new MailAddress(FindMailOfUserById(tt.iduser), "Rappel");
                          var receiveremail = new MailAddress(FindMailOfUserById(tt.iduserAffect), "Receiver");
                          var password = FindPasswordOfUserById(tt.iduser);
                          var sub = "Votre Delais :Expirer";

                          var body = string.Concat("Bonjour je suis le responsable du Module Mr/Mm" + FindFirstNameOfUserById(tt.iduser) + " " + FindLastNameOfUserById(tt.iduser) + " , je voulais vous informer que vous n'avez pas terminer votre tache et vous reste seulement 3 jours de cette tache" + Request["name"].ToString() + " veuillez consulter votre liste des taches ");
                          var smtp = new SmtpClient
                          {
                              Host = "smtp.gmail.com",
                              Port = 587,
                              EnableSsl = true,
                              DeliveryMethod = SmtpDeliveryMethod.Network,
                              UseDefaultCredentials = false,
                              Credentials = new NetworkCredential(senderemail.Address, password)

                          };
                          using (var mess = new MailMessage(senderemail, receiveremail)
                          {
                              Subject = "Proposition Rendez-vous",
                              Body = body
                          })
                          {
                              smtp.Send(mess);
                          }
                      }*/
                }
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                fVM = fVM.Where(m => m.name.Contains(searchString)).ToList();
            }

            List<TasksModels> fVm2 = fVM.ToList();
            return View(fVm2);

        }

        public ActionResult MyTasks(string searchString)
        {
           int id = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var task = ts.GetAll();
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

                          
                            name = item.name,
                            nuser = FindFirstNameOfUserById(item.iduser) + " " + FindLastNameOfUserById(item.iduser),
                            description = item.description,
                            date = item.date,

                            diff = m,
                            rest = i,



                        });
                }
                else
                {
                    fVM.Add(
                        new TasksModels
                        {

                           
                            name = item.name,
                            nuser = FindFirstNameOfUserById(item.iduser) + " " + FindLastNameOfUserById(item.iduser),
                            description = item.description,
                            date = item.date,

                            diff = b,
                            rest = er,



                        });
                  
                }
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                fVM = fVM.Where(m => m.name.Contains(searchString)).ToList();
            }

            List<TasksModels> fVm2 = fVM.ToList();
            return View(fVm2);

        }

        public ActionResult AllTasksModule()
        {
            Tasks t = new Tasks();
            Module po = new Module();
            var mod = ser.GetById(po.id);

            var task = ts.GetAll();
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
                            nuser = FindFirstNameOfUserById(item.iduser) + " " + FindLastNameOfUserById(item.iduser),
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
                            nuser = FindFirstNameOfUserById(item.iduser) + " " + FindLastNameOfUserById(item.iduser),
                            description = item.description,
                            date = item.date,

                            diff = b,
                            



                        });
                    
                }
            }
         

            List<TasksModels> fVm2 = fVM.Where(e=>e.idmodul == mod.id ).ToList();
            return View(fVm2);

        }
        //GET:List Affectation
        public ActionResult Affectation()
            {
            
            Tasks task1 = new Tasks();
            TasksModels tas = new TasksModels();
            User ui = new User();
            UserService us = new UserService();
            var Affect = ts.GetAll();
            int b = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());
            Tasks p = new Tasks();
            TasksModels t = new TasksModels();
            // dropdownlist users
            var pro = us.GetAll().Where(e => e.Id != b);
            ViewData["proKey"] = new SelectList(pro, "iduser", "LastName");
            var x = us.GetAll().Where(e => e.Id != b).
               Select(w => new SelectListItem
               {
                   Text = w.LastName + " " + w.FirstName,

                   Value = w.Id.ToString()
               });

            t.Users = x;

            List<TasksModels> fV = new List<TasksModels>();

            foreach (var item in Affect)
                {
            

                fV.Add(
                    new TasksModels
                    {   id=item.id,
                        name = item.name,
                        nmod =ser.GetById(item.idmodul).nom,
                       Users=x
                            
                        });
                }

            

            List<TasksModels> f = fV.Where(e=>e.iduserAffect == 0).ToList();
            Model model = new Model();
            model.tasks = fV;
            

            return View(model);
            

        }

        //GET:creat Affectation
        public ActionResult ListUsersNonAffection()
        {
            Tasks p = new Tasks();
            TasksModels t = new TasksModels();
            int b = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());
            // dropdownlist users
            var pro = us.GetAll().Where(e => e.Id != b);
            ViewData["proKey"] = new SelectList(pro, "iduser", "LastName");
            var x = us.GetAll().Where(e => e.Id != b).
               Select(w => new SelectListItem
               {
                   Text = w.LastName + " " + w.FirstName,

                   Value = w.Id.ToString()
               });

            t.Users = x;
           
            return View(t);

        }
        [HttpPost]
        public ActionResult ListUsersNonAffection(IEnumerable<TasksModels> ta)
        {
            var t = ta;
            Tasks p = new Tasks();

           
            return View();
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
            tas.nmod = ser.GetById(task.idmodul).nom;
            tas.etat =(Models.Etat) task.etat;
            return View(tas);

        }
        // GET: Tasks/Create
        public ActionResult Changestatus(TasksModels ta)
        {

            Tasks t = new Tasks();
            t = ts.GetById(ta.id);
            t.etat =(DomainMap.Entities.Etat) ta.etat;
            ts.Update(t);
            ts.Commit(); 
            
            

            return RedirectToAction("AllTasks");
        }

        public ActionResult Calandrier()
        {
            var tasks = ts.GetAll();
            



            return View(tasks);
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
            Module o = new Module();
            Tasks t = new Tasks();
            o.iduser = ta.id;
            t.name = ta.name;
            t.date = ta.date;
            t.description = ta.description;
            t.idmodul = ta.idmodul = id;
            t.dateAjout = ta.dateAjout = DateTime.Now;
            t.iduser = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ts.Add(t);
            ser.Add(o);
            ts.Commit();
            ser.Commit();
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
