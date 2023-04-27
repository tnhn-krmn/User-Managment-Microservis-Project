using Newtonsoft.Json;
using Presentation.Microservice.DTO;
using Presentation.Microservice.Service.Abstract;
using System.Text;

namespace Presentation.Microservice.Service.Concrete
{
    public class UserManager : IUserService
    {
        public async Task<bool> UserAdd(LoginDTO user, string token)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7003");


            HttpContent body = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = client.PostAsync("/User/UserAdd", body).Result;
            var dataa = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                if (data != null)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UserDelete(UserUpdateDto user, string token)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7003");


            HttpContent body = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = client.PostAsync("/User/UserDelete", body).Result;
            var dataa = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                if (data != null)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UserUpdate(UserUpdateDto user, string token)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7003");


            HttpContent body = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = client.PostAsync("/User/UserUpdate", body).Result;
            var dataa = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                if (data != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
