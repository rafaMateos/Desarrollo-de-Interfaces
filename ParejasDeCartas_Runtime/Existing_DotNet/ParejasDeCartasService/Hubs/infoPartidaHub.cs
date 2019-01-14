using Microsoft.AspNet.SignalR;
using ParejasDeCartasService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ParejasDeCartasService.Hubs
{

    //Interfaz que hay que mirarse mejor
    public interface IUserIdProvider
    {
        string GetUserId(IRequest request);
    }

    //Hun de mi server
    public class infoPartidaHub : Hub
    {

        public static int contadorUser = 0;

        //Metodo para enviar la informacion general de la partida.
        public void enviarInfo(clsInfoPartida info) {

            Clients.All.sendInfoPartida(info);
            

        }

        //Metodo que se ejecutara cada vez que haya una nueva conex
        public override Task OnConnected()
        {
            contadorUser++;
            Clients.All.usuarios(contadorUser);
            return base.OnConnected();
        }

        //Metodo que se ejecutara cada vez que se pierda una conex
        public override Task OnDisconnected(bool stopCalled)
        {
            contadorUser--;
            Clients.All.usuarios(contadorUser);
            return base.OnDisconnected(stopCalled);
        }





    }
}