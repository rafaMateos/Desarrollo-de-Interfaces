using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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


        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

            //Inicialiazamos las variables que vayamos a necesitar
            String email = "";
            Boolean emailCorrecto = false;


            //Comprobamos si el nombre esta vacio
            if (String.IsNullOrEmpty(txtNombre.Text))
            {

                txtErrorNombre.Visibility = Visibility.Visible; 

            }
            else {

                txtErrorNombre.Visibility = Visibility.Collapsed;
            }


            //Comprobamos si el apellido esta vacio
            if (String.IsNullOrEmpty(txtApellidos.Text))
            {

                txtErrorApellidos.Visibility = Visibility.Visible;

            }
            else
            {

                txtErrorApellidos.Visibility = Visibility.Collapsed;
            }


            //Comprobamos si el email puede ser valido
            email = txtEmail.Text;

            emailCorrecto = email.Contains('@');


            //Comprobamos si el email esta vacio o es el email es incorrecto
            if (String.IsNullOrEmpty(txtEmail.Text) || !emailCorrecto)
            {

                txtErrorEmail.Visibility = Visibility.Visible;

            }
            else
            {

                txtErrorEmail.Visibility = Visibility.Collapsed;
            }


        }
    }
}
