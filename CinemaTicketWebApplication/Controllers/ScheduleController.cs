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
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        [HttpPost]
        [Route ("Create")]
        public async Task<IActionResult> AddSchedule ([FromQuery]CreateScheduleDto createSchedule)
        {
           await _scheduleService.AddScheduleAsync(createSchedule);
            return Ok(createSchedule);
        }
        [HttpGet]
        [Route ("GetAll")]
        public async Task<IActionResult> GetAllSchedule()
        {
            var Schedule = await _scheduleService.GetSchedulesAsync();
            return Ok(Schedule);
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetScheduleById(int id) 
        {
            var SchedulId = await _scheduleService.GetScheduleById(id);
            return Ok(SchedulId);
        }
        [HttpPost]
        [Route ("Update")]
        public async Task<IActionResult> UpdateSchedule (UpdateScheduleDTO updateSchedule)
        {
            var Schedule = await _scheduleService.UpdateScheduleAsync(updateSchedule);
            return Ok (Schedule);
        }
        [HttpDelete]
        [Route("Delete")]
        public  async Task<IActionResult> DeleteSchedule(int id) 
        {
            await _scheduleService.DeleteScheduleAsync(id);
            return Ok();

        }
        [HttpGet]
        [Route("GetListByDataAndCinema")]
        public async Task<IActionResult> GetListByDataAndCinema(DateOnly fromDate , DateOnly toDate)
        {
            var Schedule = await _scheduleService.GetListByDataAndCinema(fromDate, toDate);
            return Ok(Schedule);
        }
    }
}
