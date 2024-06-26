using ExamenDDI_Ale.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamenDDI_Ale.Controllers
{
    public class MovieCallController : Controller
    {
        private readonly TMDbService _tmdbService;

        public MovieCallController(TMDbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        public async Task<IActionResult> NowPlaying()
        {
            var movies = await _tmdbService.GetNowPlayingMoviesAsync();
            return View(movies);
        }
    }
}

/* 
APB Ardillas por doquier

ven mas cerca y mirarme bailar
Main in the mirror
*/