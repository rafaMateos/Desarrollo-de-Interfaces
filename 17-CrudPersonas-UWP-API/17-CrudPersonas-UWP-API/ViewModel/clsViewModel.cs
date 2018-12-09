using _17_CruDPersonas_UWP_BL.Listados;
using _17_CrudPersonas_UWP_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_CrudPersonas_UWP_API.ViewModel
{
     public class clsViewModel : clsVMBase
    {
        private Task<List<clsPersona>> _ListadoDePersonas;
        public Task<List<clsPersona>> ListadoDePersonas
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

            _ListadoDePersonas = gest.getListadoPersonas_BL();
            
           

        }
    }
}
