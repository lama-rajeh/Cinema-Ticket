using AutoMapper;
using Domain.Data;
using Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.CreateDTO;
using Repository.CreateDTOS;
using Repository.InterFaces;
using Repository.UpdateDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRepository
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _Context;
        public MovieService(IMapper mapper, AppDbContext Context)
        {
            _mapper = mapper;
            _Context = Context;
        }

        public async Task AddMovieAsync(CreateMovieDto createMovieDto)
        {

            var addMapped = _mapper.Map<Movie>(createMovieDto);
            var addmovie = _Context.Movies.Add(addMapped);

            await _Context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<GetMovieDTO>> GetAllMoviesAsync()
        {
            var movie = await _Context.Movies
                  //.Include (m => m.Movie_Casts)
                  //.Include(m => m.Movie_Halls)
                  //.Include(m => m.Categories)
                  //.Include(m => m.Schedules)
                  .ToListAsync();
            var mapped = _mapper.Map<IEnumerable<GetMovieDTO>>(movie);
            return mapped;

        }

        public async Task<GetMovieDTO> GetMovieByIdAsync(int id)
        {
            var movieId = await _Context.Movies
                //.Include(m => m.Movie_Casts)
                //.Include(m => m.Movie_Halls)
                //.Include(m => m.Categories)
                //.Include(m => m.Schedules)
                .FirstOrDefaultAsync(x => x.Id == id);
            var mapprdId = _mapper.Map<GetMovieDTO>(movieId);
            return mapprdId;

        }

        public async Task<UpdateMovieDTO> UpdateMovie(int id, UpdateMovieDTO updateMovie)
        {
            var updatemovie = _Context.Movies.FindAsync(id, updateMovie);
            var mappedupdate = _mapper.Map<UpdateMovieDTO>(updatemovie);
            await _Context.SaveChangesAsync();
            return mappedupdate;
        }

        public async Task DeleteMovieId(int id)
        {
            var deletemovie = await _Context.Movies.FindAsync(id);
            var mappeddeleted = _mapper.Map<GetMovieDTO>(deletemovie);
            _Context.Movies.Remove(deletemovie);
            await _Context.SaveChangesAsync();
            

        }

        public async Task<IReadOnlyList<Movie>> GetPagedMovie(IPagination<Movie> pagination)
        {
            var query = _Context.Movies.AsQueryable();
            return await pagination.ApplyPagination(query);
        }

        
    }


}
