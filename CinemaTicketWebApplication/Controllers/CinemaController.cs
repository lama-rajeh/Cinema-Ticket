using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repository.CreateDTOS;
using Repository.InterFaces;
using Repository.UpdateDTOS;

namespace CinemaTicketWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;
        public CinemaController( ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> addAllCinema(CreateCinemaDto createCinema) 
        {
            await _cinemaService.AddCinemaAsync(createCinema);
            return Ok(createCinema);    
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllCinema()
        {
            var Cinema = await _cinemaService.GetAllCinemaAsync();
            return Ok(Cinema);
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id) 
        {
            var GetByIdCinema = await _cinemaService.GetByIdCinema(id);
            return Ok(GetByIdCinema);
        }
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetCinemaSearch(string search)
        {
            var searchCinema = await _cinemaService.GetCinemaByName(search);
            return Ok(searchCinema);
        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateCinema(UpdateCinemaDTO updateCinema) 
        {
            var updatedCinema = await _cinemaService.UpdateCinemaAsync(updateCinema);
            return Ok(updatedCinema);
        }

        [HttpGet]
        [Route ("GetCinemaByMovieName")]
        public async Task<IActionResult> GetCinema(string search)
        {
            var GetCinema = await _cinemaService.GetCinemaByMovieName(search);
            return Ok (GetCinema);
        }
    }
}
