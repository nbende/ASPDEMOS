using Owin;//
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


[assembly: OwinStartupAttribute(typeof(SignalR2.Startup))]
namespace SignalR2
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }

    }
}