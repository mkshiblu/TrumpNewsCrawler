using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrumpNews.Models
{
    public class TrumpNewsViewModel
    {
        public List<Tweet> Tweets { get; set; }
        public List<Article> Articles { get; set; }

        public TrumpNewsViewModel()
        {
            Tweets = new List<Tweet>();
            Articles = new List<Article>();
        }
    }
}