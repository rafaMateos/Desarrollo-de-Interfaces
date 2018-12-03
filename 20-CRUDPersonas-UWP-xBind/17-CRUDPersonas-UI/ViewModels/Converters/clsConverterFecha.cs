using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _17_CRUDPersonas_UI.ViewModels.Converters
{
    public class clsConverterFecha : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            DateTime fecha =(DateTime)value;
            String ret;
            ret=  fecha.ToShortDateString();
            return ret;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTime enteredDate = DateTime.Parse(value.ToString());

            return enteredDate;

        }


    }
}
