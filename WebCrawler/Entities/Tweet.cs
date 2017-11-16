using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Entities
{
    public class Tweet
    {
        public int TweetId { get; set; }
        public string Text { get; set; }
        public DateTime TweetTime { get; set; }

        public override string ToString()
        {
            return "Text: " + Text;
        }
    }
}
