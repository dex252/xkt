using System;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace Server
{
    public class Bootstrap : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            pipelines.BeforeRequest.AddItemToEndOfPipeline(context =>
            {
                Database db = new Database();
                context.Items.Add("db", db);
                db.OpenDatabase();
                return context.Response;
            });

            pipelines.AfterRequest.AddItemToEndOfPipeline(context => { context.GetDb()?.CloseDatabase(); });

            pipelines.OnError += (ctx, e) =>
            {
                Console.WriteLine("Error in database: " + e);
                return null;
            };
        }
    }
}
