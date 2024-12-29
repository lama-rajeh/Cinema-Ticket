using AutoMapper;
using Domain.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.CreateDTOS;
using Repository.GetDTO;
using Repository.InterFaces;
using Repository.UpdateDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRepository
{
    public class CinemaService : ICinemaService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public CinemaService( IMapper mapper , AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddCinemaAsync(CreateCinemaDto createCinema)
        {
            var mapped = _mapper.Map<Cinema>(createCinema);
            var AddCinema =  _context.Cinemas.Add(mapped);
           await _context.SaveChangesAsync();   

        }

        public async Task<IEnumerable<GetCinemaDTO>> GetAllCinemaAsync()
        {
            var GetCineme = await _context.Cinemas.ToListAsync();
            var mappedCinema = _mapper.Map<IEnumerable<GetCinemaDTO>>(GetCineme);
            return mappedCinema;
        }

        public async Task<GetCinemaDTO> GetByIdCinema(int id)
        {
            var GetCinemaId = await _context.Cinemas.FindAsync(id);
            var mapped = _mapper.Map<GetCinemaDTO>(GetCinemaId);
            return mapped;
        }

        public async Task<List<GetCinemaDTO>> GetCinemaByName(string search)
        {
            var GetCinemaName = await _context.Cinemas
                .Where(x => x.Name.ToLower().Contains( search.ToLower()) ||
               x.Location.ToLower().Contains(search.ToLower()))
              .ToListAsync();
            var mapped = _mapper.Map<List<GetCinemaDTO>>(GetCinemaName);
            return mapped;
        }

        public async Task<UpdateCinemaDTO> UpdateCinemaAsync(UpdateCinemaDTO updateCinema)
        {
            var CinemaUpdate =  _context.Cinemas.FirstOrDefault(x => x.Id == updateCinema.Id);
            var mappedCinema = _mapper.Map(updateCinema, CinemaUpdate);
            await _context.SaveChangesAsync();
            var mapped = _mapper.Map<UpdateCinemaDTO>(mappedCinema);
            return mapped;
        }
        public async Task<List<GetCinemaByMovieName>> GetCinemaByMovieName(string search)
        {
            var cinema = await _context.Cinemas
                .Include(x => x.Schedules)
                .ThenInclude(x => x.Movies)
                .ThenInclude(x => x.Schedules_Movie)
                 .Where(c => c.Schedules.Any(x=>x.Schedules_Movie.Any(s => s.Movie.Title == search)))
                 .Select(x=>x.Name)
                 .ToListAsync();
            var mapped = _mapper.Map<List<GetCinemaByMovieName>>(cinema);
            return mapped;
        }

    }

}
