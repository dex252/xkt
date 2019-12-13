using System.Text;
using Nancy;

namespace Server.Helper
{
    public static class Resp
    {
        public enum ContentType
        {
            json,
            zip,
            xml,
        }

        public static Nancy.Response SendResponse(HttpStatusCode statusCode)
        {
            return new Nancy.Response()
            {
                StatusCode = statusCode
            };
        }

        public static Nancy.Response SendResponse(HttpStatusCode statusCode, string json)
        {
            var jsonBytes = Encoding.UTF8.GetBytes(json);

            return new Nancy.Response()
            {
                StatusCode = statusCode,
                ContentType = "json",
                Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
            };
        }

        public static Nancy.Response SendResponse(HttpStatusCode statusCode, string json, ContentType type)
        {
            var jsonBytes = Encoding.UTF8.GetBytes(json);

            return new Nancy.Response()
            {
                StatusCode = statusCode,
                ContentType = ContentTypeToString(type),
                Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
            };
        }

        private static string ContentTypeToString(ContentType contentType)
        {
            switch (contentType)
            {
                case ContentType.json:
                {
                    return "application/json";
                }

                case ContentType.zip:
                {
                    return "application/zip";
                }

                case ContentType.xml:
                {
                    return "application/xml";
                }

                default:
                {
                    return "application/json";
                }
            }
        }
    }
}
