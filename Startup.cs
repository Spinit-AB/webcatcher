using System;
using System.IO;
using System.Text;
using Microsoft.Owin;
using Owin;

namespace WebCatcher
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                WriteRequest(context.Request);
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = 200;
                return context.Response.WriteAsync("Web Catcher says: Thank you!");
            });
        }

        protected void WriteRequest(IOwinRequest request)
        {
            var defaultForegroundColor = Console.ForegroundColor;
            Console.WriteLine("---------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(request.Method);
            Console.Write(" {0}\r\n", request.Uri.AbsoluteUri);
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("---------------------------------------------------------------");
            using (var reader = new StreamReader(request.Body))
            {
                Console.WriteLine(reader.ReadToEnd());
            }

            Console.WriteLine("---------------------------------------------------------------");
        }
    }
}