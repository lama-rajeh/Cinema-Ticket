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
    public interface ICinemaService
    {
        Task AddCinemaAsync(CreateCinemaDto createCinema);
        Task<IEnumerable<GetCinemaDTO>> GetAllCinemaAsync ();
        Task<GetCinemaDTO> GetByIdCinema(int id);
        Task<UpdateCinemaDTO> UpdateCinemaAsync(UpdateCinemaDTO updateCinema);
        Task <List<GetCinemaDTO>> GetCinemaByName(string search);
        Task <List<GetCinemaByMovieName>> GetCinemaByMovieName (string search);
     

    }
}
