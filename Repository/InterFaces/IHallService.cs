using Repository.CreateDTOS;
using Repository.GetDTO;
using Repository.UpdateDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.InterFaces
{
    public interface IHallService
    {
        Task AddHallAsync(CreateHallDto createHallDto);
         Task<IEnumerable<GetHallDTO>> GetAllHallAsync();
        Task <GetHallDTO> GetHallByIdAsync(int id);
        Task<UpdateHallDTO> UpdateHall(UpdateHallDTO updateHallDTO);
        Task DeleteHallAsync(int id);

    }
}
