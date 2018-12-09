using _17_CrudPersonas_UWP_DAL.Listados;
using _17_CrudPersonas_UWP_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_CruDPersonas_UWP_BL.Listados
{
    public class clsListadoPersonasBL
    {

        public async Task<List<clsPersona>> getListadoPersonas_BL() {
            
            clsListadoPersonas gestoraDal = new clsListadoPersonas();
            List<clsPersona> lista = await gestoraDal.getListadoPersonas();

            return lista;

        }
    }
}
