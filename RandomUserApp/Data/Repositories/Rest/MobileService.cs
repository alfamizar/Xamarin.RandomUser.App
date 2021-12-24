using RandomUserApp.Domain.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace RandomUserApp.Data.Repositories.Rest
{
    public class MobileService : IMobileService
    {
        private readonly IApi _mobileApi;

        private static MobileService instance = null;

        private MobileService()
        {
            _mobileApi = RestService.For<IApi>(Constants.Constants.BaseUrl);
        }

        static public MobileService getInstance()
        {
            if (instance == null)
                instance = new MobileService();

            return instance;
        }

        public async Task<UsersResponse> GetUsers(string gender, int count)
        {
            try
            {
                var result = await _mobileApi.GetRandomUsers(gender, count);
                return result;
            }
            catch (ApiException exception)
            {
                Debug.WriteLine(exception.Message);
                return null;
            }
        }

        public async Task<UsersResponse> GetUser()
        {
            try
            {
                var result = await _mobileApi.GetRandomUser();
                return result;
            }
            catch (ApiException exception)
            {
                Debug.WriteLine(exception.Message);
                return null;
            }
        }
    }
}
