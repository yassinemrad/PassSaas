using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net.Http;
using WebMap.Models;
using ServiceMap;
using Newtonsoft.Json;

namespace WebMap.Controllers
{
    public class WebapistatController : Controller
    {
        // GET: Webapistat
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:21514");
            client.DefaultRequestHeaders.Accept.Add(
                 new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("webapistat/api").Result;

            List<DataPoint> dataPoints = new List<DataPoint>();
            Dictionary<String, int> tempDic = new Dictionary<String, int>();
            TasksService taskService = new TasksService();
            tempDic = taskService.EtatCount();
            foreach (var element in tempDic)
            {
                dataPoints.Add(new DataPoint(element.Key, element.Value));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

    //        return View();

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Result = response.Content.ReadAsAsync<IEnumerable<DataPoint>>().Result;
            } else
            { ViewBag.Result = "error"; }
        
            
           
       //     Console.ReadLine();
            return View();
        }

        // GET: Webapistat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Webapistat/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Webapistat/Create
        [HttpPost]
        public ActionResult Create(TasksModels collection)
        {
            
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("http://localhost:21514");
                client.PostAsJsonAsync<TasksModels>("webapistat/api", collection).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

                return RedirectToAction("Index");
           
        }

        // GET: Webapistat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Webapistat/Edit/5
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

        // GET: Webapistat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Webapistat/Delete/5
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
