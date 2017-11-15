using System;

namespace WebCrawler
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
           // IronScrapperDemo.Start(null);

            
            CNNCrawler cnn = new CNNCrawler()
            {
                Keyword = "Donald Trump",
                NumberOfArticles = 25
            };
            
            var x = cnn.GetSearchResult();

            /*
            foreach (var item in x)
            {
                Console.WriteLine(item);
            }*/
            
            Console.WriteLine("kjas");
            Console.ReadKey();
        }
    }
}