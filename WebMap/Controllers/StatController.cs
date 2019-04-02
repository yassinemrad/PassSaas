using WebMap.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;
using ServiceMap;

namespace WebMap.Controllers
{
    public class StatController : Controller
    {
        ITasksService taskService = new TasksService();
      //  IProjetService projectService = new ProjetService();
        IUserService userservice = new UserService();
     //   ImessageService mesgService = new messageService();
        
        
        
        // GET: Stat
        public ActionResult Index()
        {
            
            return View();
        }
        // GET : Home
        public ActionResult Home()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            Dictionary<String, int> tempDic = new Dictionary<String, int>();
          //  List<projet> projet = projectService.listproj();
            //foreach (var item in collection)
            //{

            //}
            tempDic = taskService.EtatCount();
            foreach(var element in tempDic)
            {
                dataPoints.Add(new DataPoint(element.Key, element.Value));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
        public ActionResult usercount()
        {
            Dictionary<String, Dictionary<String, int>> diccount = taskService.etatCountUser();
            List<String> username = new List<String>();
            List<DataPoint> toDoDP = new List<DataPoint>();
            List<DataPoint> doingDP = new List<DataPoint>();
            List<DataPoint> doneDP = new List<DataPoint>();
            foreach (var item in diccount)
            {
                username.Add(item.Key);
                toDoDP.Add(new DataPoint(item.Value.ToArray()[0].Key.ToString(), item.Value.ToArray()[0].Value));
                doingDP.Add(new DataPoint(item.Value.ToArray()[1].Key.ToString(), item.Value.ToArray()[1].Value));
                doneDP.Add(new DataPoint(item.Key, item.Value.ToArray()[2].Value));
            }
            ViewBag.NameList = JsonConvert.SerializeObject(username);
            ViewBag.ToDoDPS = JsonConvert.SerializeObject(toDoDP);
            ViewBag.DoingDPS = JsonConvert.SerializeObject(doingDP);
            ViewBag.DoneDPS = JsonConvert.SerializeObject(doneDP);

            return View();
        }
        //------------
        public ActionResult durationtask()
        {
            List<int> arrDuration = new List<int>();
            List<String> arrName = new List<String>();
            List<DataPoint> dataPoints = new List<DataPoint>();

            var listtache = taskService.listtache();
            foreach (var tache in listtache)
            {

                dataPoints.Add(new DataPoint(tache.name, tache.realDuration));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }
        //----------
        public ActionResult categparprojet()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
        //    dataPoints.Add(new DataPoint(Cathegory.Banking.ToString(),projectService.categoriebank() ));
          //  dataPoints.Add(new DataPoint(Cathegory.Commercial.ToString(), projectService.categcountcommer()));
            //dataPoints.Add(new DataPoint(Cathegory.Education.ToString(), projectService.categcounteduc()));
            //dataPoints.Add(new DataPoint(Cathegory.Medical.ToString(), projectService.categcountmedic()));
          //  dataPoints.Add(new DataPoint(Cathegory.Statistic.ToString(), projectService.categcountsc()));
            //dataPoints.Add(new DataPoint(Cathegory.Autre.ToString(), projectService.categcountautre()));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);



            return View();
                
        }
        public ActionResult progressproject(int id = 1)
        {
            
           // List<ProjetViewModel> listP = mapi();
            List<DataPoint> dataPoints = new List<DataPoint>();
            //dataPoints.Add(new DataPoint(Etat.Todo.ToString(), etatService.EtatProgresstodo(id)));
           // dataPoints.Add(new DataPoint(Etat.Doing.ToString(), etatService.EtatProgresdoing(id)));
           // dataPoints.Add(new DataPoint(Etat.done.ToString(), etatService.EtatProgressdone(id)));
           

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

         //   ViewBag.ListProjet = listP;
          

                return View();

        }
      //  public List<ProjetViewModel> mapi()
        //{
          //  List<ProjetViewModel> lists = new List<ProjetViewModel>();
            //foreach (var item in projectService.GetAll())
           // {
             //   ProjetViewModel dvm = new ProjetViewModel();
         //       dvm.id = item.id;
           //     dvm.name = item.name;
              
             //   lists.Add(dvm);

         //   }
           // return lists;
       // }
        public ActionResult usercountperyear()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            Dictionary<String, int> userdic = new Dictionary<String, int>();
            //  List<projet> projet = projectService.listproj();
            //foreach (var item in collection)
            //{

            //}
            userdic = userservice.userdate();
            foreach (var element in userdic)
            {
                dataPoints.Add(new DataPoint(element.Key.ToString(), element.Value));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();

        }
        public ActionResult usercountmsg()
        {
          //  RegisterViewModel a;
           
            List<DataPoint> dataPoints = new List<DataPoint>();
            Dictionary<String, double> msgdiccountmsg = new Dictionary<String, double>();
            //  List<projet> projet = projectService.listproj();
            //foreach (var item in collection)
            //{

            //}
         //   msgdiccountmsg = mesgService.countmessage("jrad");
           // foreach (var element in msgdiccountmsg)
           // {
             //   dataPoints.Add(new DataPoint(element.Key.ToString(), element.Value));
           // }

           // ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();

        }
            // GET: Stat/Details/5
            public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stat/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stat/Edit/5
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

        // GET: Stat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stat/Delete/5
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
