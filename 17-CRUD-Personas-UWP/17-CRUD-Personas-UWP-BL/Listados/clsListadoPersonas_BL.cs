using _17_CRUD_Personas_UWP_DAL.Listado;
using _17_CRUD_Personas_UWP_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUDPersonas_BL.Listados
{
    public class clsListadoPersonas_BL
    {
        public List<clsPersona> ListadoPersonas_BL()
        {
            List<clsPersona> lista = new List<clsPersona>();

            clsListadoPersonas_DAL listado = new clsListadoPersonas_DAL();

            lista = listado.listadoCompletoPersonas();

            return lista;

        }
    }
}
