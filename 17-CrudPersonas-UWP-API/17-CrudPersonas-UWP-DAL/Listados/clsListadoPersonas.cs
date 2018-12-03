using _17_CrudPersonas_UWP_DAL.Conexion;
using _17_CrudPersonas_UWP_Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace _17_CrudPersonas_UWP_DAL.Listados
{
    public class clsListadoPersonas
    {

        /// <summary>
        /// Funcion que nos devuelve un listado de personas.
        /// </summary>
        /// <returns>Listados de personas</returns>
        public async Task<List<clsPersona>> getListadoPersonas() {

            clsUriBase UriApi = new clsUriBase();
            String uri = UriApi.getBaseUrlApi();
          
            Task<List<clsPersona>> lista = null;

            Console.WriteLine("Haciendo una petición al servio de clientes....");

            //se define la url del método de la api.
           
       
            //Se configura la petición.
            HttpWebRequest peticion;
            peticion = WebRequest.Create(uri) as HttpWebRequest;
            peticion.Method = "GET";

            // Respuesta
            try
            {
                HttpWebResponse respuesta;
                //Si la peticion fue correcta
                if ((int)respuesta.StatusCode == 200)
                {
                    var reader = new StreamReader(respuesta.GetResponseStream());
                    string s = reader.ReadToEnd();
                    var arr = JsonConvert.DeserializeObject(s);
                    Console.WriteLine(arr.ToString());
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }





        }

    }
}
