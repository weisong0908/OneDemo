using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using OneDemo.MemoryCache.Caching;
using OneDemo.MemoryCache.Models;

namespace OneDemo.MemoryCache.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(CacheGet));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Use IMemoryCache
        public IActionResult CacheTryGetValueSet()
        {
            DateTime cacheEntry;

            if (!_memoryCache.TryGetValue(CacheKeys.Entry, out cacheEntry))
            {
                cacheEntry = DateTime.Now;

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                _memoryCache.Set(CacheKeys.Entry, cacheEntry, cacheEntryOptions);
            }

            return View("Cache", cacheEntry);
        }

        public IActionResult CacheGetOrCreate()
        {
            var cacheEntry = _memoryCache.GetOrCreate(CacheKeys.Entry, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);

                return DateTime.Now;
            });

            return View("Cache", cacheEntry);
        }

        public async Task<IActionResult> CacheGetOrCreateAsynchronous()
        {
            var cacheEntry = await _memoryCache.GetOrCreateAsync(CacheKeys.Entry, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);

                return Task.FromResult(DateTime.Now);
            });

            return View("Cache", cacheEntry);
        }

        public IActionResult CacheGet()
        {
            var cacheEntry = _memoryCache.Get<DateTime?>(CacheKeys.Entry);

            return View("Cache", cacheEntry);
        }

        public IActionResult CacheGetOrCreateAbs()
        {
            var cacheEntry = _memoryCache.GetOrCreate(CacheKeys.Entry, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);

                return DateTime.Now;
            });

            return View("Cache", cacheEntry);
        }

        public IActionResult CacheGetOrCreateAbsSliding()
        {
            var cacheEntry = _memoryCache.GetOrCreate(CacheKeys.Entry, entry =>
            {
                entry.SetSlidingExpiration(TimeSpan.FromSeconds(3));
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20);
                return DateTime.Now;
            });

            return View("Cache", cacheEntry);
        }

        public IActionResult CacheRemove()
        {
            _memoryCache.Remove(CacheKeys.Entry);

            return RedirectToAction(nameof(CacheGet));
        }

        #endregion

        #region Use eviction callback
        public IActionResult CreateCallbackEntry()
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetPriority(CacheItemPriority.NeverRemove)
                .RegisterPostEvictionCallback(EvictionCallback, this);

            _memoryCache.Set(CacheKeys.CallbackEntry, DateTime.Now, cacheEntryOptions);

            return RedirectToAction(nameof(GetCallbackEntry));
        }

        public IActionResult GetCallbackEntry()
        {
            return View("Callback", new CallbackViewModel()
            {
                CachedTime = _memoryCache.Get<DateTime?>(CacheKeys.CallbackEntry),
                Message = _memoryCache.Get<string>(CacheKeys.CallbackMessage)
            });
        }

        public IActionResult RemoveCallbackEntry()
        {
            _memoryCache.Remove(CacheKeys.CallbackEntry);

            return RedirectToAction(nameof(GetCallbackEntry));
        }

        private static void EvictionCallback(object key, object value, EvictionReason reason, object state)
        {
            var message = $"Entry was evicted. Reason: {reason}.";
            ((HomeController)state)._memoryCache.Set(CacheKeys.CallbackMessage, message);
        }
        #endregion

        #region Cache dependencies
        public IActionResult CreateDependentEntries()
        {
            var cts = new CancellationTokenSource();
            _memoryCache.Set(CacheKeys.DependentCTS, cts);

            using (var entry = _memoryCache.CreateEntry(CacheKeys.Parent))
            {
                entry.Value = DateTime.Now;
                entry.RegisterPostEvictionCallback(DependentEvictionCallback, this);

                _memoryCache.Set(CacheKeys.Child, DateTime.Now, new CancellationChangeToken(cts.Token));
            }

            return RedirectToAction(nameof(GetDependentEntries));
        }

        public IActionResult GetDependentEntries()
        {
            return View("Dependent", new DependentViewModel()
            {
                ParentCachedTime = _memoryCache.Get<DateTime?>(CacheKeys.Parent),
                ChildCachedTime = _memoryCache.Get<DateTime?>(CacheKeys.Child),
                Message = _memoryCache.Get<string>(CacheKeys.DependentMessage)
            });
        }

        public IActionResult RemoveChildEntry()
        {
            _memoryCache.Get<CancellationTokenSource>(CacheKeys.DependentCTS).Cancel();

            return RedirectToAction(nameof(GetDependentEntries));
        }

        private static void DependentEvictionCallback(object key, object value, EvictionReason reason, object state)
        {
            var message = $"Parent entry was evicted. Reason: {reason}.";
            ((HomeController)state)._memoryCache.Set(CacheKeys.DependentMessage, message);
        }
        #endregion
    }
}
