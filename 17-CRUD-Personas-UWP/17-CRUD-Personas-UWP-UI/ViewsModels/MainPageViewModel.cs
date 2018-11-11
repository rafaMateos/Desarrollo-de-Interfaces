
using _07_CRUDPersonas_BL.Listados;
using _17_CRUD_Personas_UWP_BL.Listados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace _17_CRUD_Personas_UWP_Entidades.ViewModels
{
   public class MainPageViewModel: INotifyPropertyChanged
    {
        #region PropPrivadas
        private List<clsPersona> _listadoPersonas;
        private clsPersona _PersonaSelec;
        private List<clsDepartamento> _listadoDep;
       

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }


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
                OnPropertyChanged("PersonaSelec");


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

       
        
                #endregion

        #region constructor

        public MainPageViewModel() {

            //CargarListadoPersonas

             clsListadoPersonas_BL m = new clsListadoPersonas_BL();
            _listadoPersonas = m.ListadoPersonas_BL();

            //cargarListaDeps
            clsListadoDep_BL listaDep = new clsListadoDep_BL();
            _listadoDep = listaDep.ListadoDep_BL();

        }

        #endregion
    }

}
