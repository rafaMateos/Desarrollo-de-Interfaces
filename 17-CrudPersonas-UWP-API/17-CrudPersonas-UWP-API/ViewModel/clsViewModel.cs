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
        private List<clsPersona> _ListadoDePersonas;
        private bool _esRespuesta = false;
        private String _esVisible;

        public String EsVisible {

            get {

                return _esVisible;
            }
            set {

                _esVisible = value;
            }

        }
        
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

            CargarAsync();
            //Tener en cuenta que esta no es la mejor forma.
            //Prox dia haremos la clase tocha, de nuestro amigo cristiano.

        }


        /// <summary>
        /// No es la mejor manera prque no podriamos controlar las exepciones ya que este metodo
        //  sera llamado en el constructor.
        /// </summary>
        private async void CargarAsync() {

            clsListadoPersonasBL gest = new clsListadoPersonasBL();
            _ListadoDePersonas = await gest.getListadoPersonas_BL();
            NotifyPropertyChanged("ListadoDePersonas");
            _esRespuesta = true;
            DESHabilitarGif();
        }

        public void DESHabilitarGif() {

            if (_esRespuesta) {

                _esVisible = "Collapsed";
                NotifyPropertyChanged("EsVisible");
            }
            else {

                _esVisible = "Visible";
            }

        }
    }
}
