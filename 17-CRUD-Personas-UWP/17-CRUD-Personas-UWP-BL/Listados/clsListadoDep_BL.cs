using _17_CRUD_Personas_UWP_DAL.Listado;
using _17_CRUD_Personas_UWP_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_CRUD_Personas_UWP_BL.Listados
{
    public class clsListadoDep_BL
    {
        public List<clsDepartamento> ListadoDep_BL()
        {
            List<clsDepartamento> lista = new List<clsDepartamento>();

            clsListadoDepartamento_DAL m = new clsListadoDepartamento_DAL();
            lista = m.listadoDep();

            return lista;

        }
    }
}
