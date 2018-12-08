using _17_CruDPersonas_UWP_BL.Listados;
using _17_CrudPersonas_UWP_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_CrudPersonas_UWP_API.ViewModel
{
     public class clsViewModel
    {
        private List<clsPersona> _ListadoDePersonas;
        public List<clsPersona> ListadoDePersonas
        {

            get
            {

                return _ListadoDePersonas;
            }

            set
            {

                _ListadoDePersonas = value;
            }

        }

        public clsViewModel() {

            clsListadoPersonasBL gest = new clsListadoPersonasBL();

            gest.pepe();

        }
    }
}
