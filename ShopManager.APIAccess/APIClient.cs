using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.APIAccess
{
    public class APIClient : IAPIClient
    {
        private HttpClient client;
        private string apiAddress;

        public APIClient()
        {
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                apiAddress = ConfigurationManager.AppSettings["apiAddress"];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cant find api adress - ", ex);
            }

            client = new HttpClient();
            client.BaseAddress = new Uri(apiAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthUser> AuthenticateUser(string username, string password)
        {
            var form = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            using (var response = await client.PostAsync("/token", form))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<AuthUser>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
