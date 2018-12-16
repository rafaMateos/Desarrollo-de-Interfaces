using _17_CrudPersonas_UWP_DAL.Manejadora;
using _17_CrudPersonas_UWP_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_CruDPersonas_UWP_BL.Manejadora
{
   public class clsManejadoraPersonas_BL
    {

        /// <summary>
        /// Devuelve una persona segun su id
        /// </summary>
        /// <param name="IDPersona"></param>
        /// <returns></returns>

        public async Task<clsPersona> personaPorID_BL(int IDPersona)
        {

            clsManejadoraPersona gestora = new clsManejadoraPersona();

            clsPersona oPersona = await gestora.personaPorID_DAL(IDPersona);


            return oPersona;

            }

            /// <summary>
            /// Borra una persona segun su id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public async Task<int> BorrarPersonaPorID_BL(int id)
        {
            int filasAfectadas;

            clsManejadoraPersona gestora = new clsManejadoraPersona();

            filasAfectadas = await gestora.BorrarPersonaPorID_DAL(id);


            return filasAfectadas;

        }

        public async Task<int> insertarPersona_BL(clsPersona oPersona)
        {
            int filas;

            clsManejadoraPersona gestora = new clsManejadoraPersona();

            filas = await gestora.InsertarPersonaDAL(oPersona);

            return filas;

        }

        public async Task<int> actualizarPersona_BL(clsPersona oPersona)
        {
            int filas;

            clsManejadoraPersona gestora = new clsManejadoraPersona();

            filas = await gestora.actualizarPersonaDAL(oPersona);


            return filas;
        }


    }
}
