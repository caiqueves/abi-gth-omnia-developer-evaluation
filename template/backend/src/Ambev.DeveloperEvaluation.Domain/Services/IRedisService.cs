
namespace Ambev.DeveloperEvaluation.Domain.Services
{

    public interface IRedisService
    {
        void SetCache(string key, string value);
        string GetCache(string key);
        bool KeyExists(string key);
        void RemoveCache(string key);
    }
}
