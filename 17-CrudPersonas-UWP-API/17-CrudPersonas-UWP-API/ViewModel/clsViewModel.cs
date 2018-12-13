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
        private NotifyTaskCompletation2<List<clsPersona>> _ListadoDePersonas;

        public NotifyTaskCompletation2<List<clsPersona>> ListadoDePersonas
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

        /// <summary>
        /// Contructor de nuestro ViewModel
        /// </summary>
        public clsViewModel() {

            //CargarAsync();
            clsListadoPersonasBL gest = new clsListadoPersonasBL();

            _ListadoDePersonas = new NotifyTaskCompletation2<List<clsPersona>>(gest.getListadoPersonas_BL());

        }


        /// <summary>
        /// No es la mejor manera prque no podriamos controlar las exepciones ya que este metodo
        //  sera llamado en el constructor.
        /// </summary>
        //private async void CargarAsync() {
            
        //    _ListadoDePersonas = await gest.getListadoPersonas_BL();
        //    NotifyPropertyChanged("ListadoDePersonas");
        //    _esRespuesta = true;
        //    DESHabilitarGif();
        //}

       
    }
}
