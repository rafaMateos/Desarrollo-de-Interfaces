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
        public async Task<HttpStatusCode> actualizarPersonaDAL(clsPersona persona) {

            clsUriBase conec = new clsUriBase();
            HttpClient mihttpClient = new HttpClient();
            String datos;
            HttpContent contenido;
            string miCadenaUrl = conec.getBaseUrlApi();
            Uri miUri = new Uri($"{miCadenaUrl}/{persona.idPersona}");

            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
                datos = JsonConvert.SerializeObject(persona);

                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                miRespuesta = await mihttpClient.PutAsync(miUri, contenido);

            }
            catch {

                //TODO
            }

            return miRespuesta.StatusCode;

        }

        /// <summary>
        /// Metodo de llamado a la api para poder Insertar una persona.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> InsertarPersonaDAL(clsPersona persona)
        {

            clsUriBase conec = new clsUriBase();
            HttpClient mihttpClient = new HttpClient();
            String datos;
            HttpContent contenido;
            string miCadenaUrl = conec.getBaseUrlApi();
            Uri miUri = new Uri($"{miCadenaUrl}");

            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
                datos = JsonConvert.SerializeObject(persona);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                miRespuesta = await mihttpClient.PostAsync(miUri, contenido);

            }
            catch
            {
                //TODO
            }

            return miRespuesta.StatusCode;

        }

        

    }
}
