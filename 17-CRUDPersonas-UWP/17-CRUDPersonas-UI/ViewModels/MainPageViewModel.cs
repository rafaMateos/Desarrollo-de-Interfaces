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
        private List<clsPersona> _listadoCompleto;
        private List<clsDepartamento> _ListadoDeDepartamentos;
        private clsPersona _PersonaSelecionada;

        //Delegate commando para asi hacer cada una de las acciones
        private DelegateCommand _eliminarCommand;//Elimina una persona en concreto
        private DelegateCommand _actualizarListadoCommand;//Actualiza el listado
        private DelegateCommand _guardarCommand;//Guarda una persona la cual ha sido actualizada
        private DelegateCommand _insertarPersona;//Inserta una persona la cual has introducido sus datos.
        private bool _esEditar;//propiedas la cual nos indicara si el usuario desea insertar una persona o actualizarla
        private String _textoBuscar;
        //y asi poder diferenciar que quiere hacer cada boton.
        #endregion

        #region propiedades publicas

        public String TextoBuscar {
            get {

                return _textoBuscar;

            }
            set {

                _textoBuscar = value;
                FiltrarListado(_textoBuscar);
                NotifyPropertyChanged("ListadoDePersonas");

            }
        }

        public bool isEditar {

            get {

                return _esEditar;
            }

            set{

                _esEditar = value;
                    
            }
            

        }
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
                _guardarCommand.RaiseCanExecuteChanged();
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
        public DelegateCommand GuardarCommand {

            get{

                _guardarCommand = new DelegateCommand(GuardarPersonaCommand_ExecutedAsync,GuardarPersonaCommand_CanExecute);
                return _guardarCommand;

            }

        }
        public DelegateCommand InsertarPersonaCommand {

            get{
                _insertarPersona = new DelegateCommand(insertarPersonaCommand_Execute);
                return _insertarPersona;
            }
           

        }
        #endregion

        #region methods

        private async void  GuardarPersonaCommand_ExecutedAsync()
        {
           
            clsManejadoraPersonas_BL gestora = new clsManejadoraPersonas_BL();
            ContentDialog confirmarActualizado = new ContentDialog();
            clsListadoPersonas_BL gestoraListadosPersonas = new clsListadoPersonas_BL();

            if (_esEditar)
            {

                try
                {
                    //Actualizamos la persona
                    gestora.actualizarPersona_BL(PersonaSelecionada);

                    //Volvemos a cargar el listado
                    _ListadoDePersonas = gestoraListadosPersonas.ListadoCompletoPersonas_BL();
                    NotifyPropertyChanged("ListadoDePersonas");

                    confirmarActualizado.Title = "Todo correcto";
                    confirmarActualizado.Content = "Esto va como un tiro, has actualizado flama";
                    confirmarActualizado.PrimaryButtonText = "Aceptar";
                    ContentDialogResult resultado = await confirmarActualizado.ShowAsync();

                }
                catch (Exception e)
                {

                    //Mostramos los mensaje que creamos conveniente.
                    confirmarActualizado.Title = "Algo va mal";
                    confirmarActualizado.Content = "¿Que ha pasado? Po nose algo va mal";
                    confirmarActualizado.PrimaryButtonText = "Aceptar";
                    ContentDialogResult resultado = await confirmarActualizado.ShowAsync();
                    

                }


            }
            else {


                gestora.insertarPersona_BL(PersonaSelecionada);

                _ListadoDePersonas = gestoraListadosPersonas.ListadoCompletoPersonas_BL();
                NotifyPropertyChanged("ListadoDePersonas");

                PersonaSelecionada = new clsPersona();

                confirmarActualizado.Title = "Todo correcto";
                confirmarActualizado.Content = "Esto va como un tiro, has insertado flama";
                confirmarActualizado.PrimaryButtonText = "Aceptar";
                ContentDialogResult resultado = await confirmarActualizado.ShowAsync();
                _esEditar = true;
                PersonaSelecionada = null;

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
            clsListadoPersonas_BL gestoraListadosPersonas = new clsListadoPersonas_BL();

            try
            {
                //Cargar el listado de personas y departamentos.
                _ListadoDePersonas = gestoraListadosPersonas.ListadoCompletoPersonas_BL();
                NotifyPropertyChanged("ListadoDePersonas");
                PersonaSelecionada = null;
            }
            catch (Exception e) {

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texto"></param>
        private void FiltrarListado(String texto) {

            _ListadoDePersonas = new List<clsPersona>();
            /*
            foreach(clsPersona persona in _listadoCompleto) {

                if (persona.nombre.Contains(texto)) {

                    _ListadoDePersonas.Add(persona);

                }

            }
            */
            //bars.Where(b => b.Age >= 5 && b.Age <= 25).GroupBy(b => b.FooId).Select(g => g.FirstOrDefault().Foo).ToList();
            _ListadoDePersonas = _listadoCompleto.Where(persona => persona.nombre.Contains(texto,StringComparison.CurrentCultureIgnoreCase) || persona.apellidos.Contains(texto,StringComparison.CurrentCultureIgnoreCase)).ToList();

        }

     
        #endregion

        #region constructores

        public MainPageViewModel() {

            clsListadoPersonas_BL gestoraListadosPersonas = new clsListadoPersonas_BL();
            clsListadoDepartamentos_BL gestoraListadosDepartamentos = new clsListadoDepartamentos_BL();

            //Cargar el listado de personas y departamentos.
            try
            {
                _ListadoDePersonas = gestoraListadosPersonas.ListadoCompletoPersonas_BL();
                _ListadoDeDepartamentos = gestoraListadosDepartamentos.ListadoCompletoDepartamentos_BL();
                _listadoCompleto = gestoraListadosPersonas.ListadoCompletoPersonas_BL();
                _esEditar = true;
            }
            catch (Exception e) {

                //TODO 
            }
            
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

//A tener en cuenta:

/*
 * Cuando queramos que un boton este o no habilitado , debemos de crear los metodos:
 * nombreAccion_Execute y nombreAccion_CanExecute.
 * CanExecute es un metodo que nos dira cuando queremos que el boton se active o no
 * para realizar la accion, ya que el llamara a un metodo de la clase clsVMBase.(RaiseCanExecuteChanged)
 * Debemos llamar a dicho metodo (RaiseCanExecuteChanged) en la accion que queremos que lo compruebe.
 * En nuestro ejemplo debemos llamarlo al presionar en una persona.
 * 
 * IMPORTATE!!!!!! Preguntar a fernando por la posibilidad de cosas nuevas en el examen
*/
