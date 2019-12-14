using System;
using System.Collections.Generic;
using Dapper;
using Nancy;
using Server.Helper;
using Server.Models;

namespace Server.Response
{
    public class GetManifest : GetResponse<List<LocoData>>
    {
        public override Nancy.Response PostResponse(Request request, Database db)
        {
            this.db = db;
            var response = GetResponse();

            if (response != null)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(response);

                return Resp.SendResponse(HttpStatusCode.OK, json);
            }

            return Resp.SendResponse(HttpStatusCode.BadRequest);
        }

        private List<LocoData> GetResponse()
        {
            try
            {
                var sql = "SELECT " +
                          "full_sql_locodataseconds.loco_id, " +
                          "full_sql_loco.type_loco_id, " +
                          "full_sql_locodataseconds.timestamp, " +
                          "full_sql_locodataseconds.rpm_diesel, " +
                          "full_sql_locodataseconds.power_generator, " +
                          "full_sql_locodataseconds.poz_kont_sec " +
                          "FROM " +
                          "full_sql_locodataseconds, " +
                          "full_sql_loco " +
                          "WHERE " +
                          "full_sql_locodataseconds.poz_kont_sec>9 " +
                          "AND " +
                          "full_sql_locodataseconds.loco_id=full_sql_loco.id " +
                          "AND full_sql_locodataseconds.rpm_diesel>=500 " +
                          "AND full_sql_locodataseconds.power_generator>=400;";

                List<LocoData> response = db.Db.Query<LocoData>(sql, null, null, true, 300).AsList();
                
                Console.WriteLine("Get manifest");

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


//var sql = "SELECT " +
//          "full_sql_locodataseconds.loco_id, " +
//          "full_sql_loco.type_loco_id, " +
//          "full_sql_locodataseconds.timestamp, " +
//          "full_sql_locodataseconds.rpm_diesel, " +
//          "full_sql_locodataseconds.power_generator, " +
//          "full_sql_locodataseconds.poz_kont_sec " +
//          "FROM " +
//          "full_sql_locodataseconds, " +
//          "full_sql_loco " +
//          "WHERE " +
//          "full_sql_locodataseconds.poz_kont_sec>9 " +
//          "AND " +
//          "full_sql_locodataseconds.loco_id=full_sql_loco.id " +
//          "AND full_sql_locodataseconds.rpm_diesel>=500 " +
//          "AND full_sql_locodataseconds.power_generator>=400;";

//var sql = "SELECT " +
//            "full_sql_locodataseconds.loco_id, " +
//            "full_sql_loco.type_loco_id, " +
//            "full_sql_locodataseconds.timestamp, " +
//            "full_sql_locodataseconds.rpm_diesel, " +
//            "full_sql_locodataseconds.power_generator, " +
//            "full_sql_locodataseconds.poz_kont_sec " +
//                "FROM " +
//                "full_sql_locodataseconds, " +
//                "full_sql_loco " +
//                    "WHERE " +
//                    "full_sql_locodataseconds.poz_kont_sec>9 " +
//                        "AND " +
//                        "full_sql_locodataseconds.loco_id=full_sql_loco.id;";
