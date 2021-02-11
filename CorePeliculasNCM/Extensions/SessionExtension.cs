using CorePeliculasNCM.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePeliculasNCM.Extensions
{
    public static class SessionExtension
    {
        //QUÉ NECESITAMOS??
        //LO QUE QUEREMOS ES PODER ALMACENAR
        //CUALQUIER OBJETO EN SESSION
        //DEBEMOS RECIBIR (COMO PRIMER PARÁMETRO)
        //EL OBJETO QUE ESTAMOS EXTENDIENDO (ISession)
        public static void SetObject
            (this ISession session, String key, object value)
        {
            //CUANDO ALMACENAMOS ALGO EN Session
            //QUÉ NECESITAMOS?? UNA CLAVE Y UN VALUE
            //HttpContext.Session.SetString("key", value)
            String data = ToolKit.SerializeJsonObject(value);
            session.SetString(key, data);
        }

        public static T GetObject<T>(this ISession session, String key)
        {
            //TENEMOS UN STRING (JSON) GUARDADO
            //QUÉ DEBERÍAMOS HACER??
            //DEVOLVER EL OBJETO MAPEADO DE DICHO STRING
            //var algo = HttpContext.Session.GetObject<T>("key");
            //RECUPERAMOS EL Json ALMACENADO EN Session
            String data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            return ToolKit.DeserializeJsonObject<T>(data);
        }
    }
}
