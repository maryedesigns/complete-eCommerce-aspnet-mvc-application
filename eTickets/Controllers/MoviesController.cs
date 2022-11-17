using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Description, Price, ImageURL, StartDate, EndDate")] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await _service.AddAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetByIdAsync(id);

            if (movieDetails == null) return View("NotFound");
            return View(movieDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetByIdAsync(id);

            if (movieDetails == null) return View("NotFound");
            return View(movieDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Description, Price, ImageURL, StartDate, EndDate")] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await _service.UpdateAsync(id, movie);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var movieDetails = await _service.GetByIdAsync(id);

            if (movieDetails == null) return View("NotFound");
            return View(movieDetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var movieDetails = await _service.GetByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
