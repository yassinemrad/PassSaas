using DomainMap.Entities;
using Microsoft.AspNet.Identity;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;

namespace WebMap.Controllers
{
    [ValidateInput(false)]
    public class ForumController : Controller
    {
        ForumService fs = new ForumService();
        // GET: Forum
        public ActionResult AllForum()
        {
            var User = new User();
            List<Models.ForumModels> lists = new List<Models.ForumModels>();
            foreach (var item in fs.GetAll())
            {
                Models.ForumModels dvm = new Models.ForumModels();
                dvm.Id = item.Id;

                dvm.Title = item.Title;

                dvm.Contenu = item.Contenu;
                dvm.Date = DateTime.Now;
                var user = User.UserName;
                dvm.Author = user;
                    
                dvm.Categorie = (WebMap.Models.Categorie)item.Categorie;
                //dvm.Etat.Equals(item.Etat);
                lists.Add(dvm);

            }
            return View(lists);
            //var forum = fs.GetAll();


            //List<ForumModels> fVM = new List<ForumModels>();

            //foreach (var item in forum)
            //{
            //    fVM.Add(
            //        new ForumModels
            //        {

            //            Id = item.Id,
            //            Title = item.Title,
            //           // Subtitle = item.Subtitle,
            //            //Categorie = 
            //            Author = User.Identity.Name,
            //            Contenu = item.Contenu,
            //        });
            //}
            //List<ForumModels> fVm2 = fVM.ToList();
            //return View(fVm2);
        }
        //{
        //return View();
        // }

        // GET: Forum/Details/5
        public ActionResult Details(int id)
        {
            var pr = fs.GetById(id);


            WebMap.Models.ForumModels bvm = new WebMap.Models.ForumModels();
            //bvm.cathegory = (WebMap.Models.Cathegory)pr.cathegory;

            bvm.Title = pr.Title;
            bvm.Date = pr.Date;

            bvm.Contenu = pr.Contenu;

            bvm.Categorie = (WebMap.Models.Categorie)pr.Categorie;

            return View(bvm);
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forum/Create
        [HttpPost]
        public ActionResult Create(Forum forum)
        {
           Forum f = new Forum() { Categorie = forum.Categorie };

            f.Id = forum.Id;
            f.Title = forum.Title;
            f.Contenu = forum.Contenu;

            fs.Add(f);
            fs.Commit();

            return RedirectToAction("AllForum");
        }

        //  f.Id = forum.Id;
        //  f.Title = forum.Title;
        //  f.Contenu = forum.Contenu;
        //// f.Categorie = (DomainMap.Entities.Categorie)forum.Categorie;
        //  //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
        //  //Image.SaveAs(path);
        //  //f.Image= Image.FileName;
        //  fs.Add(f);
        //  fs.Commit();
        //  return RedirectToAction("AllForum");
    
    //Forum t = new Forum();
    //t.Contenu = fa.Contenu;
    //t.Title = fa.Title;
    ////t.Categorie = fa.Categorie;

    //fs.Add(t);
    //fs.Commit();

    //return RedirectToAction("AllForum");


    // GET: Forum/Edit/5
        public ActionResult Edit(int id)
        {
            var bib = fs.GetById(id);


            WebMap.Models.ForumModels bvm = new WebMap.Models.ForumModels(); ;
            bvm.Title = bib.Title;
            bvm.Contenu = bib.Contenu;
            
            bvm.Categorie.Equals(bib.Categorie);
            return View(bvm);
        }

        // POST: Forum/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, WebMap.Models.ForumModels DVM, HttpPostedFileBase Image)
        {

            Forum d = fs.GetById(id);
            d.Id = DVM.Id;
            d.Title = DVM.Title;
            //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            //Image.SaveAs(path);
            //d.Image = Image.FileName;
            //d.Photo =DVM.Photo;
            d.Categorie = (DomainMap.Entities.Categorie)DVM.Categorie;
            fs.Update(d);
            fs.Commit();
            return RedirectToAction("AllForum");
        }

        // GET: Forum/Delete/5
        public ActionResult Delete(int id)
        {
             var bib = fs.GetById(id);


            WebMap.Models.ForumModels bvm = new WebMap.Models.ForumModels(); 
            //DomainMap.Entities.Projet d = new DomainMap.Entities.Projet() { cathegory = bib.cathegory };

            //bvm.cathegory = bib.cathegory;
            bvm.Id = bib.Id;

            bvm.Title = bib.Title;
            bvm.Date = bib.Date;
            bvm.Author = bib.Author;
            bvm.Contenu = bib.Contenu;

            bvm.Categorie.Equals(bib.Categorie);


            return View(bvm);
        }

        // POST: Forum/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ForumModels DVM)
        {
            var bib = fs.GetById(id);


            WebMap.Models.ForumModels bvm = new WebMap.Models.ForumModels();
            //DomainMap.Entities.Projet d = new DomainMap.Entities.Projet() { cathegory = bib.cathegory };

            //bvm.cathegory = bib.cathegory;
            bvm.Id = bib.Id;

            bvm.Title = bib.Title;
            bvm.Date = bib.Date;
            bvm.Author = bib.Author;
            bvm.Contenu = bib.Contenu;

            bvm.Categorie.Equals(bib.Categorie);
            return View(bvm);
        }
    }
    }

