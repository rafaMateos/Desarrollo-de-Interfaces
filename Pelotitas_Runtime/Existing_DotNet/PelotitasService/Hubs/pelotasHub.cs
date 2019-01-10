using Microsoft.AspNet.SignalR;
using PelotitasService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PelotitasService.Hubs
{
    public class pelotasHub : Hub
    {
        public void enviarPosi(clsPelotitas obj)
        {
            Clients.All.sendPosition(obj);
        }

    }
}