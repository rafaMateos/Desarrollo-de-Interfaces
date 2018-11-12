using _17_CRUDPersonas_BL.Listados;
using _17_CRUDPersonas_BL.Manejadoras;
using _17_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace _17_CRUDPersonas_UI.ViewModels
{
    public class MainPageViewModel : clsVMBase
    {

        #region propiedades privadas

        private List<clsPersona> _ListadoDePersonas;
        private List<clsDepartamento> _ListadoDeDepartamentos;
        private clsPersona _PersonaSelecionada;
        private DelegateCommand _eliminarCommand;
        private DelegateCommand _actualizarListadoCommand;




        #endregion

        #region propiedades publicas


        public List<clsPersona> ListadoDePersonas {

            get {

                return _ListadoDePersonas;
            }

            set {

                _ListadoDePersonas = value;
            }

        }

        public List<clsDepartamento> ListadoDeDepartamentos
        {

            get
            {

                return _ListadoDeDepartamentos;
            }

            set
            {

                _ListadoDeDepartamentos = value;
            }

        }

        public clsPersona PersonaSelecionada
        {

            get {

                return _PersonaSelecionada;
            }

            set {

                _PersonaSelecionada = value;

                //LLamamos a canExecute para que habilite el comandoEliminar
                _eliminarCommand.RaiseCanExecuteChanged();

                NotifyPropertyChanged("PersonaSelecionada");
            }
        }

        public DelegateCommand eliminarCommand
        {
            get {

                _eliminarCommand = new DelegateCommand(EliminarCommand_Executed,EliminarCommand_CanExecuted);
                return _eliminarCommand;
                

            }
        }

        public DelegateCommand ActualizarListadoCommando
        {
            get {

                _actualizarListadoCommand = new DelegateCommand(ActualizarListadoCommand_Executed);
                return _actualizarListadoCommand;
                

            }
        }

        private void ActualizarListadoCommand_Executed()
        {
            clsListadoPersonas_BL gestoraListadosPersonas = new clsListadoPersonas_BL();

            //Cargar el listado de personas y departamentos.
            _ListadoDePersonas = gestoraListadosPersonas.ListadoCompletoPersonas_BL();
            NotifyPropertyChanged("ListadoDePersonas");
        }


        /// <summary>
        /// 
        /// </summary>
        private async void EliminarCommand_Executed()
        {
            try {
                int filas;
                clsManejadoraPersonas_BL m = new clsManejadoraPersonas_BL();
                clsListadoPersonas_BL listadoper = new clsListadoPersonas_BL();
                ContentDialog confirmarBorrado = new ContentDialog();

                confirmarBorrado.Title = "Eliminar";
                confirmarBorrado.Content = "Estas seguro de borrar?";
                confirmarBorrado.PrimaryButtonText = "Cancelar";
                confirmarBorrado.SecondaryButtonText = "Aceptar";

                ContentDialogResult resultado = await confirmarBorrado.ShowAsync();

                if (resultado == ContentDialogResult.Secondary) {

                    try {

                        filas = m.BorrarPersonaPorID_BL(PersonaSelecionada.idPersona);

                        if (filas == 1) {
                            _ListadoDePersonas = listadoper.ListadoCompletoPersonas_BL();
                            NotifyPropertyChanged("ListadoDePersonas");
                        }
                        
                    }
                    catch (Exception e) {

                    }
                }

               

            }
            catch (Exception e) {

                //TODO Lanazar dialogo con error

            }
        }

        /// <summary>
        /// Funcion que devuelve un boleano para habilitar o desabilitar los controles bindiados al comando eliminar
        /// </summary>
        /// <returns></returns>
        private bool EliminarCommand_CanExecuted()
        {

            bool sePuedeEliminar = false;

            if (PersonaSelecionada !=  null) {

                sePuedeEliminar = true;
            }

            return sePuedeEliminar;

        }

        #endregion


        #region constructores

        public MainPageViewModel() {

            clsListadoPersonas_BL gestoraListadosPersonas = new clsListadoPersonas_BL();
            clsListadoDepartamentos_BL gestoraListadosDepartamentos = new clsListadoDepartamentos_BL();

            //Cargar el listado de personas y departamentos.
            _ListadoDePersonas = gestoraListadosPersonas.ListadoCompletoPersonas_BL();
            _ListadoDeDepartamentos = gestoraListadosDepartamentos.ListadoCompletoDepartamentos_BL();

        }

        #endregion


        //Al utilizar clcVMBase no haxce falta
        /*protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        */

    }
}
