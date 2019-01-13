/*
 * To add Offline Sync Support:
 *  1) Add the NuGet package Microsoft.Azure.Mobile.Client.SQLiteStore (and dependencies) to all client projects
 *  2) Uncomment the #define OFFLINE_SYNC_ENABLED
 *
 * For more information, see: http://go.microsoft.com/fwlink/?LinkId=717898
 */
//#define OFFLINE_SYNC_ENABLED

using Microsoft.AspNet.SignalR.Client;
using Microsoft.WindowsAzure.MobileServices;
using Pelotitas.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

#if OFFLINE_SYNC_ENABLED
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;  // offline sync
using Microsoft.WindowsAzure.MobileServices.Sync;         // offline sync
#endif

namespace Pelotitas
{
    public sealed partial class MainPage : Page
    {
        private List<Point> m_Points;
        private Random m_Random;

        public ViewModelMain pos = new ViewModelMain();
        public HubConnection conn { get; set; }
        public IHubProxy proxy { get; set; }
        public IHubProxy MyHubProxy { get; set; }

        public MainPage() {

            this.InitializeComponent();
            m_Points = new List<Point>();
            m_Random = new Random();
            SignalR();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Ellipse rectangle;
            Point newPoint;
            int index = GetRandomIndex();
            newPoint = GetRandomPoint();

            rectangle = (Ellipse)canvasBolita.Children[index];
            if (index == -1) return;
            
            Position(new clsPelotitas
                {arriba = (int)newPoint.Y,
                esComedor = 1,
                id =0,
                izquierda = (int)newPoint.X
            });

        }

        private Point GetRandomPoint()
        {
            int x;
            int y;
            x = m_Random.Next(10, 490);
            y = m_Random.Next(10, 490);
            return new Point(x, y);
        }

        private int GetRandomIndex()
        {
            int index;
            if (m_Points.Count == 0) return 0;
            index = m_Random.Next(m_Points.Count - 1);
            return index;
        }

        private void SignalR()
        {
            //Connect to the url 
            conn = new HubConnection("https://pelotitas.azurewebsites.net");
            //conn = new HubConnection("http://localhost:58458/");
            //ChatHub is the hub name defined in the host program. 
            MyHubProxy = conn.CreateHubProxy("pelotasHub");
            conn.Start();

            MyHubProxy.On<clsPelotitas>("sendPosition", onPosition);

        }

        public void Position(clsPelotitas pos)
        {

            if (conn.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
            {
                MyHubProxy.Invoke("enviarPosi", pos);
            }

        }

        private async void onPosition(clsPelotitas pelotas)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
               Ellipse rectangle = (Ellipse)canvasBolita.Children[0];

                Canvas.SetTop(rectangle, pelotas.arriba);
                Canvas.SetLeft(rectangle, pelotas.izquierda);
            });
        }
    }
}
