using Domain.Entities;
using Repository.CreateDTO;
using Repository.CreateDTOS;
using Repository.UpdateDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.InterFaces
{
    public interface IMovieService
    {
        Task<IReadOnlyList<Movie>> GetPagedMovie(IPagination<Movie> pagination);
        Task AddMovieAsync(CreateMovieDto createMovieDto);
        Task<IEnumerable<GetMovieDTO>> GetAllMoviesAsync();
        Task <GetMovieDTO> GetMovieByIdAsync (int id);
        Task<UpdateMovieDTO> UpdateMovie(int id,UpdateMovieDTO updateMovie);
        Task DeleteMovieId(int id);


    }
}
