using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace OneDemo.RedisCache.Pages
{
    public class IndexModel : PageModel
    {
        public string CachedTimeUTC { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly IDistributedCache _distributedCache;

        public IndexModel(ILogger<IndexModel> logger, IDistributedCache distributedCache)
        {
            _logger = logger;
            _distributedCache = distributedCache;
        }

        public async Task OnGetAsync()
        {
            CachedTimeUTC = "Cached Time Expired";

            var encodedCachedTimeUTC = await _distributedCache.GetAsync("cachedTimeUTC");

            if (encodedCachedTimeUTC != null)
                CachedTimeUTC = Encoding.UTF8.GetString(encodedCachedTimeUTC);
        }

        public async Task<IActionResult> OnPostResetCachedTime()
        {
            var currentTimeUTC = DateTime.UtcNow.ToString();
            byte[] encodedCachedTimeUTC = Encoding.UTF8.GetBytes(currentTimeUTC);
            var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(20));

            await _distributedCache.SetAsync("cachedTimeUTC", encodedCachedTimeUTC, options);

            return RedirectToPage();
        }
    }
}
