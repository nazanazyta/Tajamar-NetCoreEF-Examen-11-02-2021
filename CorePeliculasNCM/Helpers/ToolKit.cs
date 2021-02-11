using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePeliculasNCM.Helpers
{
    public class ToolKit
    {
        //MÉTODO QUE RECIBIRÁ UN OBJETO Y LO TRANSFORMARÁ EN String Json
        public static String SerializeJsonObject(Object objeto)
        {
            String respuesta = JsonConvert.SerializeObject(objeto);
            return respuesta;
        }

        //MÉTODO QUE RECIBIRÁ UN String Json Y DEVOLVERÁ EL OBJETO
        //QUE REPRESENTA DICHO JSON
        public static T DeserializeJsonObject<T>(String json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
