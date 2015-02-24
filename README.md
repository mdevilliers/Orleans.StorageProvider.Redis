# Orleans.StorageProvider.Redis

An Orleans Storage Provider backed with Redis.

Usage
-----

Use the following attribute on classes you wish to be saved to redis

```
[StorageProvider(ProviderName = "RedisStore")]
```

Configuration
-------------

An example configuration is as follows -

```
<StorageProviders>
      <Provider Type="Orleans.StorageProvider.Redis.RedisStorageProvider" 
      	Name="RedisStore" 
      	KeySpace="{{optional - KeySpace to use in Redis - defaults to 'Orleans'}}" 
      	RedisIpAddress="{{required - IpAddress}} 
      	RedisPortNumber={{optional - Port - defaults to 6379}}"
        />
</StorageProviders>
```

