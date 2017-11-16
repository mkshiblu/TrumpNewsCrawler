using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using WebCrawler.Entities;


namespace WebCrawler
{
    public class CNNCrawler
    {
        private const string searchURL = "https://cnn.com/search/?q=";

        /// <summary>
        /// Keyword to search for
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// Maximum Number of latest Articles matching the keyword to be returned
        /// Default is 10
        /// </summary>
        public int NumberOfArticles { get; set; }

        /// <summary>
        /// URL showing the result of search from which the title, body and link of the article will be scrapped
        /// Example: For keyword being 'Donald Trump', NumberOfArticles being 25,
        /// this will be returned by this function http://cnn.com/search/?q=donald+trump&size=25&sort=newest&type=article
        /// newest and articles are also added to ensure that only the latest articles have to be returned.
        /// </summary>
        private string constructSearchURL()
        {
            // Replace whitespaces from the keyword with + sign and append to the search url
            return searchURL
                + (Keyword.Trim().Replace(' ', '+'))    // Remove extra whitespace and replace space with a + sign from keyword
                + "&size=" + NumberOfArticles
                + "&sort=newest"
                + "&type=article";  // We only want the articles not the videos
        }

        public CNNCrawler()
        {
            NumberOfArticles = 10;
            Keyword = string.Empty;
        }

        /// <summary>
        /// First, it searches with the specified keyword and then returns the
        /// result items
        /// </summary>
        /// <returns></returns>
        public List<CNNSearchResultArticle> GetSearchResult()
        {
            string searchURL = constructSearchURL();

            // Create a browser
            HtmlWeb web = new HtmlWeb()
            {
                //BrowserDelay = new TimeSpan(0, 0, 0, 10, 0),
                //BrowserTimeout = new TimeSpan(0, 0, 0, 30, 0)
            };


            Console.WriteLine("before load");
            //var document = web.LoadFromBrowser(searchURL);
            var document = web.LoadFromBrowser(searchURL, IsFullyLoaded);

            Console.WriteLine("after load");

            // Each search result article is a div with class cnn-search__result--article
            // Find all articles
            var searchResultarticles = document.DocumentNode.SelectNodes("//div[contains(@class, 'cnn-search__result--article')]");
            
            if (searchResultarticles != null)
            {
                var articles = new List<CNNSearchResultArticle>();

                // Create entity from each html result item
                foreach (var item in searchResultarticles)
                {
                    CNNSearchResultArticle article = new CNNSearchResultArticle();

                    article.Thumbnail = item.SelectSingleNode(".//div[@class='cnn-search__result-thumbnail']/a/img").GetAttributeValue("src", null);
                    article.Title = item.SelectSingleNode(".//h3[@class='cnn-search__result-headline']/a").InnerText;
                    article.Body = item.SelectSingleNode(".//div[@class='cnn-search__result-body']").InnerText.TrimStart(); 
                    article.URL = item.SelectSingleNode(".//h3[@class='cnn-search__result-headline']/a").GetAttributeValue("href", null);
                    article.PublishDate = DateTime.Parse(item.SelectSingleNode(".//div[@class='cnn-search__result-publish-date']/span[2]").InnerText);

                    //Console.WriteLine(article);

                    articles.Add(article);
                }

                return articles;
            }

            return null;
        }

        public bool IsFullyLoaded(Object sender)
        {
            var webBrowser = (System.Windows.Forms.WebBrowser) sender;

            Console.WriteLine("Checking if page is fully loaded...");

            return !webBrowser.IsBusy && webBrowser.ReadyState == System.Windows.Forms.WebBrowserReadyState.Complete;
        }
    }
}
