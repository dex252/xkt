using Nancy;
using Server.Response;

namespace Server.Module
{
    public abstract class MainModule<T> : NancyModule
    {
        protected MainModule(string pathToRequest, GetResponse<T> mainJsonMethod)
        {
            Post($"/{pathToRequest}", param =>
            {
                var request = Context.Request;
                Database db = Context.GetDb();

                return mainJsonMethod.PostResponse(request,  db);
            });
        }
    }
}
