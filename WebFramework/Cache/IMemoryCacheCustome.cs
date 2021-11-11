using Common.Interface;
using System;

namespace WebFramework
{
    public interface IMemoryCacheCustome : IScopedDependency
    {
        void Remove(object key);
        object Set(object key, object data, DateTime dateTime);
        object Get(object key);
    }
}
