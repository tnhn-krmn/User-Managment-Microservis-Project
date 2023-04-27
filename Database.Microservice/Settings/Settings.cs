namespace Database.Microservice.Settings
{
    public class Settings
    {
        public class TokenSettings
        {
            public string Audience { get; set; }
            public string Issuer { get; set; }
            public string SecretKey { get; set; }
        }
    }
}
