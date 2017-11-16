using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrumpNews.Helpers;
using TrumpNews.Models;

namespace TrumpNews.Controllers
{
    public class HomeController : Controller
    {
        private CrawlingHelper crawlingHelper = new CrawlingHelper();
        public ActionResult Index()
        {
            List<Article> articles = null;
            try
            {
                // Get all articles and post regarding trump using crawler
                articles = crawlingHelper
                   .CrawlArticlesDemo()
                   .OrderByDescending(article => article.PublishDate).ToList();
            }
            catch (Exception ex)
            {
                return PartialView("Error", ex);
            }

            return View(articles);
        }


        // GET: /InvoiceItem/Details/5
        public ActionResult PostDetails(int? id)
        {
            //ViewBag.Message = "Your application description page.";
            // TODO
            return View();
        }
    }
}