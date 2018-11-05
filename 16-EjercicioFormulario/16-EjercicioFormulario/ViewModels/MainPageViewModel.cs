using _16_EjercicioFormulario.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_EjercicioFormulario.ViewModels
{
   public class MainPageViewModel:INotifyPropertyChanged
   {
        #region PropPrivadas
        private List<clsPersona> _listadoPersonas;
        private clsPersona _PersonaSelec;
        private List<clsDepartamento> _listadoDep;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region propiedades publicas
        public List<clsPersona> listadoPersonas {

            get {

                return _listadoPersonas;
            }
            set {

                _listadoPersonas = value;
            }

        }

        public clsPersona PersonaSelec {

            get {

                return _PersonaSelec;
            }
            set {

                _PersonaSelec = value;
                
            }

        }

        public List<clsDepartamento> ListadoDep {

            get {

                return _listadoDep;
            }
            set {

                _listadoDep = value;
            }

        }

        /*
        private void NotifyPropertyChanged([] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        */
        #endregion

        #region constructor

        public MainPageViewModel() {

            //CargarListadoPersonas
            ListadoPersona m = new ListadoPersona();
           _listadoPersonas =  m.listadoPersona();

        }

        #endregion
    }

}
