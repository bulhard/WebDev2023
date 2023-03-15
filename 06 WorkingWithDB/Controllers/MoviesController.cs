using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _06_WorkingWithDB.Data;
using _06_WorkingWithDB.Models;

namespace _06_WorkingWithDB.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext appDbContext;

        public MoviesController(MvcMovieContext dbContext)
        {
            this.appDbContext = dbContext;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string SearchString)
        {
            MovieIndexViewModel viewModel = new MovieIndexViewModel
            {
                Title = "Movies",
                SearchString = SearchString
            };

            if (appDbContext.Movie != null)
            {
                var query = appDbContext.Movie.Select(m => m);

                if (!string.IsNullOrEmpty(SearchString))
                {
                    query = query.Where(m => m.Title != null && m.Title.Contains(SearchString));
                }

                viewModel.Movies = await query.ToListAsync();

                //var movies = await appDbContext.Movie
                //    .Where(m =>
                //        string.IsNullOrEmpty(SearchString)
                //        || (m.Title != null && m.Title.Contains(SearchString)))
                //    .ToListAsync();

                return View(viewModel);
            }
            else
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            //return appDbContext.Movie != null ?
            //            View(await appDbContext.Movie.ToListAsync()) :
            //            Problem("Entity set 'MvcMovieContext.Movie'  is null.");
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || appDbContext.Movie == null)
            {
                return NotFound();
            }

            var movie = await appDbContext.Movie
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                appDbContext.Add(movie);
                await appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || appDbContext.Movie == null)
            {
                return NotFound();
            }

            var movie = await appDbContext.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    appDbContext.Update(movie);
                    await appDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || appDbContext.Movie == null)
            {
                return NotFound();
            }

            var movie = await appDbContext.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (appDbContext.Movie == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }
            var movie = await appDbContext.Movie.FindAsync(id);
            if (movie != null)
            {
                appDbContext.Movie.Remove(movie);
            }

            await appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return (appDbContext.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}