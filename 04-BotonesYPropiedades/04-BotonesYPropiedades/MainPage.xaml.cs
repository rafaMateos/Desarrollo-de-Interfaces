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

namespace _04_BotonesYPropiedades
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            //Creacion del boton en tiempo de ejecucion
            this.InitializeComponent();

            //Creacion del objeto boton
            Button boton3 = new Button();

            //Asignamos valores a sus propiedades
            boton3.Content = "Boton3";
            boton3.VerticalAlignment = VerticalAlignment.Center;
            boton3.HorizontalAlignment = HorizontalAlignment.Center;
            boton3.Background = new SolidColorBrush(Windows.UI.Colors.Blue);
            boton3.Height = 70;
            boton3.Width = 200;
            boton3.FontFamily = new FontFamily("Verdana");
            boton3.FontSize = 16;
            boton3.FontWeight = Windows.UI.Text.FontWeights.Bold;
            boton3.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Yellow);

            //Añadimos al stacpanel
            stac.Children.Add(boton3);
            boton3.Click += new RoutedEventHandler(Button3Click);
        }

        /// <summary>
        /// Metodo click del boton creado por codigo, que nos mostrara un holamundo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void Button3Click(object sender, RoutedEventArgs e)
        {

            ContentDialog msg = new ContentDialog

            {
                //Le damos valores a los campos del content dialog
                Title = "Hola Mundo",
                Content = "Estamos en DI",
                CloseButtonText = "Salir"

            };
            //Mostrar el mensaje
            await msg.ShowAsync();

        }
    }
}
