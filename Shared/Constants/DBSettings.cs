namespace Shared.Constants {
    public static class DBSettings {
        public const string ApplicationDbContextConnectionString = "Server=pineu.db;Database=main;Uid=root;Pwd=89309df4-7a2d-45a9-800e-d697572db520";
        public static class RedisConfigs {
            public const string ConnectionString = "pineu.redis";
            public const string SmsPoolKey = "SmsPool";
            public const string SmsDateKey = "SmsDate";
        }
    }
}
