using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace FFRKApi.Data.Api
{
    public interface ICacheProvider
    {
        bool Flush();

        bool KeyExists(string key);

        bool StringSet(string key, string value);
        string StringGet(string key);

        bool ObjectSet<T>(string key, T value);
        T ObjectGet<T>(string key);
    }

    public class CacheProvider : ICacheProvider
    {
        #region Statics
        private static readonly Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(_connectionString);
            });
        private static ConnectionMultiplexer Connection => lazyConnection.Value;

        private static string _connectionString;
        #endregion

        #region Class Variables

        private IDatabase _db;
        private readonly bool _isConnected = true;
        private readonly bool _useCache;
        private readonly TimeSpan _defaultTimeToLive;
        private readonly ILogger<CacheProvider> _logger;
        #endregion

        #region Constructors
        public CacheProvider(IOptions<CachingOptions> cachingOptionsAccessor, ILogger<CacheProvider> logger)
        {
            CachingOptions cachingOptions = cachingOptionsAccessor.Value;
            _connectionString = cachingOptions.ConnectionString;
            _defaultTimeToLive = TimeSpan.FromHours(Double.Parse(cachingOptions.DefaultTimeToLiveInHours));
            _useCache = Boolean.Parse(cachingOptions.UseCache);

            _logger = logger;

            if (_useCache)
            {
                _isConnected = Connection.IsConnected;
                if (_isConnected)
                {
                    _db = Connection.GetDatabase();
                }
            }
            else
            {
                _isConnected = false;
            }


        }
        #endregion

        #region ICacheProvider Implementation

        public bool Flush()
        {
            bool flushed = false;

            try
            {
                if (_isConnected)
                {
                    var endpoint = Connection.GetEndPoints().FirstOrDefault();
                    if (endpoint != null)
                    {
                        Connection.GetServer(endpoint).FlushDatabase();
                        flushed = true;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleCacheError(ex);
            }
            return flushed;
        }

        public bool KeyExists(string key)
        {
            bool keyExists = false;

            if (_isConnected)
            {
                try
                {
                    keyExists = _db.KeyExists(key);
                }
                catch (Exception ex)
                {
                    HandleCacheError(ex);
                }
            }
            return keyExists;
        }

        public bool StringSet(string key, string value)
        {
            bool stringWasSet = false;

            if (_isConnected)
            {
                try
                {
                    stringWasSet = _db.StringSet(key, value, _defaultTimeToLive);
                }
                catch (Exception ex)
                {
                    HandleCacheError(ex);
                }
            }
            return stringWasSet;
        }

        public string StringGet(string key)
        {
            string value = null;

            if (_isConnected)
            {
                try
                {
                    RedisValue redisValue = _db.StringGet(key);

                    if (!redisValue.IsNullOrEmpty)
                    {
                        value = redisValue.ToString();
                    }
                }
                catch (Exception ex)
                {
                    HandleCacheError(ex);
                }
            }
            return value;
        }

        public bool ObjectSet<T>(string key, T value)
        {
            bool objectWasSet = false;

            if (_isConnected)
            {
                try
                {
                    if (value != null)
                    {
                        string valueAsString = JsonConvert.SerializeObject(value);

                        objectWasSet = StringSet(key, valueAsString);
                    }
                }
                catch (Exception ex)
                {
                    HandleCacheError(ex);
                }
            }

            return objectWasSet;
        }

        public T ObjectGet<T>(string key)
        {
            T value = default(T);

            if (_isConnected)
            {
                try
                {
                    string valueAsString = StringGet(key);

                    if (valueAsString != null)
                    {
                        //turn string back to the requested object
                        value = JsonConvert.DeserializeObject<T>(valueAsString);
                    }
                }
                catch (Exception ex)
                {
                    HandleCacheError(ex);
                }
            }

            return value;
        }
        #endregion

        #region Private Methods

        private void HandleCacheError(Exception ex)
        {
            _logger.LogError(ex, "Exception encountered trying to use Cache.");
        }

        #endregion
    }
}
