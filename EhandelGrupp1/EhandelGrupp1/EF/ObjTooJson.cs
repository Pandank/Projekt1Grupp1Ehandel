using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace EhandelGrupp1.EF
{
    public static class ObjTooJson
    {

        public static string ObjToJson(IQueryable<string> query)
        {
            return JsonConvert.SerializeObject(query, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }



        public static string ObjToJson(object query)
        {
            return JsonConvert.SerializeObject(query, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

    }
}