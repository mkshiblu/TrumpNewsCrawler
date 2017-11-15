using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Entities
{
    public class CNNSearchResultArticle
    {
        /// <summary>
        /// URL of the thumbnail
        /// </summary>
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// URL of the article
        /// </summary>
        public string URL { get; set; }

        public override string ToString()
        {
            return "Title: " + Title + " PublishDate: " + PublishDate + " URL: " + URL + " Thumbnail: " + Thumbnail + " Body: " + Body.Substring(0, 10);
        }

    }
}
