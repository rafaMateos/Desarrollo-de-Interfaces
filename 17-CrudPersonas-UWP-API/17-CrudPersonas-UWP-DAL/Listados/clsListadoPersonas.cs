using _17_CrudPersonas_UWP_DAL.Conexion;
using _17_CrudPersonas_UWP_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace _17_CrudPersonas_UWP_DAL.Listados
{
    public class clsListadoPersonas
    {

        /// <summary>
        /// Funcion que nos devuelve un listado de personas.
        /// </summary>
        /// <returns>Listados de personas</returns>
        public async void getListadoPersonas() {

            /*
            clsUriBase gestoriaApi = new clsUriBase();
            String uri = gestoriaApi.getBaseUrlApi();
            Uri UriApi = new Uri(uri);
            List<clsPersona> lista = null;
            Byte[] devuelveAlgoPorfa;
            clsPersona newPer;
            Formatting bf = new Formatting();
            string ret;

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(UriApi); //

            devuelveAlgoPorfa = await response.Content.ReadAsByteArrayAsync(); //


            for (int i = 0; i < devuelveAlgoPorfa.Count(); i++) {

               

            }

            */
            clsUriBase gestoriaApi = new clsUriBase();

            Console.WriteLine("Haciendo una petición al servio de clientes....");

            //se define la url del método de la api.
            String uri = gestoriaApi.getBaseUrlApi();
            Uri URL = new Uri(uri);

            //Se configura la petición.
            WebRequest peticion;
            peticion = WebRequest.Create(URL);
           
            peticion.Method = "GET";

            // Respuesta
            try
            {
                WebResponse respuesta = await peticion.GetResponseAsync();
                //Si la peticion fue correcta
              
                
                    var reader = new StreamReader(respuesta.GetResponseStream());
                    string s = reader.ReadToEnd();
                    var arr = JsonConvert.DeserializeObject(s);
                    
                 
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           




        }

       

    }
}
