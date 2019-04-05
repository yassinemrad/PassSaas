

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
        public ActionResult AllTasks()
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
                            description = item.description,
                            date = item.date,

                            diff = b,
                            rest = er,



                        });
                    /*   if (differenceInDays == 3)
                      {

                          var senderemail = new MailAddress(FindMailOfUserById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId())), "Rappel");
                          var receiveremail = new MailAddress(FindMailOfUserById(id), "Receiver");
                          var password = FindPasswordOfUserById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()));
                          var sub = "Un rendez-vous";

                          var body = string.Concat("Bonjour je suis votre Docteur Mr/Mme " + FindFirstNameOfUserById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId())) + " " + FindLastNameOfUserById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId())) + " , je voulais vous informer que je vous ai planifié un nouveau rendez-vous avec " + Request["NomMedecin"].ToString() + " Spécialisé en " + Request["Specialite"].ToString() + " veuillez consulter votre parcours et merci d'attendre la confirmation du docteur que je vous ai recommandé");
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
            List<TasksModels> fVm2 = fVM.ToList();
            return View(fVm2);

        }
            //GET:List Affectation
            public ActionResult Affectation()
            {
                Tasks task1 = new Tasks();       
                var Affect = ts.GetAll();
                List<TasksModels> fV = new List<TasksModels>();

                foreach (var item in Affect)
                {
                    fV.Add(
                        new TasksModels
                        {
                            name = item.name,
                            nmod= FindNameModuleById(item.idmodul),
                            nuser= FindFirstNameOfUserById(item.iduser)+" "+ FindLastNameOfUserById(item.iduser),
                            });
                }
                List<TasksModels> f = fV.ToList();
                return View(f);

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
