namespace Pineu.API.Constants {
    internal static class JwtConfigs {
        public static string JwtIssuer { get; } = "Pineu";
        public static string JwtKey { get; } = "ea0ff21a-f35b-4086-856a-d3b2c5c9882e";
        public static int JwtExpire { get; } = 30;
        public static int RefreshTokenExpire { get; } = 2;
    }
}
