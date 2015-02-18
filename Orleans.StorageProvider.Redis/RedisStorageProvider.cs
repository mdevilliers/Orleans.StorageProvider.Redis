using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Orleans.Providers;
using Orleans.Runtime;
using Orleans.Storage;
using StackExchange.Redis;

namespace Orleans.StorageProvider.Redis
{
    public class RedisStorageProvider : IStorageProvider
    {
        private const string KeySpaceConfigurationKey = "KeySpace";
        private const string RedisIpAddressConfigurationKey = "RedisIpAddress";
        private const string RedisPortNumberConfigurationKey = "RedisPortNumber";
        private const string RedisPasswordConfigurationKey = "RedisPassword";

        private ConnectionMultiplexer _connectionMultiplexer;
        private string KeySpace = "Orleans";

        public async Task Init(string name, IProviderRuntime providerRuntime, IProviderConfiguration config)
        {
            var redisIpAddress = GetStringPropertyFromConfigurationThrowIfMissing(config, RedisIpAddressConfigurationKey);

            KeySpace = GetStringPropertyFromConfigurationWithDefault(config, KeySpaceConfigurationKey, KeySpace);

            var redisPortNumber = GetIntPropertyFromConfigurationWithDefault(config, RedisPortNumberConfigurationKey, 6379);
            var redisPassword = GetStringPropertyFromConfigurationWithDefault(config, RedisPasswordConfigurationKey, string.Empty);
            
            Log = providerRuntime.GetLogger(this.GetType().FullName);
            Log.Info(string.Format("Redis Storage Provider connecting to {0}:{1}", redisIpAddress, redisPortNumber));

            var configOptions = new ConfigurationOptions()
            {
                EndPoints = {
			        {
                        redisIpAddress, redisPortNumber
                    } 
                },
                Password = redisPassword
            };

            _connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(configOptions);
            Log.Info(string.Format("Redis Storage Provider connected to {0}:{1}", redisIpAddress, redisPortNumber));
        }

        public string Name { get; set; }
        public Task Close()
        {
            _connectionMultiplexer.Close(true);
            _connectionMultiplexer.Dispose();
            return TaskDone.Done;
        }

        public async Task ReadStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
        {
            var key = GenerateKey(grainReference);
            var value = await _connectionMultiplexer.GetDatabase().StringGetAsync(key);

            var data = new Dictionary<string, object>();

            if (value.HasValue)
            {
                data = JsonConvert.DeserializeObject<Dictionary<string, object>>(value);
            }

            grainState.SetAll(data);
        }

        public async Task WriteStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
        {
            var key = GenerateKey(grainReference);
            var data = grainState.AsDictionary();

            var json = JsonConvert.SerializeObject(data);

            await _connectionMultiplexer.GetDatabase()
                .StringSetAsync(key, json);
        }

        public async Task ClearStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
        {
            await _connectionMultiplexer.GetDatabase().KeyDeleteAsync(grainReference.ToKeyString());
        }

        public Logger Log { get; set; }

        private string GenerateKey(GrainReference grainReference)
        {
            return string.Format("{0}_{1}", KeySpace, grainReference.ToKeyString());
        }

        private string GetStringPropertyFromConfigurationWithDefault(IProviderConfiguration config, string key, string defaultValue)
        {
            if (config.Properties.ContainsKey(key))
            {
                return config.Properties[key];
            }
            return defaultValue;
        }

        private int GetIntPropertyFromConfigurationWithDefault(IProviderConfiguration config, string key, int defaultValue)
        {
            if (config.Properties.ContainsKey(key))
            {
                int ret = defaultValue;
                Int32.TryParse(config.Properties[key], out ret);
                return ret;
            }
            return defaultValue;
        }

        private string GetStringPropertyFromConfigurationThrowIfMissing(IProviderConfiguration config, string key)
        {
            if (config.Properties.ContainsKey(key))
            {
                return config.Properties[key];
            }
            var message = string.Format("Redis : Missing {0} from server configuration.", key);
            throw new Exception(message);
        }
    }
}
