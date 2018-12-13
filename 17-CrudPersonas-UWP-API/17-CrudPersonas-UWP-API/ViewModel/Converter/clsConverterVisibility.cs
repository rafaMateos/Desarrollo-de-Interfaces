using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _17_CrudPersonas_UWP_API.ViewModel.Converter
{
    public class clsConverterVisibility : IValueConverter
    {

        /// <summary>
        /// Conversor para poder utilizar (segun el resultado de la peticion asincrona) la visibilidad de los componentes
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns>String con el valor del atributo visibilidad</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Boolean result = (Boolean)value;
            return result ? "Visible" : "Collapsed";
        }

        /// <summary>
        /// Conversor para poder utilizar (segun el resultado de la peticion asincrona) la visibilidad de los componentes
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns>Bool con el valor del atributo visibilidad</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            String result = (String)value;

            Boolean ret = false;

            if (result.Equals("Visible"))
            {

                ret = true;
            }
            else {

                ret = false;
            }

            return ret;


        }
    }
}
