using System;
using System.Linq;
using Microsoft.Owin.Hosting;

namespace WebCatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var port = args.Any() ? args[0] : "1234";
            var uri = string.Format("http://localhost:{0}/", port);

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("==============================================================");
                Console.WriteLine("Web Catcher Started on port " + port + ". Press any key to exit...");
                Console.ReadKey();
                Console.WriteLine("Stopping Web Catcher");
                Console.WriteLine("==============================================================");
            }
        }
    }
}
