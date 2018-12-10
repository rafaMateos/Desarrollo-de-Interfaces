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
using System.Net.Http;

namespace _17_CrudPersonas_UWP_DAL.Listados
{
    public class clsListadoPersonas
    {

        /// <summary>
        /// Funcion que nos devuelve un listado de personas.
        /// </summary>
        /// <returns>Listados de personas</returns>
        public async Task<List<clsPersona>> getListadoPersonas()
        {


            clsUriBase gestoriaApi = new clsUriBase();
            String uri = gestoriaApi.getBaseUrlApi();
            Uri UriApi = new Uri(uri);
            List<clsPersona> lista = null;
            string ret;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(UriApi);

            if (response.IsSuccessStatusCode)
            {
                ret = await response.Content.ReadAsStringAsync();
                lista = await JsonConvert.DeserializeObject<Task<List<clsPersona>>>(ret);
            }
            else
            {
                
            }
        

            return lista;


            /*
            Task<List<object>> rett = null;
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

                
                    Object arr =JsonConvert.DeserializeObject(s);


                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            */
            /*
            clsUriBase gestoriaApi = new clsUriBase();

            Console.WriteLine("Haciendo una petición al servio de clientes....");

            //se define la url del método de la api.
            String uri = gestoriaApi.getBaseUrlApi();
            Uri URL = new Uri(uri);
            var listado;

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            HttpClient client = new HttpClient();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await client.GetAsync(uri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                listado = JsonConvert.DeserializeObject(httpResponseBody);
            }
            catch (Exception ex)
            {
                
            }

            return listado;

        }

    */



        }
    }
}
