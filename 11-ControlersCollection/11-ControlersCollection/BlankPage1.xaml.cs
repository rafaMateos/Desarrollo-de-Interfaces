using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI;


// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _11_ControlersCollection
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        private Color color;
        
        public BlankPage1()
        {
            this.InitializeComponent();
            MapService.ServiceToken = " i0LX0ZtyCNlqrCpfAe4o~UOcr-lGr9izrFCmZtL2qjg~AttsrrQUiwrEJOnzJkpGooFH-_dKrzLCSmjLJR6cu9ZMhiAsoEVrSTtw1DXYJL82";


        }

        /// <summary>
        /// Metodo clik el cual nos recojera el color de la paleta y se lo pondra de fondo a un rectangulo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            color = myColorPicker.Color;

            rec.Fill = new SolidColorBrush(color);

        }

        /// <summary>
        /// Metodo el cual nos devuelve a la pagina anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void atras_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        /// <summary>
        /// Metodo el cual nos pondra una ubicacion predefinida
        /// </summary>
        /// <param name="e"></param>
        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Especificamos una ubucacion
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 37.0861000, Longitude = -5.7861400 };
            Geopoint cityCenter = new Geopoint(cityPosition);

            // Modificamos el mapa
            MapControl1.Center = cityCenter;
            MapControl1.ZoomLevel = 12;
            MapControl1.LandmarksVisible = true;


            /*
            var accessStatus = await Geolocator.RequestAccessAsync();
          
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:

                    // Get the current location.
                    Geolocator geolocator = new Geolocator();
                    Geoposition pos = await geolocator.GetGeopositionAsync();
                    Geopoint myLocation = pos.Coordinate.Point;

                    // Set the map location.
                    MapControl1.Center = myLocation;
                    MapControl1.ZoomLevel = 12;
                    MapControl1.LandmarksVisible = true;
                   
                    break;

                case GeolocationAccessStatus.Denied:
                    // Handle the case  if access to location is denied.
                    break;

                case GeolocationAccessStatus.Unspecified:
                    // Handle the case if  an unspecified error occurs.
                    break;
            }
            */
        }
    }
}

