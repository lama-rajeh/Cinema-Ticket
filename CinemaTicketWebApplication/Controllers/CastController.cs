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
    public class CastController : ControllerBase
    {
        private readonly ICastService _castService;
        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        [HttpPost]
        [Route ("Create")]
        public async Task<IActionResult> AddCast(CreateCastDto createCast)
        {
             await _castService.AddCastAsync(createCast);
            return Ok(createCast);
        }
        [HttpGet]
        [Route ("GetAll")]
        public async Task<IActionResult> GetAllCast()
        {
            var Cast = await _castService.GetCastsAsync();
            return Ok(Cast);
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetCastById(int id)
        {
            var cast = await _castService.GetByIdCast(id);
            return Ok(cast);
        }

        [HttpPost]
        [Route ("update")]
        public async Task<IActionResult> UpdateCast (UpdateCastDTO updateCast)
        {
            var cast = await _castService.UpdateCastAsync(updateCast);
            return Ok(cast);
        }

        [HttpDelete]
        [Route ("Delete")]
        public async Task<IActionResult> DeleteCast (int id)
        {
            await _castService.DeleteCastAsync(id);
            return Ok();
        }
    }
}
