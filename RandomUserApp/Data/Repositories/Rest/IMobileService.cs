using RandomUserApp.Data.DTOs;
using System.Threading.Tasks;

namespace RandomUserApp.Data.Repositories.Rest
{
    public interface IMobileService
    {
        Task<UsersResponse> GetUsers(string gender, int count);

        Task<UsersResponse> GetUser();
    }
}
