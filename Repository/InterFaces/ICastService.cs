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
    public interface ICastService
    {
        Task AddCastAsync(CreateCastDto createCast);
        Task<IEnumerable<GetCastDTO>> GetCastsAsync();
        Task<GetCastDTO> GetByIdCast (int id); 
        Task<UpdateCastDTO> UpdateCastAsync(UpdateCastDTO updateCast);
        Task DeleteCastAsync(int id);
    }
}
