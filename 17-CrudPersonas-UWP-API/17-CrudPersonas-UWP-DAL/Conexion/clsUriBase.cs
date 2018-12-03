using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_CrudPersonas_UWP_DAL.Conexion
{
   public class clsUriBase
    {

       private String _URL_API = "rafaapirestpersona.azurewebsites.net/api/";

        /// <summary>
        /// Devuelve un string con la uri base de la api
        /// </summary>
        /// <returns>Url de la api</returns>
        public String getBaseUrlApi() { 
            return _URL_API;
    }

    }
}
