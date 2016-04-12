using System;
using System.Web.Http.SelfHost;
using SDSK.API;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = "http://localhost:1994";

            var config = new HttpSelfHostConfiguration(url);
            WebApiConfig.Register(config);

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Use " + url);
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
