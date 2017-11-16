﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrumpNews.Models;
using WebCrawler;

namespace TrumpNews.Helpers
{
    public class CrawlingHelper
    {
        private CNNCrawler cnnCrawler;

        // TODO use dictionary or use db
        // Returns a cached version without re-crawling
        public List<Article> Articles { get; set; }

        public string CNNSearchKeyword { get; set; }
        public string TwitterUserName { get; set; }
        public int NumberOfCNNArticles { get; set; }
        public int NumberOfTwitterPosts { get; set; }

        public CrawlingHelper()
        {
            CNNSearchKeyword = "Donuld Trump";
            NumberOfCNNArticles = 25;
            TwitterUserName = "TODO";
            NumberOfTwitterPosts = 25;

            // Create crawler with this value
            cnnCrawler = new CNNCrawler()
            {
                Keyword = CNNSearchKeyword,
                NumberOfArticles = NumberOfCNNArticles
            };
        }

        /// <summary>
        /// Refersh the Article properly with the newly fetched data
        /// </summary>
        /// <returns></returns>
        public List<Article> CrawlArticles()
        {
            // Create new articles for refreshing

            Articles = new List<Article>();

            #region get cnn news

            // Set cnn variables
            cnnCrawler.Keyword = CNNSearchKeyword;
            cnnCrawler.NumberOfArticles = NumberOfCNNArticles;

            // Get the crawled items
            var cnnItems = cnnCrawler.GetSearchResult();

            // For incremental id
            int id = 0;

            foreach (var item in cnnItems)
            {
                Article article = new Article()
                {
                    Id = ++id,
                    Title = item.Title,
                    Body = item.Body,
                    Url = item.URL,
                    PublishDate = item.PublishDate,
                    Source = "CNN"
                };
            }
            #endregion

            #region get Twitter posts
            // TODO
            #endregion

            return Articles;
        }

        // Demo offline crawling
        public List<Article> CrawlArticlesDemo()
        {
            Articles = new List<Article>();


            Articles.Add(new Article()
            {
                Id = 5,
                Title = "Donald Trump 2",
                Body = "Rohinga Issue",
               // Url = item.URL,
                //PublishDate = item.PublishDate,
                Source = "CNN"
            });

            Articles.Add(new Article()
            {
                Id = 2,
                Title = "Can Sessions actually run for his old Senate seat",
                Body = "Sen. Marco Rubio had a chance at payback Wednesday, when President Donald Trump noticeably sipped from a water boSen. Marco Rubio had a chance at payback Wednesday, when President Donald Trump noticeably sipped from a water bo",
                Url = "//www.cnn.com/2017/11/15/politics/state-department-staff-mccain-shaheen/index.html",
                PublishDate = DateTime.Now,
                Source = "CNN"
            });
            return Articles;
        }
    }
}