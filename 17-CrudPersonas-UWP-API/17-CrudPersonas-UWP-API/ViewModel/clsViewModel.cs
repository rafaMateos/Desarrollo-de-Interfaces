using _17_CruDPersonas_UWP_BL.Listados;
using _17_CruDPersonas_UWP_BL.Manejadora;
using _17_CrudPersonas_UWP_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace _17_CrudPersonas_UWP_API.ViewModel
{
     public class clsViewModel : clsVMBase
    {
        private NotifyTaskCompletation2<List<clsPersona>> _ListadoDePersonas;

        private clsPersona _PersonaSelecionada;

        //Delegate commando para asi hacer cada una de las acciones
        private DelegateCommand _eliminarCommand;//Elimina una persona en concreto
        private DelegateCommand _actualizarListadoCommand;//Actualiza el listado
        private DelegateCommand _guardarCommand;//Guarda una persona la cual ha sido actualizada
        private DelegateCommand _insertarPersona;//Inserta una persona la cual has introducido sus datos.

        private bool _esEditar;//propiedas la cual nos indicara si el usuario desea insertar una persona o actualizarla
        private String _textoBuscar;
        private String _esVisible;

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



        #region propiedades publicas
        public String EsVisible
        {

            get
            {

                return _esVisible;
            }

        }



       

        public bool isEditar
        {

            get
            {

                return _esEditar;
            }

            set
            {

                _esEditar = value;

            }


        }
       
        public clsPersona PersonaSelecionada
        {

            get
            {

                return _PersonaSelecionada;
            }

            set
            {

                _PersonaSelecionada = value;
                //LLamamos a canExecute para que habilite el comandoEliminar
                _eliminarCommand.RaiseCanExecuteChanged();
                _guardarCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("PersonaSelecionada");
                _esVisible = "Visible";
                NotifyPropertyChanged("EsVisible");
            }
        }
        public DelegateCommand eliminarCommand
        {
            get
            {

                _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecuted);
                return _eliminarCommand;


            }
        }
        public DelegateCommand ActualizarListadoCommando
        {
            get
            {

                _actualizarListadoCommand = new DelegateCommand(ActualizarListadoCommand_Executed);

                return _actualizarListadoCommand;

            }
        }
        public DelegateCommand GuardarCommand
        {

            get
            {

                _guardarCommand = new DelegateCommand(GuardarPersonaCommand_ExecutedAsync, GuardarPersonaCommand_CanExecute);
                return _guardarCommand;

            }

        }
        public DelegateCommand InsertarPersonaCommand
        {

            get
            {
                _insertarPersona = new DelegateCommand(insertarPersonaCommand_Execute);

                return _insertarPersona;
            }


        }
        #endregion

        #region methods

        private async void GuardarPersonaCommand_ExecutedAsync()
        {

            clsManejadoraPersonas_BL gestora = new clsManejadoraPersonas_BL();
            ContentDialog confirmarActualizado = new ContentDialog();
            clsListadoPersonasBL gestoraListadosPersonas = new clsListadoPersonasBL();

            if (_esEditar)
            {

                try
                {
                    //Actualizamos la persona
                    gestora.actualizarPersona_BL(PersonaSelecionada);

                    //Volvemos a cargar el listado
                    _ListadoDePersonas = new NotifyTaskCompletation2<List<clsPersona>>(gestoraListadosPersonas.getListadoPersonas_BL());
                    NotifyPropertyChanged("ListadoDePersonas");

                    confirmarActualizado.Title = "Todo correcto";
                    confirmarActualizado.Content = "Esto va como un tiro, has actualizado flama";
                    confirmarActualizado.PrimaryButtonText = "Aceptar";
                    ContentDialogResult resultado = await confirmarActualizado.ShowAsync();

                    _esVisible = "Collapsed";
                    NotifyPropertyChanged("EsVisible");

                }
                catch (Exception e)
                {

                    //Mostramos los mensaje que creamos conveniente.
                    confirmarActualizado.Title = "Algo va mal";
                    confirmarActualizado.Content = "¿Que ha pasado? Po nose algo va mal";
                    confirmarActualizado.PrimaryButtonText = "Aceptar";
                    ContentDialogResult resultado = await confirmarActualizado.ShowAsync();

                    _esVisible = "Collapsed";
                    NotifyPropertyChanged("EsVisible");


                }


            }
            else
            {


                gestora.insertarPersona_BL(PersonaSelecionada);

                _ListadoDePersonas = new NotifyTaskCompletation2<List<clsPersona>>(gestoraListadosPersonas.getListadoPersonas_BL());
                NotifyPropertyChanged("ListadoDePersonas");

                PersonaSelecionada = new clsPersona();

                confirmarActualizado.Title = "Todo correcto";
                confirmarActualizado.Content = "Esto va como un tiro, has insertado flama";
                confirmarActualizado.PrimaryButtonText = "Aceptar";
                ContentDialogResult resultado = await confirmarActualizado.ShowAsync();
                _esEditar = true;
                PersonaSelecionada = null;
                _esVisible = "Collapsed";
                NotifyPropertyChanged("EsVisible");

            }




        }
        private bool GuardarPersonaCommand_CanExecute()
        {

            bool sePuedeGuardar = false;

            if (PersonaSelecionada != null)
            {
                sePuedeGuardar = true;
            }

            return sePuedeGuardar;

        }

        private void ActualizarListadoCommand_Executed()
        {
            clsListadoPersonasBL gestoraListadosPersonas = new clsListadoPersonasBL();

            try
            {
                //Cargar el listado de personas y departamentos.
                _ListadoDePersonas = new NotifyTaskCompletation2<List<clsPersona>>(gestoraListadosPersonas.getListadoPersonas_BL());
                NotifyPropertyChanged("ListadoDePersonas");
                PersonaSelecionada = null;
                _esVisible = "Collapsed";
                NotifyPropertyChanged("EsVisible");
            }
            catch (Exception e)
            {

            }



        }

        private void insertarPersonaCommand_Execute()
        {
            PersonaSelecionada = new clsPersona();
            _esEditar = false;


        }

        /// <summary>
        /// Metodo por el cual se eliminara a una persona del listado
        /// </summary>
        private async void EliminarCommand_Executed()
        {
            try
            {
                int filas;
                clsManejadoraPersonas_BL m = new clsManejadoraPersonas_BL();
                clsListadoPersonasBL listadoper = new clsListadoPersonasBL();
                ContentDialog confirmarBorrado = new ContentDialog();

                confirmarBorrado.Title = "Eliminar";
                confirmarBorrado.Content = "Estas seguro de borrar?";
                confirmarBorrado.PrimaryButtonText = "Cancelar";
                confirmarBorrado.SecondaryButtonText = "Aceptar";

                ContentDialogResult resultado = await confirmarBorrado.ShowAsync();

                if (resultado == ContentDialogResult.Secondary)
                {

                    try
                    {

                        filas = await m.BorrarPersonaPorID_BL(PersonaSelecionada.idPersona);

                        if (filas == 1)
                        {

                            _ListadoDePersonas = new NotifyTaskCompletation2<List<clsPersona>>(listadoper.getListadoPersonas_BL());
                            NotifyPropertyChanged("ListadoDePersonas");

                            _esVisible = "Collapsed";
                            NotifyPropertyChanged("EsVisible");
                        }

                    }
                    catch (Exception e)
                    {

                    }
                }



            }
            catch (Exception e)
            {

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

            if (PersonaSelecionada != null)
            {

                sePuedeEliminar = true;
            }

            return sePuedeEliminar;

        }





        /// <summary>
        /// Contructor de nuestro ViewModel
        /// </summary>
        public clsViewModel() {

            //CargarAsync();
            clsListadoPersonasBL gest = new clsListadoPersonasBL();

            _ListadoDePersonas = new NotifyTaskCompletation2<List<clsPersona>>(gest.getListadoPersonas_BL());
            _esEditar = true;
            _esVisible = "Collapsed";

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
#endregion