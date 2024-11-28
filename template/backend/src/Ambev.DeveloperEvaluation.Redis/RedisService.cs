using StackExchange.Redis;
using Microsoft.Extensions.Configuration;
using Ambev.DeveloperEvaluation.Domain.Services;

public class RedisService : IRedisService
{
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _database;

    public RedisService(IConfiguration configuration)
    {
        // Aqui você configura o Redis, usando o hostname do Redis ou a string de conexão
        _redis = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
        _database = _redis.GetDatabase();
    }


    public void SetCache(string key, string value)
    {
        _database.StringSet(key, value);
    }

    // Função para buscar dados do Redis
    public string GetCache(string key)
    {
        return _database.StringGet(key);
    }

    // Função para verificar se a chave existe no Redis
    public bool KeyExists(string key)
    {
        return _database.KeyExists(key);
    }

    public void RemoveCache(string key)
    {
        _database.KeyDelete(key);
    }
}
