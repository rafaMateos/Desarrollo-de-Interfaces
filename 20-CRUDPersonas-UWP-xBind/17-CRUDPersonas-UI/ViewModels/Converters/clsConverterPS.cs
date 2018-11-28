using _17_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _17_CRUDPersonas_UI.ViewModels.Converters
{
    class clsConverterPS:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            clsPersona oPer = null;
            if (value != null) {

                oPer = (clsPersona)value;
            }

            return oPer;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
