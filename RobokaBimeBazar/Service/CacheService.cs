using System;
using System.Runtime.Caching;
using RobokaBimeBazar.Service.Interface;

namespace RobokaBimeBazar.Service
{
    public class CacheService : ICacheService
    {
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            return GetOrSet<T>(cacheKey, 180, getItemCallback);
        }

        public T GetOrSet<T>(string cacheKey, int minutes, Func<T> getItemCallback) where T : class
        {
            var item = MemoryCache.Default.Get(cacheKey) as T;
            if (item != null) return item;

            item = getItemCallback();
            if (item != null)
            {
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(minutes));
            }
            return item;
        }
    }
}
