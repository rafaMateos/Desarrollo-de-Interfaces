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
            boton3.Content = "Boton1";
            boton3.VerticalAlignment = VerticalAlignment.Center;
            boton3.HorizontalAlignment = HorizontalAlignment.Center;
            boton3.Background = new SolidColorBrush(Windows.UI.Colors.Blue);
            boton3.Height = 70;
            boton3.Width = 200;
            boton3.FontFamily = new FontFamily("Verdana");
            boton3.FontSize = 16;
            boton3.FontWeight = Windows.UI.Text.FontWeights.Bold;
            boton3.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Yellow);


            stac = new StackPanel();
            boton3.Content = stac;
        }
    }
}
