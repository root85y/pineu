using Pineu.Application.Abstractions.Pools;
using Shared.Constants;
using StackExchange.Redis;

namespace Pineu.Persistence.Pools {
    internal class SmsPool : ISmsPool {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _db;

        public SmsPool() {
            _redis = ConnectionMultiplexer.Connect(DBSettings.RedisConfigs.ConnectionString);
            _db = _redis.GetDatabase();
        }

        public async Task<bool> AddCode(string phoneNumber, int code) =>
            await _db.HashSetAsync(DBSettings.RedisConfigs.SmsPoolKey, phoneNumber, code);

        public async Task<bool> AddDate(string phoneNumber, DateTime dateTime) =>
            await _db.HashSetAsync(DBSettings.RedisConfigs.SmsDateKey, phoneNumber, dateTime.ToString());

        public async Task<int?> GetCode(string phoneNumber) {
            var res = await _db.HashGetAsync(DBSettings.RedisConfigs.SmsPoolKey, phoneNumber);
            if (res.IsNull) return null;

            return int.Parse(res!);
        }

        public async Task<DateTime?> GetDate(string phoneNumber) {
            var res = await _db.HashGetAsync(DBSettings.RedisConfigs.SmsDateKey, phoneNumber);
            if (res.IsNull) return null;

            return DateTime.Parse(res!);
        }

        public async Task<bool> RemoveCode(string phoneNumber) =>
            await _db.HashDeleteAsync(DBSettings.RedisConfigs.SmsPoolKey, phoneNumber);

        public async Task<bool> RemoveDate(string phoneNumber) =>
            await _db.HashDeleteAsync(DBSettings.RedisConfigs.SmsDateKey, phoneNumber);
    }
}
