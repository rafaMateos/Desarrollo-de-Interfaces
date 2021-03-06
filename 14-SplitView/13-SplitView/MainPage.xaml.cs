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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _13_SplitView
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

        private void hamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            this.splitView.IsPaneOpen = !this.splitView.IsPaneOpen;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Correo.IsSelected)
            {
                Contenedor.Navigate(typeof(Calendario));
            }
            if (Fechas.IsSelected)
            {

                Contenedor.Navigate(typeof(pag1));
            }
            if (uuuu.IsSelected) {

                Contenedor.Navigate(typeof(pag2));

            }



        }

        private void FontIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Contenedor.Navigate(typeof(formulario));

        }

        private void splitView_PaneOpening(SplitView sender, object args)
        {

        }
    }
}
