using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RssNewsEngine.Models;
using RssNewsEngine.Properties;

namespace RssNewsEngine.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EnterNews()
        {
            return View();
        }
        public ActionResult Multimedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload()
        {
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                System.Diagnostics.Debug.WriteLine(hpf.FileName);
            }

            return View();
        }
        [HttpPost]
        public ActionResult EnterNews(NewsComponents newscomponents)
        {

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;
                Images images = new Images();
                images.fileName = Convert.ToString(Guid.NewGuid()) + hpf.FileName;
                images.photostreams = hpf.InputStream;
                switch (newscomponents.Country)
                {
                    case "Kenya":

                        images.Url = Settings.Default.BucketNameURL + "/kenya/" + images.fileName;
                        break;
                    case "Malawi":
                        images.Url = Settings.Default.BucketNameURL + "/malawi/" + images.fileName;
                        break;
                    case "Tanzania":
                        images.Url = Settings.Default.BucketNameURL + "/tanzania/" + images.fileName;
                        break;
                    case "Uganda":
                        images.Url = Settings.Default.BucketNameURL + "/uganda/" + images.fileName;
                        break;
                    case "Zambia":
                        images.Url = Settings.Default.BucketNameURL + "/zambia/" + images.fileName;
                        break;
                    case "Zimbabwe":
                        images.Url = Settings.Default.BucketNameURL + "/zimbabwe/" + images.fileName;
                        break;
                }

                // images.Url=Settings.Default.
                newscomponents.Images.Add(images);
            }
            
            newscomponents.NewsAdded = DateTime.Now;
            newscomponents.NewsID = Guid.NewGuid();
            newscomponents.NewsItem = Server.HtmlEncode(newscomponents.NewsItem);

            switch (newscomponents.Country)
            {
                case "Kenya":
                    newscomponents.BucketName = Settings.Default.BucketName + "/" + Settings.Default.Kenya;
                    newscomponents.Summary = Settings.Default.BucketNameURL + "/" + Settings.Default.Kenya + "/" + newscomponents.NewsID;
                    NewsEngine.LoadNewsintoTables(newscomponents, Settings.Default.Kenya);
                    break;
                case "Malawi":
                    newscomponents.BucketName = Settings.Default.BucketName + "/" + Settings.Default.Malawi;
                    newscomponents.Summary = Settings.Default.BucketNameURL + "/" + Settings.Default.Malawi + "/" + newscomponents.NewsID;
                    NewsEngine.LoadNewsintoTables(newscomponents, Settings.Default.Malawi);

                    break;
                case "Tanzania":
                    newscomponents.BucketName = Settings.Default.BucketName + "/" + Settings.Default.Uganda;
                    newscomponents.Summary = Settings.Default.BucketNameURL + "/" + Settings.Default.Uganda + "/" + newscomponents.NewsID;
                    NewsEngine.LoadNewsintoTables(newscomponents, Settings.Default.Tanzania);
                    break;
                case "Uganda":
                    newscomponents.BucketName = Settings.Default.BucketName + "/" + Settings.Default.Uganda;
                    newscomponents.Summary = Settings.Default.BucketNameURL + "/" + Settings.Default.Uganda + " /" + newscomponents.NewsID;
                    NewsEngine.LoadNewsintoTables(newscomponents, Settings.Default.Uganda);
                    break;
                case "SouthAfrica":
                    newscomponents.BucketName = Settings.Default.BucketName + "/" + Settings.Default.SouthAfrica;
                    newscomponents.Summary = Settings.Default.BucketNameURL + "/" + Settings.Default.SouthAfrica + " /" + newscomponents.NewsID;
                    NewsEngine.LoadNewsintoTables(newscomponents, Settings.Default.SouthAfrica);
                    break;
                case "Bostwana":
                    newscomponents.BucketName = Settings.Default.BucketName + "/" + Settings.Default.Bostwana;
                    newscomponents.Summary = Settings.Default.BucketNameURL + "/" + Settings.Default.Bostwana + " /" + newscomponents.NewsID;
                    NewsEngine.LoadNewsintoTables(newscomponents, Settings.Default.SouthAfrica);
                    break;
                case "Zambia":
                    newscomponents.BucketName = Settings.Default.BucketName + "/" + Settings.Default.Zambia;
                    newscomponents.Summary = Settings.Default.BucketNameURL + "/" + Settings.Default.Zambia + "/" + newscomponents.NewsID;
                    NewsEngine.LoadNewsintoTables(newscomponents, Settings.Default.Zambia);
                    break;
                case "Zimbabwe":
                    newscomponents.BucketName = Settings.Default.BucketName + "/" + Settings.Default.Zimbabwe;
                    newscomponents.Summary = Settings.Default.BucketNameURL + "/" + Settings.Default.Zimbabwe + "/" + newscomponents.NewsID;
                    NewsEngine.LoadNewsintoTables(newscomponents, Settings.Default.Zimbabwe);
                    break;
            }


            return View();
        }
        //
        // GET: /News/Details/5
        [HttpPost]
        public ActionResult Multimedia(Multimedia multimedia)
        {
            multimedia.VideoId = Guid.NewGuid();
            switch (multimedia.Country)
            {
                case "Kenya":
                  NewsEngine.SaveMultimedia(multimedia,Settings.Default.KenyaVideo);
                    break;
                case "Malawi":

                    NewsEngine.SaveMultimedia(multimedia, Settings.Default.MalawiVideo);
                    break;
                case "Tanzania":
                    NewsEngine.SaveMultimedia(multimedia, Settings.Default.TanzaniaVideo);
                    break;
                case "Uganda":
                    NewsEngine.SaveMultimedia(multimedia, Settings.Default.UgandaVideo);
                    break;
                case "SouthAfrica":
                    NewsEngine.SaveMultimedia(multimedia, Settings.Default.SouthAfricaVideo);
                    break;
                case "Bostwana":
                    NewsEngine.SaveMultimedia(multimedia, Settings.Default.BostwanaVideo);
                    break;
                case "Zambia":
                    NewsEngine.SaveMultimedia(multimedia, Settings.Default.ZambiaVideo);
                    break;
                case "Zimbabwe":
                    NewsEngine.SaveMultimedia(multimedia, Settings.Default.ZimbabweVideo);
                    break;
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /News/Create

        public ActionResult Create()
        {
            return View();
        }



        // POST: /News/Create
        [HttpPost]
        public ActionResult Save(NewsComponents news)
        {

            return View();
        }
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

        //
        // GET: /News/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /News/Edit/5

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

        //
        // GET: /News/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /News/Delete/5

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
