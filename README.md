# Orleans.StorageProvider.Redis

An Orleans Storage Provider backed with Redis.

Notice
------

This project is no longer actively maintained. I urge you to use https://github.com/OrleansContrib/Orleans.StorageProvider.Redis instead.


Nuget
-----

To install from nuget

```
Install-Package Orleans.StorageProvider.Redis
```

To build the nuget package

```
cd Orleans.StorageProvider.Redis
..\.nuget\NuGet.exe pack Orleans.StorageProvider.Redis.csproj
```

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
      	RedisPortNumber="{{optional - Port - defaults to 6379}}"
      	RedisPassword={{optional}}"
        />
</StorageProviders>
```


