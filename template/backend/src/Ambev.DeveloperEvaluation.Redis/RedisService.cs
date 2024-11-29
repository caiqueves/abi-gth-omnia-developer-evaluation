using StackExchange.Redis;
using Microsoft.Extensions.Configuration;
using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.Redis;
public class RedisService : IRedisService
{
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _database;

    public RedisService(IConfiguration configuration)
    {
        try
        {
            // Conecta ao Redis com as opções de configuração
            _redis = ConnectionMultiplexer.Connect($"localhost:6379,password=ev@luAt10n");
            _database = _redis.GetDatabase();

            // Obtém o banco de dados Redis
            _database = _redis.GetDatabase();
        }
        catch (RedisConnectionException ex)
        {
            // Lidar com falha na conexão
            throw new InvalidOperationException("Não foi possível conectar ao Redis.", ex);
        }
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
