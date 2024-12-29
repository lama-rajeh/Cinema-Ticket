using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.CreateDTO;
using Repository.CreateDTOS;
using Repository.InterFaces;
using Repository.UpdateDTOS;
using Service.ServiceRepository;

namespace CinemaTicketWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase 
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]

        public async Task<IActionResult> GetPagedMovies(int pageNumber = 1, int pageSize = 10)
        {
            var pagination = new Pagination<Movie>
            {
                pageNumber = pageNumber,
                pageSize = pageSize
            };

            var movies = await _movieService.GetPagedMovie(pagination);
            return Ok(movies);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateMovie(CreateMovieDto createMovieDto)
        {
                await  _movieService.AddMovieAsync(createMovieDto);
           return Ok(createMovieDto);
           
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllMovie()
        {
            var movie = await _movieService.GetAllMoviesAsync();

            return Ok(movie);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetMovieId(int id)
        {
            var movieId = await _movieService.GetMovieByIdAsync(id);
            return Ok(movieId);
        }

        [HttpPost]
        [Route ("Update")]
        public async Task<IActionResult> updateMovie(int id , [FromBody]UpdateMovieDTO updateMovie)
        {
            var updatemovie = await _movieService.UpdateMovie(id, updateMovie);
            return Ok(updatemovie);
        }
        [HttpDelete]
        [Route("Delete")]

        public async Task<IActionResult> DeleteMovie (int id)
        {
             await _movieService.DeleteMovieId(id);
            return Ok();
        }

    }

}
