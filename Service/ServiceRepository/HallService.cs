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
    public class HallService : IHallService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public HallService( IMapper mapper , AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddHallAsync(CreateHallDto createHallDto)
        {
            var mappedHall = _mapper.Map<Hall>(createHallDto);
            var hall = _context.Halls.Add(mappedHall);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetHallDTO>> GetAllHallAsync()
        {
            var getHall = await _context.Halls.ToListAsync(); 
            var mappedHall = _mapper.Map<IEnumerable<GetHallDTO>>(getHall);
            return mappedHall;
        }

        public async Task<GetHallDTO> GetHallByIdAsync(int id)
        {
            var HallId = await _context.Halls.FindAsync(id);
            var mapped = _mapper.Map<GetHallDTO>(HallId);
            return mapped;

        }

        public async Task<UpdateHallDTO> UpdateHall(UpdateHallDTO updateHallDTO)
        {
            var updateHall = _context.Halls.FirstOrDefault(x => x.Id == updateHallDTO.Id);
            var mappedHall = _mapper.Map(updateHallDTO , updateHall);
            await _context.SaveChangesAsync();
            var mapped = _mapper.Map<UpdateHallDTO>(mappedHall);
            return mapped;
        }

        public async Task DeleteHallAsync(int id)
        {
            var DeleteHall = await _context.Halls.FindAsync(id);
            //var mapHall = _mapper.Map<GetHallDTO>(DeleteHall);
            _context.Halls.Remove(DeleteHall);
            await _context.SaveChangesAsync();           
        }

    }
}
