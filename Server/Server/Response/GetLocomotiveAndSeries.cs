using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Nancy;
using Server.Helper;
using Server.Models;

namespace Server.Response
{
    public class GetLocomotiveAndSeries : GetResponse<List<LocomotiveAndSeries>>
    {
        public override Nancy.Response PostResponse(Request request, Database db)
        {
            this.db = db;
            var response = GetResponse();

            if (response != null)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(response);

                var jsonBytes = Encoding.UTF8.GetBytes(json);

                return new Nancy.Response()
                {
                    StatusCode = HttpStatusCode.OK,
                    ContentType = "json",
                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
                };
               // return Resp.SendResponse(HttpStatusCode.OK, json);
            }

            return Resp.SendResponse(HttpStatusCode.BadRequest);
        }

        private List<LocomotiveAndSeries> GetResponse()
        {
            try
            {
                var sql = "SELECT " +
                          "full_sql_loco.num_loco, " +
                          "full_sql_loco.num_sec, " +
                          "full_sql_loco.type_loco_id, " +
                          "full_sql_locotype.num, " +
                          "full_sql_locotype.name " +
                          "FROM " +
                          "full_sql_loco, " +
                          "full_sql_locotype " +
                          "WHERE " +
                          "full_sql_loco.type_loco_id=full_sql_locotype.id; ";

                List<LocomotiveAndSeries> response = db.Db.Query<LocomotiveAndSeries>(sql, null, null, true, 100).AsList();

                Console.WriteLine("Get Locomotiv&Series");

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);

                return null;
            }
        }
    }
}
