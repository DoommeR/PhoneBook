                             using API.Interfaces;
using API.Models;
using API.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ContactsController 
    {
        //IRestService srv = new RestService();
        private  IRestService srv;

        public ContactsController(IRestService service) 
        {
            srv = service;
        }
        
        public  Task<Result> GetContacts() {
            return  srv.RefreshDataAsync();
        }
    }
}
