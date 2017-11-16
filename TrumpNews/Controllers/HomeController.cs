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
            TrumpNewsViewModel tnViewModel = new TrumpNewsViewModel();
            try
            {
                List<Article> articles = null;
                List<Tweet> tweets = null;

                // Get all articles regarding trump using crawler
                articles = crawlingHelper
                   .CrawlArticlesDemo()
                   .OrderByDescending(article => article.PublishDate).ToList();

                // Get all tweets posted by trump
                tweets = crawlingHelper
                    .CrawlTweetsDemo()
                    .OrderByDescending(t => t.PublishTime).ToList();

                tnViewModel.Articles = articles;
                tnViewModel.Tweets = tweets;

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return PartialView("Error");
            }

            return View(tnViewModel);
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