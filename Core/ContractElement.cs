
using API.Interfaces;
using API.Services;
using API.Controllers;
using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public class ContractElement 
    {
        //IRestService restService;
        ContactsController cntr = new ContactsController();

        public async Task<Result> GetContacts() {
            return await cntr.GetContacts();
        }
        public async Task<List<Contact>> getContactsList() {
           Result list = await GetContacts();
            return list.Results;
        }
    }
}
