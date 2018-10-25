using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _12_Solarizr.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class EspecificacionesCitas : Page
    {
        public EspecificacionesCitas()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            MapService.ServiceToken = "i0LX0ZtyCNlqrCpfAe4o~UOcr-lGr9izrFCmZtL2qjg~AttsrrQUiwrEJOnzJkpGooFH-_dKrzLCSmjLJR6cu9ZMhiAsoEVrSTtw1DXYJL82";
        }

        private void botonGaleria_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Galeria));
        }

        /// <summary>
        /// Metodo el cual nos pondra una ubicacion predefinida
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Especificamos una ubucacion
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 37.0861000, Longitude = -5.7861400 };
            Geopoint cityCenter = new Geopoint(cityPosition);

            // Modificamos el mapa
            MapControl1.Center = cityCenter;
            MapControl1.ZoomLevel = 12;
            MapControl1.LandmarksVisible = true;

        }
    }
    }
