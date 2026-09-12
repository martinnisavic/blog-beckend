namespace BlogApi
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public int DurationMinutes { get; set; }
    }
}
