using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneDemo.Razor.Models;
using OneDemo.Razor.Persistence;

namespace OneDemo.Razor.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly OneDemo.Razor.Persistence.MovieContext _context;

        public IndexModel(OneDemo.Razor.Persistence.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            var movies = _context.Movies.Select(m => m);

            var genreQuery = _context.Movies.OrderBy(m => m.Genre).Select(m => m.Genre);

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                movies = movies.Where(m => m.Title.Contains(SearchString));
            }

            if (!string.IsNullOrWhiteSpace(MovieGenre))
            {
                movies = movies.Where(m => m.Genre == MovieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
