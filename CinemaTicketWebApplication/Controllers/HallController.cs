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
    public class HallController : ControllerBase
    {
        private readonly IHallService _hallService;
        public HallController(IHallService hallService)
        {
            _hallService = hallService;
        }

        [HttpPost]
        [Route("Crate")]
        public async Task<IActionResult> AddHallAsync(CreateHallDto createHall)
        {
             await _hallService.AddHallAsync(createHall);
           return Ok(createHall);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllHall()
        {
            var getHall = await _hallService.GetAllHallAsync(); 
            return Ok(getHall);
        }

        [HttpGet]
        [Route("GetId") ]
        public async Task<IActionResult> GetIdHall(int id)
        {
            var HallId = await _hallService.GetHallByIdAsync(id);
            return Ok(HallId);
        }

        [HttpPost]
        [Route ("Update")]
        public async Task<IActionResult> UpdateHall(UpdateHallDTO updateHall)
        {
            var updatedHall = await _hallService.UpdateHall(updateHall);
            return Ok(updatedHall);
        }

        [HttpDelete]
        public  async Task<IActionResult> DeleteHall(int id)
        { 
           await _hallService.DeleteHallAsync(id);
            return Ok();
            
        }
    }
}
