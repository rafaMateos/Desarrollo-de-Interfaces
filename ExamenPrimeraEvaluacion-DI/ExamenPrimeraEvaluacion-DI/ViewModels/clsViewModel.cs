using ExamenPrimeraEvaluacion_DI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ExamenPrimeraEvaluacion_DI.ViewModels
{
    public class clsViewModel: clsVMBase
    {
        #region Propiedades privadas
        private List<clsCarta> _listadoCartas;
        private clsCarta _cartaSeleccionada;
        private List<int> _aleatorioBombas;
        private int _contador;

        private DelegateCommand _reiniciar;
        #endregion


        #region PropiedadesPublicas
        
        public int Contador {

            get {
                return _contador;
            }
            set {

                _contador = value;
                
            }
        }
        public List<clsCarta> ListadoCartas {

            get {

                return _listadoCartas;
            }
            set {

                _listadoCartas = value;

            }
        }
        public clsCarta CartaSeleccionada {

            get {

                return _cartaSeleccionada;
            }
            set {

                _cartaSeleccionada = value;

                if (_cartaSeleccionada != null) {
                    esPressedPressed();
                    NotifyPropertyChanged("CartaSeleccionada");


                }

            }
        }
        public List<int> AleatorioBombas {

            get {

                return _aleatorioBombas;

            }
            set {
                _aleatorioBombas = value;
            }

        }
        public DelegateCommand reiniciarCommando
        {
            get
            {

                _reiniciar = new DelegateCommand(ResetCommando_Execute);
                return _reiniciar;
            }

        }

        #endregion


        #region constructor
        public clsViewModel() {

            _listadoCartas = clsCarta.listadoCartas();
            _aleatorioBombas = clsCarta.aleatorioBombas();

        }
        #endregion


        #region methods

        /// <summary>
        /// Funcion la cual nos comprueba cuando selecciona una carta si ha ganado o no y si es una bomba
        /// </summary>
        public async void esPressedPressed() {

            ContentDialog confirmarActualizado = new ContentDialog();
            
            bool salir = false; ;
           

            for (int i = 0; i < _aleatorioBombas.Count && !salir; i++) {

                if (_cartaSeleccionada.Posicion == _aleatorioBombas[i] || _cartaSeleccionada.Posicion == _aleatorioBombas[i + 1] || _cartaSeleccionada.Posicion == _aleatorioBombas[i + 2] || _cartaSeleccionada.Posicion == _aleatorioBombas[i + 3])
                {

                    _cartaSeleccionada.UriImagen = "ms-appx://ExamenPrimeraEvaluacion-DI/Assets/Imagenes/bomba.png";
                    NotifyPropertyChanged("CartaSeleccionada");
                    confirmarActualizado.Title = "Perdiste pulsate bomba";
                    confirmarActualizado.Content = "Lo siento";
                    confirmarActualizado.PrimaryButtonText = "Aceptar";
                    ContentDialogResult resultado = await confirmarActualizado.ShowAsync();
                    salir = true;
                    ResetCommando_Execute();

                }
                else {

                    _cartaSeleccionada.UriImagen = "ms-appx://ExamenPrimeraEvaluacion-DI/Assets/Imagenes/salvado.png";
                    NotifyPropertyChanged("CartaSeleccionada");
                    _contador++;
                    
                    salir = true;
                    if (_contador == 5) {

                        _contador = 0;
                        confirmarActualizado.Title = "Ganaste";
                        confirmarActualizado.Content = "Enhorabuena";
                        confirmarActualizado.PrimaryButtonText = "Aceptar";
                        ContentDialogResult resultado = await confirmarActualizado.ShowAsync();
                        ResetCommando_Execute();



                    }
                    
                }

            }


            

        }


        /// <summary>
        /// Delegate command el cual nos reiniciara la partida
        /// </summary>
        private void ResetCommando_Execute()
        {

            _listadoCartas = clsCarta.listadoCartas();
            NotifyPropertyChanged("ListadoCartas");
            _aleatorioBombas = clsCarta.aleatorioBombas();
            NotifyPropertyChanged("AleatorioBombas");
            _cartaSeleccionada = new clsCarta(0);
            _contador = 0;


        }
        #endregion



    }
}
