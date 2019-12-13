using System;
using System.Configuration;
using Microsoft.Owin.Hosting;

namespace Server
{
    class App
    {
        static void Main()
        {
            string url = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.hostConnectionString"].ConnectionString;

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine($"Running on {url}");
                Console.ReadKey();
            }

        }
    }
}
