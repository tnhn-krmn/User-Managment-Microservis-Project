using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using User.Microservice.Dto;
using User.Microservice.Service.Abstract;

namespace User.Microservice.Service.Concrete
{
    public class UserManager : IUserService
    {
        public async Task<bool> UserAdd(UserDto user, string token)
        {
            if(token == null) return false;

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            httpClient.BaseAddress = new Uri("https://localhost:7024");


            HttpContent body = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("/api/Users/UserAdd", body).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                if (data != null)
                {
                    var objectData = JsonConvert.DeserializeObject<UserDto>(data);

                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UserDelete(UserUpdateDto user)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024");


            HttpContent body = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = client.PostAsync("/api/Users/UserDelete", body).Result;
            //var dataa = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                if (data != null)
                {
                    var objectData = JsonConvert.DeserializeObject<UserDto>(data);

                    return true;
                }
            }
            return false;
        }

        public async Task<UserDto> UserUpdate(UserUpdateDto user)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024");


            HttpContent body = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = client.PostAsync("/api/Users/UserUpdate", body).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                if (data != null)
                {
                    var objectData = JsonConvert.DeserializeObject<UserDto>(data);

                    return objectData;
                }
            }
            return null;
        }
    }
}
