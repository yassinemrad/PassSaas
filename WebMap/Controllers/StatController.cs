using WebMap.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;
using ServiceMap;
using DomainMap.Entities;
using Rotativa;
using Microsoft.AspNet.Identity;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using System.Drawing.Imaging;
using iTextSharp.text;
using Image = iTextSharp.text.Image;
using Syncfusion.Pdf.Grid;

namespace WebMap.Controllers
{
    public class StatController : Controller
    {
        ITasksService taskService = new TasksService();
        IProjetService projectService = new ProjetService();
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
           
            tempDic = taskService.EtatCount();
            foreach (var element in tempDic)
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
                //value=diccount *** //key=2eme dic
                toDoDP.Add(new DataPoint(item.Value.ToArray()[0].Key.ToString(), item.Value.ToArray()[0].Value));
                doingDP.Add(new DataPoint(item.Value.ToArray()[1].Key, item.Value.ToArray()[1].Value));
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


            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints);
            return View();
        }
        //----------
        public ActionResult categparprojet()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            dataPoints.Add(new DataPoint(Cathegory.Banking.ToString(), projectService.categoriebank()));
            dataPoints.Add(new DataPoint(Cathegory.Commercial.ToString(), projectService.categcountcommer()));
            dataPoints.Add(new DataPoint(Cathegory.Education.ToString(), projectService.categcounteduc()));
            dataPoints.Add(new DataPoint(Cathegory.Medical.ToString(), projectService.categcountmedic()));
            dataPoints.Add(new DataPoint(Cathegory.Statistic.ToString(), projectService.categcountsc()));
            dataPoints.Add(new DataPoint(Cathegory.Autre.ToString(), projectService.categcountautre()));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);



            return View();

        }
        public ActionResult progressproject(int id = 1)
        {

            List<ProjetModels> listP = mapi();
            List<DataPoint> dataPoints = new List<DataPoint>();
            dataPoints.Add(new DataPoint(Models.Etat.ToDo.ToString(), taskService.EtatProgresstodo(id)));
            dataPoints.Add(new DataPoint(Models.Etat.Doing.ToString(), taskService.EtatProgresdoing(id)));
            dataPoints.Add(new DataPoint(Models.Etat.Done.ToString(), taskService.EtatProgressdone(id)));
            // dataPoints.Add(System.Drawing.Printing.PageSetup()

            
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            ViewBag.ListProjet = listP;


            return View();

        }
        public List<ProjetModels> mapi()
        {
            List<ProjetModels> lists = new List<ProjetModels>();
            foreach (var item in projectService.GetAll())
            {
                ProjetModels dvm = new ProjetModels();
                dvm.id = item.id;
                dvm.name = item.name;

                lists.Add(dvm);

            }
            return lists;
        }
        public ActionResult usercountperyear()
        { User h = userservice.GetById(Int32.Parse(User.Identity.GetUserId()));
            //  var s = userservice.getbyuser(User.Identity.GetUserId().);
        //    var r = (WebMap.Models.Role.TeamLeader.ToString());
            //  dvm.Etat = (BibliothequeWeb.Models.Etat)item.Etat;
            //ViewBag.rs = User.Identity.GetUserId();
          //  ViewBag.users = r;
            List<DataPoint> dataPoints = new List<DataPoint>();
            Dictionary<String, int> userdic = new Dictionary<String, int>();
            //   List<Projet> projet = projectService.listproj();

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

        //kol projet 9adh fih mn user

        public ActionResult usercountmsg()
        {
            //  RegisterViewModel a;

            // if (h.Roles.ToString() == "TeamMember") ;
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
       


      


       

      


      
         public ActionResult CreateDocument()
    //    public PdfTemplate CreateTemplate()
        {
            //Create an instance of PdfDocument.
            using (PdfDocument document = new PdfDocument())
            {
                //Add a page to the document
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for the page
                PdfGraphics graphics = page.Graphics;

                //Set the standard font
                //   PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                //Draw the text
                // graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));
                //    using (var src = new Bitmap("C:/Users/ELYES/source/repos/pidev/WebMap/Views/Stat/categparprojet.cshtml"))
                //  using (var bmp = new Bitmap(100, 100, PixelFormat.Format32bppPArgb))
                //using (var src = new Bitmap("c:/temp/trans.png"))
                //   using (var bmp = new Bitmap(100, 100, PixelFormat.Format32bppPArgb))
                // using (var gr = Graphics.FromImage(bmp))
                // {
                //   gr.Clear(Color.Blue);
                //   gr.DrawImage(src, new Rectangle(0, 0, bmp.Width, bmp.Height));
                // bmp.Save("c:/temp/result.png", ImageFormat.Png);
                // }
                PdfDocument pdfDocument = new PdfDocument();
                //Adds a page to the PDF document.
                PdfPage pdfPage = pdfDocument.Pages.Add();

                PdfTemplate template = new PdfTemplate(100, 50);
                //Draws a rectangle into the graphics of the template.
                template.Graphics.DrawRectangle(PdfBrushes.BurlyWood, new System.Drawing.RectangleF(0, 0, 100, 50));
             //   template.Graphics.DrawPie();
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);
                PdfBrush brush = new PdfSolidBrush(Color.Black);
              //  graphics.DrawPdfTemplate(V, PointF.Empty);
                template.Graphics.DrawString("Hello World", font, brush, 5, 5);
                //Draws the template into the page graphics of the document.
                pdfPage.Graphics.DrawPdfTemplate(template, PointF.Empty);
               
                //Saves the document.
            //    pdfDocument.Save("Output.pdf");
                //Close the document
                
                //  graphics.DrawPdfTemplate("categparprojet")
                // Open the document in browser after saving it
               pdfDocument.Save("Output.pdf", HttpContext.ApplicationInstance.Response, HttpReadType.Save);
                pdfDocument.Close(true);
                //   var report = new ActionAsPdf("categparprojet");
                //  return report;
            }
          //  return PdfTemplate=PdfDocument.ProgressEventHandler.Combine(durationtask(),);
          return View();
        }

        //public ActionResult savepdfimg()
        //{
        //    string pdfpath = Server.MapPath("PDFs");
        //    string imagepath = Server.MapPath("Images");
        //    iTextSharp.text.Document doc = new iTextSharp.text.Document();
        //    try
        //    {
        //        iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new System.IO.FileStream(pdfpath + "/Images.pdf", System.IO.FileMode.Create));
        //        doc.Open();

        //        doc.Add(new Paragraph("PNG"));
        //        Image gif = Image.GetInstance(imagepath + "/Chart (1).png");
        //        doc.Add(gif);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log error;
        //    }
        //    finally
        //    {
        //        doc.Close();
        //    }
        //    return View();
        //}

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
        [HttpPost]
        public ActionResult tableaureport()
           // public ActionResult tableaureport(System.Web.HttpPostedFileBase helpSectionImages)
        {
            using (PdfDocument doc = new PdfDocument())
            {
                //Add a page
                PdfPage page = doc.Pages.Add();

                //Create a PdfGrid
                PdfGrid pdfGrid = new PdfGrid();
                               
                //Create a DataTable
                System.Data.DataTable dataTable = new System.Data.DataTable();
                
                //Add columns to the DataTable
                dataTable.Columns.Add("Categories");
                dataTable.Columns.Add("Pourcentages");

                //Add rows to the DataTable
                dataTable.Rows.Add(new object[] { Cathegory.Banking.ToString(), projectService.categoriebank().ToString()+"%" });
                dataTable.Rows.Add(new object[] { Cathegory.Commercial.ToString(), projectService.categcountcommer().ToString() + "%" });
                dataTable.Rows.Add(new object[] { Cathegory.Education.ToString(), projectService.categcounteduc().ToString() + "%" });
                dataTable.Rows.Add(new object[] { Cathegory.Medical.ToString(), projectService.categcountmedic().ToString() + "%" });
                dataTable.Rows.Add(new object[] { Cathegory.Statistic.ToString(), projectService.categcountsc().ToString() + "%" });
                dataTable.Rows.Add(new object[] { Cathegory.Autre.ToString(), projectService.categcountautre().ToString() + "%" });
                

                //Assign data source
                pdfGrid.DataSource = dataTable;

                //Draw grid to the page of PDF document
                pdfGrid.Draw(page, new PointF(10, 10));

                PdfGraphics graphics = page.Graphics;
                

               // chartmodel = new ViewModel();
               // chart1 = new SfChart() { Background = Brushes.White };
               // chart1.PrimaryAxis = new NumericalAxis();
               // chart1.SecondaryAxis = new NumericalAxis()
               // {
               //     EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift
               //};
               // ColumnSeries series = new ColumnSeries();
               // series.ItemsSource = model.Collection;
               // series.XBindingPath = "XValue";
               // series.YBindingPath = "YValue";
               // chart1.Series.Add(series);
               // chart1.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
               // chart1.Arrange(new Rect(new Point(0, 0), chart1.DesiredSize));

               // // Export to PDF
               // System.IO.MemoryStream outStream = new System.IO.MemoryStream();
               // chart1.Save(outStream, new BmpBitmapEncoder());
               //PdfPage page2 = doc.Pages.Add();
               //PdfBitmap img = new PdfBitmap(outStream);
               // page2.Graphics.DrawImage(img, 0, 100, 400, 350);
               //outStream.Close();
                //Save the document
                doc.Save("Output.pdf", HttpContext.ApplicationInstance.Response, HttpReadType.Save); 
            }
            return RedirectToAction("categparprojet");
        }
 


    }

    public class ViewModel
    {
        IProjetService projectService = new ProjetService();

        public List <DataPoint> Collection { get; set; }
        public ViewModel()
        {
            Collection = new List<DataPoint> ();
             
               
            Collection.Add(new DataPoint() { Label = Cathegory.Banking.ToString(), Y = projectService.categoriebank()});
            Collection.Add(new DataPoint() { Label = Cathegory.Autre.ToString(), Y = projectService.categcountautre() });
            Collection.Add(new DataPoint() { Label = Cathegory.Commercial.ToString(), Y = projectService.categcountcommer() });
            Collection.Add(new DataPoint() { Label = Cathegory.Education.ToString(), Y = projectService.categcounteduc() });
            Collection.Add(new DataPoint() { Label = Cathegory.Medical.ToString(), Y = projectService.categcountmedic() });
            Collection.Add(new DataPoint() { Label = Cathegory.Statistic.ToString(), Y = projectService.categcountsc() });
        }
    }
}
