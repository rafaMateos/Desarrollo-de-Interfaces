using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _07_GridLayout
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Evento asociado al clik boton enviar.
        /// Valida el formulario y muestra mensajes de error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

            //Inicialiazamos y declaramos las variables que vayamos a necesitar
            String email = "";
            Boolean emailCorrecto = false;
            String time = "";
            //Dclara las variables String y guarda los textos de los txtbox nene.

            //Comprobamos si el nombre esta vacio
            if (String.IsNullOrEmpty(txtNombre.Text))
            {

                txtbErrorNombre.Visibility = Visibility.Visible;

            }
            else
            {

                txtbErrorNombre.Visibility = Visibility.Collapsed;
            }


            //Comprobamos si el apellido esta vacio
            if (String.IsNullOrEmpty(txtApellidos.Text))
            {

                txtbErrorApellidos.Visibility = Visibility.Visible;

            }
            else
            {

                txtbErrorApellidos.Visibility = Visibility.Collapsed;
            }


            //Comprobamos si el email puede ser valido
            email = txtEmail.Text;
            
            //Instanciamos un objeto de la clase regex con nuestra expresion regular
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            //La clase match tiene un metodo regex el cual nos comprobara si nuestro email es valido acorde la expresion regular
            Match match = regex.Match(email);

            //Si el email es correcto
            if (!match.Success)
            {

                txtbErrorEmail.Visibility = Visibility.Visible;

            }
            else {

                txtbErrorEmail.Visibility = Visibility.Collapsed;

            }


            DateTime today;
            if (DateTime.TryParse(txtFecha.Text, out today))
            {

                txtbErrorFecha.Visibility = Visibility.Visible;

            }
            else {

                txtbErrorFecha.Visibility = Visibility.Collapsed;


            }





        }
    }
}
