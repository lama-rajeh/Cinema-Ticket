using Repository.CreateDTOS;
using Repository.GetDTO;
using Repository.UpdateDTOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.InterFaces
{
    public interface IScheduleService
    {
        Task AddScheduleAsync(CreateScheduleDto createSchedule);
        Task <IEnumerable<GetScheduleDTO>> GetSchedulesAsync();
        Task<GetScheduleDTO> GetScheduleById (int id);  
        Task<UpdateScheduleDTO> UpdateScheduleAsync(UpdateScheduleDTO updateSchedule);
        Task DeleteScheduleAsync(int id);
        Task<List<GetListScheduleDTO>> GetListByDataAndCinema(DateOnly fromDate , DateOnly toDate);
    }
}
