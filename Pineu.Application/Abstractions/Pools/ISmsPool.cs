namespace Pineu.Application.Abstractions.Pools;

public interface ISmsPool {
    Task<bool> AddCode(string phoneNumber, int code);
    Task<bool> AddDate(string phoneNumber, DateTime dateTime);
    Task<bool> RemoveCode(string phoneNumber);
    Task<bool> RemoveDate(string phoneNumber);
    Task<int?> GetCode(string phoneNumber);
    Task<DateTime?> GetDate(string phoneNumber);
}
