using System;
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
        private TwitterCrawler twitterCrawler;

        // TODO use dictionary or use db
        // Returns a cached version without re-crawling
        public List<Article> Articles { get; set; }
        public List<Tweet> Tweets { get; set; }

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

            twitterCrawler = new TwitterCrawler()
            {
                UserName = TwitterUserName,
                NumberOfTweets = NumberOfTwitterPosts
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

            // Set cnn variables
            cnnCrawler.Keyword = CNNSearchKeyword;
            cnnCrawler.NumberOfArticles = NumberOfCNNArticles;

            // Get the crawled items
            var cnnItems = cnnCrawler.CrawlCNNSearchResult();

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
                };

                Articles.Add(article);
            }

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
            });

            Articles.Add(new Article()
            {
                Id = 2,
                Title = "Can Sessions actually run for his old Senate seat",
                Body = "Sen. Marco Rubio had a chance at payback Wednesday, when President Donald Trump noticeably sipped from a water boSen. Marco Rubio had a chance at payback Wednesday, when President Donald Trump noticeably sipped from a water bo",
                Url = "//www.cnn.com/2017/11/15/politics/state-department-staff-mccain-shaheen/index.html",
                PublishDate = DateTime.Now,
            });
            return Articles;
        }


        public List<Tweet> CrawlTweets()
        {
            // Create new articles for refreshing
            Tweets = new List<Tweet>();

            // Set cnn variables
            twitterCrawler.UserName = TwitterUserName;
            twitterCrawler.NumberOfTweets = NumberOfTwitterPosts;

            // Get the crawled items
            var items = twitterCrawler.CrawlTweets();

            foreach (var item in items)
            {
                Tweet t = new Tweet()
                {
                    Text = item.Text,
                    PublishTime = item.TweetTime
                };

                Tweets.Add(t);
            }

            return Tweets;
        }

        public List<Tweet> CrawlTweetsDemo()
        {
            Tweets = new List<Tweet>();


            Tweets.Add(new Tweet()
            {
                Text = "Thank you to our GREAT Military/Veterans and @PacificCommand. Remember #PearlHarbor. Remember the @USSArizona!"
                // Url = item.URL,
                //PublishDate = item.PublishDate,
            });

            Tweets.Add(new Tweet()
            {
                Text = "Thank you to our GREAT Military/Veterans and @PacificCommand. Remember #PearlHarbor. Remember the @USSArizona!",
                PublishTime = DateTime.Now,
            });
            return Tweets;
        }
    }
}