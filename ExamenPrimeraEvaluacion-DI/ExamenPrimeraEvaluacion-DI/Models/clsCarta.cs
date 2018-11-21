using ExamenPrimeraEvaluacion_DI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEvaluacion_DI.Models
{
    public class clsCarta : clsVMBase
    {

        #region Atributos
      
        private int _posicion;

        private bool _esBomba;

        private String _uriImagen;
        

        public bool EsBomba {

            get {

                return _esBomba;
            }
            set {

                _esBomba = value;
                
            }
        }
        public int Posicion {

            get {

                return _posicion;
            }set {

                _posicion = value;
                NotifyPropertyChanged("Posicion");
            }
        }
        public String UriImagen {

            get {

                return _uriImagen;
            }set {

                _uriImagen = value;
                NotifyPropertyChanged("UriImagen");
            }

        }
        #endregion
        
        #region Contructor
        public clsCarta() {
            this._posicion = 0;
            this._esBomba = false;
            this.UriImagen = "ms-appx://ExamenPrimeraEvaluacion-DI/Assets/Imagenes/presionar.png";
            
        }

        public clsCarta(int pos) {

            this._posicion = pos;
            this._esBomba = false;
            this._uriImagen = "ms-appx://ExamenPrimeraEvaluacion-DI/Assets/Imagenes/presionar.png";

        }

        #endregion

        #region Metodos
        /// <summary>
        /// Funcion la cual nos devolvera un listado de cartas .
        /// </summary>
        /// <returns>List clsCartas</returns>
        public static List<clsCarta> listadoCartas() {

            List<clsCarta> ret = new List<clsCarta>();

            clsCarta carta1 = new clsCarta(1);
            clsCarta carta2 = new clsCarta(2);
            clsCarta carta3 = new clsCarta(3);
            clsCarta carta4 = new clsCarta(4);
            clsCarta carta5 = new clsCarta(5);
            clsCarta carta6 = new clsCarta(6);
            clsCarta carta7 = new clsCarta(7);
            clsCarta carta8 = new clsCarta(8);
            clsCarta carta9 = new clsCarta(9);
            clsCarta carta10 = new clsCarta(10);
            clsCarta carta11 = new clsCarta(11);
            clsCarta carta12 = new clsCarta(12);
            clsCarta carta13 = new clsCarta(13);
            clsCarta carta14 = new clsCarta(14);
            clsCarta carta15 = new clsCarta(15);
            clsCarta carta16 = new clsCarta(16);

            ret.Add(carta1);
            ret.Add(carta2);
            ret.Add(carta3);
            ret.Add(carta4);
            ret.Add(carta5);
            ret.Add(carta6);
            ret.Add(carta7);
            ret.Add(carta8);
            ret.Add(carta9);
            ret.Add(carta10);
            ret.Add(carta11);
            ret.Add(carta12);
            ret.Add(carta13);
            ret.Add(carta14);
            ret.Add(carta15);
            ret.Add(carta16);

            return ret;

        }

        /// <summary>
        /// Funcion la cual nos devolvera el aleatorio de las bombas
        /// </summary>
        /// <returns>List de enteros</returns>
        public static List<int> aleatorioBombas() {
            Random alet = new Random();
            List<int> ret = new List<int>();

            for (int i = 0; i < 4; i++) {

                ret.Add(alet.Next(1, 16));
            }

            return ret;

        }
        #endregion

    }
}
