﻿using API.Interfaces;
using API.Services;
using API.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Core
{
    public class Init
    {

        public static void CoreInit() {
            ServiceManager serviceManager = ServiceManager.getInstance();
            serviceManager.Register(new RestService());
            serviceManager.Register(new ContactsController(ServiceManager.Resolve<RestService>()));
            serviceManager.Register(new WebClient());
        }
        
    }
}
