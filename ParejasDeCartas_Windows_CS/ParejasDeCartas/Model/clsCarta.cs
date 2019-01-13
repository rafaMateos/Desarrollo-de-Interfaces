using System;
using System.Collections.Generic;
using System.Linq;


namespace ParejasDeCartas.Model
{
    public class clsCarta
    {
        public clsCarta(String Uri, bool esCorrecta) {

            _uriImage = Uri;
            _esCorrecta = esCorrecta;
        }

        private String _uriImage;
        private bool _esCorrecta;

        public bool esCorrecta{

            get {

                return _esCorrecta;
            }

        }


        public String uriImage {

            get {

                return _uriImage;
            }
            set {

                _uriImage = value;
            }
        }

        

    }
}