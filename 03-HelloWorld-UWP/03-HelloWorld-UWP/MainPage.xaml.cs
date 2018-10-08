﻿using System;
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
using Windows.UI.Xaml.Navigatio

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _03_HelloWorld_UWP
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
        /// Lanza contentdialog saludando usando el contenido de textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //Declaracion variables
            String nombre;

            //Guardamos el nombre
            nombre = TxtNombre.Text;

            //Declaramos el contentdialog
            
            ContentDialog msg = new ContentDialog
            {
                //Le damos valores a los campos del content dialog
                Title = "Hola: " + nombre,
                Content = "Estamos en DI",
                CloseButtonText = "Salir"
                
            };
            //Mostrar el mensaje
             await msg.ShowAsync();

        }
    }
}

