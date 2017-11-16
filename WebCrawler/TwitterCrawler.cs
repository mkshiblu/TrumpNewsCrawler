using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using WebCrawler.Entities;
using System.Linq;

namespace WebCrawler
{
    public class TwitterCrawler
    {
        private const string siteUrl = "https://twitter.com";

        public string UserName { get; set; }

        /// <summary>
        /// Maximum Number of tweets matching the keyword to be returned
        /// Default is 10
        /// </summary>
        public int NumberOfTweets { get; set; }

        /// <summary>
        /// URL of the user from where posts will be scrapped
        /// Example: For UserName being 'realDonaldTrump', NumberOfTweets being 25,
        /// this will be returned by this function https://twitter.com/realdonaldtrump?lang-en&count=25
        /// </summary>
        private string constructURL()
        {
            // Replace whitespaces from the keyword with + sign and append to the search url
            return siteUrl
                + "/" + UserName
                + "?count=" + NumberOfTweets;  // TODO: Does not work, use API?
        }

        public TwitterCrawler()
        {
            NumberOfTweets = 10;
            UserName = string.Empty;
        }

        /// <summary>
        /// It searches with the specified UserName and then returns the
        /// result items
        /// </summary>
        /// <returns></returns>
        public List<Tweet> CrawlTweets()
        {
            string url = constructURL();

            // Create a browser
            HtmlWeb web = new HtmlWeb()
            {
                //BrowserDelay = new TimeSpan(0, 0, 0, 2, 0),
                //BrowserTimeout = new TimeSpan(0, 0, 0, 30, 0)

            };


            Console.WriteLine("before load");
            //var document = web.LoadFromBrowser(searchURL);
            var document = web.LoadFromBrowser(url, IsFullyLoaded);

            Console.WriteLine("after load");

            #region TODO parse tweet id etc.
            /* 
            var posts = document.DocumentNode.SelectNodes("//div[contains(@class, 'tweet')]");
            
            //var posts = document.DocumentNode.SelectNodes("//div[contains(@class, 'tweet')][" + NumberOfTweets + "]");

            if (posts != null)
            {
                var tweets = new List<Tweet>();

                // Create entity from each html result item
                foreach (var item in posts)
                {
                    Tweet tweet = new Tweet();

                    //tweet.TweetId = Int32.Parse(item.GetAttributeValue(".data-tweet-id", "-1"));
                    //tweet.TweetText = item.SelectSingleNode(".//p[@class='tweet-text']").InnerText;
                    //tweet.TweetTime = DateTime.Parse(item.SelectSingleNode(".//a[@class='tweet-timestamp']").GetAttributeValue("data-original-title", null));

                    tweets.Add(tweet);
                }


           
                return tweets;
            }*/
            #endregion

            // Select all tweet text for now
            var tweetTexts = document.DocumentNode.SelectNodes("//p[contains(@class, 'tweet-text')]");
            if (tweetTexts != null)
            {
                var tweets = new List<Tweet>();
                foreach (var item in tweetTexts)
                {
                    Tweet tweet = new Tweet();

                    // For now parse only text
                    tweet.Text = item.InnerText;

                    tweets.Add(tweet);
                }

                return tweets;
            }

            return null;
        }

        public bool IsFullyLoaded(Object sender)
        {
            var webBrowser = (System.Windows.Forms.WebBrowser)sender;

            Console.WriteLine("Checking if page is fully loaded...");

            return !webBrowser.IsBusy && webBrowser.ReadyState == System.Windows.Forms.WebBrowserReadyState.Complete;
        }
    }
}
