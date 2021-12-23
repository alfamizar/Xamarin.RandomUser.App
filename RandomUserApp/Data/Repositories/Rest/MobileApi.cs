using RandomUserApp.Domain.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace RandomUserApp.Data.Repositories.Rest
{
    public class MobileApi
    {
        private readonly IMobileApi _mobileApi;

        public MobileApi()
        {
            _mobileApi = RestService.For<IMobileApi>(Constants.Constants.BaseUrl);
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
    }
}
