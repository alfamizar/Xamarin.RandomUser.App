using RandomUserApp.Domain.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RandomUserApp.Data.Repositories.Rest
{
    public interface IMobileApi
    {
        [Get("/api/?gender={gender}&results={count}")]
        Task<UsersResponse> GetRandomUsers(string gender, int count);
    }
}
