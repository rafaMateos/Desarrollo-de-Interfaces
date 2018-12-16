using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using _17_CrudPersonas_UWP_DAL.Conexion;
using _17_CrudPersonas_UWP_Entidades;
using Newtonsoft.Json;

namespace _17_CrudPersonas_UWP_DAL.Manejadora
{
   public class clsManejadoraPersona
    {

        /// <summary>
        /// Metodo de llamado a la api para poder actualizar una persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<int> actualizarPersonaDAL(clsPersona persona) {

            clsUriBase conec = new clsUriBase();
            HttpClient mihttpClient = new HttpClient();
            String datos;
            int filas = 0;
            HttpContent contenido;
            string miCadenaUrl = conec.getBaseUrlApi();
            Uri miUri = new Uri($"{miCadenaUrl}/{persona.idPersona}");

            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
                datos = JsonConvert.SerializeObject(persona);

                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                miRespuesta = await mihttpClient.PutAsync(miUri, contenido);

                if (miRespuesta.IsSuccessStatusCode)
                {

                    filas = 1;
                }

            }
            catch {

                //TODO
            }

            return filas;

        }

        /// <summary>
        /// Metodo de llamado a la api para poder Insertar una persona.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<int> InsertarPersonaDAL(clsPersona persona)
        {

            clsUriBase conec = new clsUriBase();
            HttpClient mihttpClient = new HttpClient();
            String datos;
            int filas = 0;
            HttpContent contenido;
            string miCadenaUrl = conec.getBaseUrlApi();
            Uri miUri = new Uri($"{miCadenaUrl}");

            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
                datos = JsonConvert.SerializeObject(persona);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                miRespuesta = await mihttpClient.PostAsync(miUri, contenido);

                if (miRespuesta.IsSuccessStatusCode) {

                    filas = 1;
                }

            }
            catch
            {
                //TODO
            }

            return filas;

        }

        public async Task<int> BorrarPersonaPorID_DAL(int id)
        {

            int filas = 0;
            clsUriBase gestoraUri = new clsUriBase();
            HttpClient httpClient = new HttpClient();
            String uriBase = gestoraUri.getBaseUrlApi();
            Uri miUri = new Uri($"{uriBase}/{id}");

            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try
            {

                miRespuesta = await httpClient.DeleteAsync(miUri);

                if (miRespuesta.IsSuccessStatusCode)
                {

                    filas = 1;
                }

            }
            catch (Exception e)
            {

                //TODO

            }

            return filas;



        }

        public async Task<clsPersona> personaPorID_DAL(int id)
        {

            clsPersona persona = new clsPersona();


            HttpClient client = new HttpClient();

            clsUriBase uriBase = new clsUriBase();
            String uri = uriBase.getBaseUrlApi();
            Uri myUri = new Uri($"{uri}/{id}");


            String jsonText;


            HttpResponseMessage response = await client.GetAsync(myUri);

            if (response.IsSuccessStatusCode)
            {

                jsonText = await response.Content.ReadAsStringAsync(); //Con la respuesta
                //jsonText = await client.GetStringAsync(myUri);    //Con el cliente

                persona = JsonConvert.DeserializeObject<clsPersona>(jsonText);

            }



            return persona;
        }



    }
}
