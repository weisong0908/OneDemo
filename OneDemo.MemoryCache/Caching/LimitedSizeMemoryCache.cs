using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace OneDemo.MemoryCache.Caching
{
    public class LimitedSizeMemoryCache
    {
        public Microsoft.Extensions.Caching.Memory.MemoryCache Cache { get; set; }

        public LimitedSizeMemoryCache()
        {
            Cache = new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions()
            {
                SizeLimit = 1024
            });
        }
    }
}