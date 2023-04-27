using Newtonsoft.Json;
using Presentation.Microservice.DTO;
using Presentation.Microservice.Service.Abstract;
using System.Text;

namespace Presentation.Microservice.Service.Concrete
{
    public class AuthManager : IAuthService
    {
        public async Task<string> GetLogin(LoginDTO user)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7003");


            HttpContent body = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = client.PostAsync("/Authentication/UserAuthentication", body).Result;
            var dataa = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                if (data != null)
                {
                    return data;
                }
            }
            return null;
        }
    }
}
