namespace Saucedemo_Csharp_Bdd.Configurations
{
    public class TestSettings
    {
        public required string Browser { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Headless { get; set; }
        public required string BaseUrl { get; set; }
        public float SlowMo { get; set; }
    }
}
