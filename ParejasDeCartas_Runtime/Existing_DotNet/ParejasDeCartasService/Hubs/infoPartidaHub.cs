using Microsoft.AspNet.SignalR;
using ParejasDeCartasService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ParejasDeCartasService.Hubs
{

    public interface IUserIdProvider
    {
        string GetUserId(IRequest request);
    }

    
    public class infoPartidaHub : Hub
    {

        public static int contadorUser = 0;

        public void enviarInfo(clsInfoPartida info) {

            Clients.All.sendInfoPartida(info);
            

        }

        public override Task OnConnected()
        {
            contadorUser++;
            Clients.All.usuarios(contadorUser);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            contadorUser--;
            Clients.All.usuarios(contadorUser);
            return base.OnDisconnected(stopCalled);
        }





    }
}