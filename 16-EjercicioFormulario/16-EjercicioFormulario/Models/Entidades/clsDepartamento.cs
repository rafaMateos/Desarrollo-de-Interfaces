using System;
using System.Collections.Generic;
using System.Linq;

namespace _16_EjercicioFormulario.Models
{
    public class clsDepartamento
    {
        #region Atributos
        public int Id { get; set; }
        public String Nombre { get; set; }
        #endregion

        #region Contructor
        public clsDepartamento(int Id,String Nombre){

            this.Id = Id;
            this.Nombre = Nombre;
    }
        #endregion


    }
}