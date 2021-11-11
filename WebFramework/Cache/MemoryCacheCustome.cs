using Microsoft.Extensions.Caching.Memory;
using System;

namespace WebFramework
{
    public class MemoryCacheCustome : IMemoryCacheCustome
    {
        private IMemoryCache _memoryCache;
        public MemoryCacheCustome(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }
        public void Remove(object key)
        {
            _memoryCache.Remove(key);
        }
        public object Set(object key, object data, DateTime dateTime) 
        {
           return _memoryCache.Set(key, data, dateTime);
        }  
        public object Get(object key) 
        {
           return _memoryCache.Get(key);
        }
    }
}
