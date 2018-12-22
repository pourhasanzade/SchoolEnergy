using System;

namespace RobokaBimeBazar.Service.Interface
{
    public interface ICacheService
    {
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class;
        T GetOrSet<T>(string cacheKey, int minutes, Func<T> getItemCallback) where T : class;
    }
}
