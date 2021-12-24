using RandomUserApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RandomUserApp.Data.Repositories.Rest
{
    public interface IMobileService
    {
        Task<UsersResponse> GetUsers(string gender, int count);

        Task<UsersResponse> GetUser();
    }
}
