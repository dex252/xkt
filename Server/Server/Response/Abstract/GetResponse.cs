using Nancy;

namespace Server.Response
{
    public abstract class GetResponse<T> : NancyModule
    {
        public Database db;

        public abstract Nancy.Response PostResponse(Request request, Database db);
    }
}
