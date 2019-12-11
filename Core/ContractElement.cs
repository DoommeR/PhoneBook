
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
        private readonly ContactsController controller= ServiceManager.Resolve<ContactsController>();

        public async Task<List<Contact>> getContactsList()
        {
           Result list = await controller.GetContacts();
            return list.Results;
        }
    }
}
