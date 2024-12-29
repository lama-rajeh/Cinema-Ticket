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
    public class CastService : ICastService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public CastService(IMapper mapper , AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddCastAsync(CreateCastDto createCast)
        {
            var mappedCast = _mapper.Map<Cast>(createCast);
            var cast =  _context.Casts.AddAsync(mappedCast);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<GetCastDTO>> GetCastsAsync()
        {
            var getCast = await _context.Casts.ToListAsync();
            var mapped = _mapper.Map<IEnumerable<GetCastDTO>>(getCast);
            return mapped;
        }

        public async Task<GetCastDTO> GetByIdCast(int id)
        {
            var getIdCast = await _context.Casts.FindAsync(id);
            var mapped = _mapper.Map<GetCastDTO>(getIdCast);
            return mapped;
        }

        public async Task<UpdateCastDTO> UpdateCastAsync(UpdateCastDTO updateCastdto)
        {
            var updatedCast = _context.Casts.FirstOrDefault(x => x.Id == updateCastdto.Id);
            var mappedCast = _mapper.Map(updateCastdto,updatedCast);
            await _context.SaveChangesAsync();
            var mapping = _mapper.Map<UpdateCastDTO>(mappedCast);
            return mapping;


        }

        public async Task DeleteCastAsync(int id)
        {
            var deletedCast = await _context.Casts.FindAsync(id);
            //var mapCast = _mapper.Map<GetCastDTO>(deletedCast);
            _context.Casts.Remove(deletedCast);
            await _context.SaveChangesAsync();
        }
    }
}
