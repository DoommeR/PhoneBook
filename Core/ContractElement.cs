
using API.Interfaces;
using API.Services;
using API.Controllers;
using API.Models;
using System.Collections.Generic;



namespace Core
{
    public class ContractElement 
    {
        //IRestService restService;
        ContactsController cntr = new ContactsController();

        public List<Contact> GetContacts() {

            var list = await cntr.RefreshDataAsync(); 
            return  list;
        }
    }
}
