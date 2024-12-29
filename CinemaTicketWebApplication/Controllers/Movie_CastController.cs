using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repository.InterFaces;

namespace CinemaTicketWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Movie_CastController : ControllerBase
    {
        private readonly IMovie_CastService _movieCastService;
        public Movie_CastController( IMovie_CastService movieCastService)
        {
            _movieCastService = movieCastService; 
        }
        [HttpGet]
        [Route("GetMoviesByCastId")]
        public async Task<IActionResult> GetMoviesByCastId(int id)
        { 
            var movie = await _movieCastService.GetMovies_ByCastId(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("GetCastsByMovieId")]
        public async Task<IActionResult> GetCastsByMovieId(int id) 
        { 
            var cast = await _movieCastService.GetCasts_ByMovieId(id);
            return Ok(cast);
        }

        
    }
}
