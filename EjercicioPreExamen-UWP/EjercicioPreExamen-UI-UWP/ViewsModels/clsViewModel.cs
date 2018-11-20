using EjercicioPreExamen_UI_UWP.BD;
using EjercicioPreExamen_UI_UWP.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPreExamen_UI_UWP.ViewsModels
{
    public class clsViewModel : clsVMBase
    {
        private List<clsCategoria> _listaCategorias;
        private int _categoriaSeleccionada;
        private List<clsPersonaje> _listaPersonajes;
        private clsPersonaje _personajeSeleccionado;


        public List<clsCategoria> ListadoCategorias{

            get {

                return _listaCategorias;
            }
            set {

                _listaCategorias = value;
            }
        }

        public int CategoriaSeleccionada {

            get {

                return _categoriaSeleccionada;
            }
            set {

                _categoriaSeleccionada = value;
                NotifyPropertyChanged("CategoriaSeleccionada");
                listadoPersonajesPorCategoria();
                NotifyPropertyChanged("ListaPersonajes");
                
            }

        }
        public List<clsPersonaje> ListaPersonajes {

            get {

                return _listaPersonajes;

            }
            set {

                _listaPersonajes = value;

            }
        }
        public clsPersonaje PersonajeSeleccionado {

            get {

                return _personajeSeleccionado;
            }
            set {

                _personajeSeleccionado = value;
                NotifyPropertyChanged("PersonajeSeleccionado");
            }
        }


        public void listadoPersonajesPorCategoria() {

            clsListados gestora = new clsListados();
            _listaPersonajes = gestora.listaPersonajesID(CategoriaSeleccionada);

        }


        public clsViewModel() {

            clsListados gestora = new clsListados();
            _listaCategorias = gestora.listadoCategoria();
            _listaPersonajes = gestora.ListadoPersonajes();

        }
    }
}
