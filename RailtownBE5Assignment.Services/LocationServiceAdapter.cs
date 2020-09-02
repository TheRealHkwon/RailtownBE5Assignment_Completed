using RailtownBE5Assignment.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RailtownBE5Assignment.Services
{
    public class LocationServiceAdapter : ILocationServiceAdapter
    {
        HttpClient _httpClient;

        public LocationServiceAdapter()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IUser[]> GetUsers(string url)
        {
            HttpResponseMessage usersResponse = await _httpClient.GetAsync(url);

            if (!usersResponse.IsSuccessStatusCode)
            {
                throw new HttpResponseException(usersResponse);
            }

            User[] users = await usersResponse.Content.ReadAsAsync<User[]>();

            return users;
        }
    }
}
