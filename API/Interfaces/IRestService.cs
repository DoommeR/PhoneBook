using API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IRestService
    {
        Task<Result> RefreshDataAsync();

    }
}
