using AutoMapper;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Repository.GetDTO;
using Repository.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRepository
{
    public class Movie_CastService : IMovie_CastService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public Movie_CastService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<GetMovie_CastDTO>> GetCasts_ByMovieId(int MovieId)
        {
            var cast = await _context.Movie_Casts
                .Where(x => x.MovieId == MovieId)
                .Include(x => x.Cast )
                .Include(x => x.Movie )
                .ToListAsync();
            var mapped = _mapper.Map<List<GetMovie_CastDTO>>(cast);
           return mapped;
        }

        public async Task<List<GetMovie_CastDTO>>GetMovies_ByCastId(int CastId)
        {
            var movie =await _context.Movie_Casts
                .Where(x => x.CastId == CastId)
                .Include(x => x.Movie)
                .Include(x => x.Cast)
                .ToListAsync();
            var mapped = _mapper.Map<List<GetMovie_CastDTO>>(movie);
            return mapped;
        }

    }
}
