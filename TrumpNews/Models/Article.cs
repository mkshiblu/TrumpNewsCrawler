using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrumpNews.Models
{
    /// <summary>
    /// Represents a post or article
    /// </summary>
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public DateTime PublishDate { get; set; }

        // TODO use enum to represent twitter / cnn
        public string Source { get; set; }

        // Original source URL 
        public string Url { get; set; }
    }
}