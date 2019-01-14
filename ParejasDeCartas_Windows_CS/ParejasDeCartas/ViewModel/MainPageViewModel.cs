using ParejasDeCartas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ParejasDeCartas.ViewModel
{
    public class MainPageViewModel : clsVMBase
    {

        public MainPageViewModel()
        {

            _Images = CargarImages();
            _listadoCartas = cargarPregun();
            _contadorPeguntasMostradas = 1;
            _contadorPeguntasAcertadas = 0;
        }

        #region propiedades privada
        private clsInfoPartida info = new clsInfoPartida();
        private List<String> _listadoCartas;
        private List<clsCarta> _Images;
        private clsCarta _cartaSeleccionada;
        private int _contadorPeguntasMostradas;
        public int _contadorPeguntasAcertadas { get; set; }
        #endregion

        #region propiedades publicas
        public int Contador
        {

            get
            {
                return _contadorPeguntasMostradas;
            }
            set
            {

                _contadorPeguntasMostradas = value;

            }
        }

        public List<String> ListadoCartas
        {

            get
            {

                return _listadoCartas;
            }
            set
            {

                _listadoCartas = value;

            }
        }


        public clsCarta CartaSeleccionada
        {

            get
            {

                return _cartaSeleccionada;
            }
            set
            {
                _cartaSeleccionada = value;
                ContadorAcert();
                info._cartasAcertadas = _contadorPeguntasAcertadas;
              
                info.nickNameGanador = "";
               
                info._cartasRespondidas = _contadorPeguntasMostradas++;
                MainPage.Position(info);
                if (_cartaSeleccionada != null)
                { 
                    //_contadorPeguntasMostradas++;
                    CargarUI();
                    NotifyPropertyChanged("CartaSeleccionada");
                    ComprobarGanadorAsync();
                }

                

                

            }
        }

        public List<clsCarta> Images {

            get {

                return _Images;
            }
            set {

                _Images = value;
                NotifyPropertyChanged("_Images");            }
        }
        #endregion

        #region Metodos que se que no van aqui pero como era una prueba los he dejado
        public List<clsCarta> CargarImages() {

            List<clsCarta> ret = new List<clsCarta>();

            clsCarta carta1 = new clsCarta("ms-appx://ParejasDeCartas/Assets/Imagenes/flecha.jpg",false);
            clsCarta carta2 = new clsCarta("ms-appx://ParejasDeCartas/Assets/Imagenes/lebron.jpg",true);

            ret.Add(carta1);
            ret.Add(carta2);
            return ret;


        }

        public List<clsCarta> CargarImages2()
        {

            List<clsCarta> ret = new List<clsCarta>();

            clsCarta carta1 = new clsCarta("ms-appx://ParejasDeCartas/Assets/Imagenes/cero.jpg",false);
            clsCarta carta2 = new clsCarta("ms-appx://ParejasDeCartas/Assets/Imagenes/doce.jpg",true);
            clsCarta carta3 = new clsCarta("ms-appx://ParejasDeCartas/Assets/Imagenes/siete.jpg",false);

            ret.Add(carta1);
            ret.Add(carta2);
            ret.Add(carta3);
            return ret;


        }

        public List<clsCarta> CargarImages3()
        {

            List<clsCarta> ret = new List<clsCarta>();

            clsCarta carta1 = new clsCarta("ms-appx://ParejasDeCartas/Assets/Imagenes/verdad.jpg",true);
            clsCarta carta2 = new clsCarta("ms-appx://ParejasDeCartas/Assets/Imagenes/false.jpg", false);

            ret.Add(carta1);
            ret.Add(carta2);
            return ret;


        }

        public List<clsCarta> CargarImages4()
        {

            List<clsCarta> ret = new List<clsCarta>();

            clsCarta carta1 = new clsCarta("ms-appx://ParejasDeCartas/Assets/Imagenes/perro.jpg", true);
            clsCarta carta2 = new clsCarta("ms-appx://ParejasDeCartas/Assets/Imagenes/pajaro.jpg", false);

            ret.Add(carta1);
            ret.Add(carta2);
            return ret;


        }

        public List<String> cargarPregun() {

            List<String> ret = new List<string>();

            ret.Add("¿Quien de los dos se llama lebronJames?");

            return ret;

        }

        public List<String> cargarPregun2()
        {

            List<String> ret = new List<string>();

            ret.Add("¿Si en una pecera hay 12 peces y 5 de ellos se ahogan" + "\n"+" ¿Cuantos quedan?");

            return ret;

        }

        public List<String> cargarPregun3()
        {

            List<String> ret = new List<string>();

            ret.Add("¿La palabra París comienza con “P” y termina con “T”,"+ "\n"+ " ¿cierto o falso?");

            return ret;

        }

        public List<String> cargarPregun4()
        {

            List<String> ret = new List<string>();

            ret.Add("¿Qué animal da nombre a las Islas Canarias?");

            return ret;

        }

        public void CargarUI()
        {

            switch (_contadorPeguntasMostradas)
            {

                case 2:
                    _listadoCartas = cargarPregun2();
                    _Images = CargarImages2();

                    NotifyPropertyChanged("Images");
                    NotifyPropertyChanged("ListadoCartas");
                    break;
                case 3:
                    _listadoCartas = cargarPregun3();
                    _Images = CargarImages3();

                    NotifyPropertyChanged("Images");
                    NotifyPropertyChanged("ListadoCartas");
                    break;

                case 4:
                    _listadoCartas = cargarPregun4();
                    _Images = CargarImages4();

                    NotifyPropertyChanged("Images");
                    NotifyPropertyChanged("ListadoCartas");
                    break;

            }

        }

        public void ContadorAcert() {

            if (_cartaSeleccionada.esCorrecta) {

                _contadorPeguntasAcertadas++;
              
            }
        }


        public async Task ComprobarGanadorAsync() {

            if (_contadorPeguntasMostradas == 5) {

                //ContentDialog confirmarActualizado = new ContentDialog();
                //confirmarActualizado.Title = "Resultados";
                //confirmarActualizado.Content = "Acertaste " + _contadorPeguntasAcertadas;
                //confirmarActualizado.PrimaryButtonText = "Aceptar";
                //ContentDialogResult resultado = await confirmarActualizado.ShowAsync();



            }
        }

        #endregion


    }
}
