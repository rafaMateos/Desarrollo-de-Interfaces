using System;
using System.Collections.Generic;
using System.Linq;

namespace _17_CRUD_Personas_UWP_Entidades
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

        public clsDepartamento() {

        }
        #endregion


    }
}