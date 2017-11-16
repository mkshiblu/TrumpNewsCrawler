using System;

namespace WebCrawler
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            #region CNN Crawler

            Console.WriteLine("Crawling CNN..");
            CNNCrawler cnn = new CNNCrawler()
            {
                Keyword = "Donald Trump",
                NumberOfArticles = 25
            };

            var x = cnn.CrawlCNNSearchResult();

            if (x != null)
            {
                foreach (var item in x)
                {
                    Console.WriteLine(item);
                }
            }
            #endregion

            #region Twitter Crawler
            Console.WriteLine("Crawling Twitter..");

            TwitterCrawler twitter = new TwitterCrawler()
            {
                UserName = "realDonaldTrump",
                NumberOfTweets = 35
            };

            var items = twitter.CrawlTweets();

            if (items != null)
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }

            #endregion

            Console.WriteLine("Process End");
            Console.ReadKey();
        }
    }
}