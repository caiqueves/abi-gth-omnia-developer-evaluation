using StackExchange.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.Redis;

public class RedisService : IRedisService
{
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _database;
    private readonly ILogger<RedisService> _logger;

    public RedisService(IConfiguration configuration, ILogger<RedisService> logger)
    {
        _logger = logger;

        try
        {
            var connection = "localhost:6379";
            var password = configuration.GetValue<string>("Redis:RedisPass");

            ConfigurationOptions options = new ConfigurationOptions
            {
                EndPoints = { connection! },
                AbortOnConnectFail = false
            };

            if (!string.IsNullOrWhiteSpace(password))
            {
                options.Password = password;
            }

            _redis = ConnectionMultiplexer.Connect(options);
            _database = _redis.GetDatabase();

            _logger.LogInformation("Redis connected successfully to {Endpoint}", connection);
        }
        catch (RedisConnectionException ex)
        {
            _logger.LogError(ex, "Failed to connect to Redis");
            throw new InvalidOperationException("Não foi possível conectar ao Redis.", ex);
        }
    }

    public void SetCache(string key, string value, TimeSpan? expiry = null)
    {
        _database.StringSet(key, value, expiry);
        _logger.LogInformation("Set key {Key} in Redis", key);
    }

    public string GetCache(string key)
    {
        var value = _database.StringGet(key);
        _logger.LogInformation("Get key {Key} from Redis: {Value}", key, value);
        return value;
    }

    public bool KeyExists(string key)
    {
        var exists = _database.KeyExists(key);
        _logger.LogInformation("Key {Key} exists: {Exists}", key, exists);
        return exists;
    }

    public void RemoveCache(string key)
    {
        _database.KeyDelete(key);
        _logger.LogInformation("Removed key {Key} from Redis", key);
    }

    // Método de teste simples
    public bool TestConnection()
    {
        try
        {
            return _redis.IsConnected;
        }
        catch
        {
            return false;
        }
    }
}
