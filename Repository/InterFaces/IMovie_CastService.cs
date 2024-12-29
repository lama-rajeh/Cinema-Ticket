using Repository.GetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.InterFaces
{
    public interface IMovie_CastService
    {
        Task<List<GetMovie_CastDTO>> GetMovies_ByCastId(int CastId);
        Task<List<GetMovie_CastDTO>> GetCasts_ByMovieId(int MovieId);
    }
}
