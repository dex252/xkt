using System;
using Nancy;

namespace Server
{
    public static class Extensions
    {
        /// <summary>
        /// Вспомогательная функция чтобы вытащить из контекста GetDb
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Database GetDb(this NancyContext context)
        {
            if (context != null && context.Items.ContainsKey("db"))
            {
                return (Database)context.Items["db"];
            }

            Console.WriteLine("Can`t get database from context");
            return null;
        }
    }
}
