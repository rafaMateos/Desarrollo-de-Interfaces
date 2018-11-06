using _16_EjercicioFormulario.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_MVC_Ejercicio1.Models
{
    public class clsListadoDepartamento
    {
        #region Metodos
        public List<clsDepartamento> ObtenerListado() {

            List<clsDepartamento> list = new List<clsDepartamento>();

           clsDepartamento dep1 = new clsDepartamento(1,"Informatica");
            clsDepartamento dep2 = new clsDepartamento(2,"Marketin");
            clsDepartamento dep3 = new clsDepartamento(3,"Recursos Homanos");
            clsDepartamento dep4 = new clsDepartamento(4,"Medecina");

            list.Add(dep1);
            list.Add(dep2);
            list.Add(dep3);
            list.Add(dep4);

            return list;
        }
        #endregion
    }
}