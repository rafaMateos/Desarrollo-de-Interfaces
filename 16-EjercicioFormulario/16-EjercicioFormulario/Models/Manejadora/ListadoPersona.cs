using System;
using System.Collections.Generic;
using System.Linq;
using _16_EjercicioFormulario.Models;

namespace _16_EjercicioFormulario.Models
{
    public class ListadoPersona
    {

        /// <summary>
        /// Funcion que nos devolvera un lista de personas
        /// </summary>
        /// <returns></returns>
        public List<clsPersona> listadoPersona() {

            List<clsPersona> listado = new List<clsPersona>();

            listado.Add(new clsPersona(1,1, "Rafa", "Mateos", new DateTime(2010, 10, 10), "66666666", "Calle Ere el mejo"));
            listado.Add(new clsPersona(2,3, "Fernando", "Galiana", new DateTime(2010, 10, 10), "7887uuu", "Calle .net"));
            listado.Add(new clsPersona(3,4, "Jorgue", "Obando", new DateTime(2010, 10, 10), "786756764564", "Calle ExPON10"));


            return listado;
        }
       
    }
}