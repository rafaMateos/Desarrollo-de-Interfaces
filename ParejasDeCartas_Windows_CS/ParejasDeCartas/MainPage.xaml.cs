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
using ParejasDeCartas.Model;
using ParejasDeCartas.ViewModel;
using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

#if OFFLINE_SYNC_ENABLED
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;  // offline sync
using Microsoft.WindowsAzure.MobileServices.Sync;         // offline sync
#endif

namespace ParejasDeCartas
{
    public sealed partial class MainPage : Page
    {
        public int aciertos = 0;
        public int aciertoO = 0;
        public int cartasResp = 0;
        public int cartasRespO = 0;
        public String nombreJugadorExterior;
        String tt = "ff";
        MainPageViewModel VM = new MainPageViewModel(); 
        public static HubConnection conn { get; set; }
        public IHubProxy proxy { get; set; }
        public static IHubProxy MyHubProxy { get; set; }
        public static String NickName;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NickName = (String)e.Parameter;
        }

        public MainPage()
        {
            this.InitializeComponent();
            SignalR();
        }

        public MainPage(String r) {
            this.tt = r;
        }

        private void SignalR()
        {

            //Connect to the url 
            conn = new HubConnection("https://parejasdecartasnervion.azurewebsites.net/");
            //conn = new HubConnection("http://localhost:58716/");
            //ChatHub is the hub name defined in the host program. 
            MyHubProxy = conn.CreateHubProxy("infoPartidaHub");
            conn.Start();

            MyHubProxy.On<clsInfoPartida>("sendInfoPartida", onInfo);
            

           
        }

         public static void Position(clsInfoPartida info)
        {

            if (conn.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
            {
                info.NickName = NickName;
                MyHubProxy.Invoke("enviarInfo", info);
                
            }

        }

        

        private async void onInfo(clsInfoPartida info)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
               
                if (info._cartasRespondidas == 4 && info.NickName.Equals(NickName)) {

                    
                    aciertos = info._cartasAcertadas;
                    cartasResp = info._cartasRespondidas;
                    this.Frame.Navigate(typeof(EsperarQueAcabe));
                }

                if (info._cartasRespondidas == 4 && !info.NickName.Equals(NickName)) {

                    aciertoO = info._cartasAcertadas;
                    cartasRespO = info._cartasRespondidas;
                    nombreJugadorExterior = info.NickName;
                }
   
                    if (cartasResp == 4 && cartasRespO == 4)
                    {

                        if (aciertoO > aciertos)
                        {
                            info.nickNameGanador = nombreJugadorExterior;

                        }
                        else if (aciertoO < aciertos || !String.IsNullOrEmpty(info.nickNameGanador))
                        {

                            info.nickNameGanador = NickName;

                        }
                        else if (aciertoO == aciertos || !String.IsNullOrEmpty(info.nickNameGanador))
                        {
                            info.nickNameGanador = "Empate";
                        }

                    if (!String.IsNullOrEmpty(info.nickNameGanador) && cartasResp == 4 && cartasRespO == 4)
                    {

                        ContentDialog confirmarActualizado = new ContentDialog();
                        confirmarActualizado.Title = "Resultados";
                        confirmarActualizado.Content = "Ganador " + info.nickNameGanador;
                        confirmarActualizado.PrimaryButtonText = "Aceptar";
                        ContentDialogResult resultado = await confirmarActualizado.ShowAsync();

                        Application.Current.Exit();
                    }

                }


                
               


            });
        }

      

    }
}
