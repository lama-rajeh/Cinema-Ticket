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
    public class ScheduleService : IScheduleService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public ScheduleService(IMapper mapper , AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddScheduleAsync(CreateScheduleDto createSchedule)
        {//createSchedule

            var mapping = _mapper.Map<Schedule>(createSchedule);
            mapping.Year = new DateOnly(createSchedule.year,createSchedule.month,createSchedule.day);
            mapping.CreatedDate = DateTime.Now;
            mapping.CreatedBy = "Malak";
            var AddSchedule = _context.Schedules.Add(mapping);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetScheduleDTO>> GetSchedulesAsync()
        {
            var getSchule = await _context.Schedules.Where(x=>x.IsDeleted==false).ToListAsync();
            var mapped = _mapper.Map<IEnumerable<GetScheduleDTO>>(getSchule);
            return mapped;
        }
        public async Task<GetScheduleDTO> GetScheduleById(int id)
        {
            var GetIdSchule = await _context.Schedules.FindAsync(id);
            var mapped = _mapper.Map<GetScheduleDTO>(GetIdSchule);
            return mapped;
        }

        public async Task<UpdateScheduleDTO> UpdateScheduleAsync(UpdateScheduleDTO updateSchedule)
        {
            
            var UpdatedSchedule = _context.Schedules.FirstOrDefault(x =>x.Id == updateSchedule.Id);
            if (UpdatedSchedule != null)
            {
            UpdatedSchedule.UpdateBy = "Malak";
            UpdatedSchedule.UpDateDate = DateTime.Now;
            }
            var mappSchedule = _mapper.Map(updateSchedule,UpdatedSchedule);
            await _context.SaveChangesAsync();
            var mapped = _mapper.Map<UpdateScheduleDTO>(mappSchedule);
            return mapped;
        }

        public async Task DeleteScheduleAsync(int id)
        {
            var DeletedSchedule = await _context.Schedules.FindAsync(id);
            DeletedSchedule.IsDeleted = true;
            DeletedSchedule.DeletedDate = DateTime.Now;
            DeletedSchedule.DeletedBy = "Malak";
            //var mapped = _mapper.Map<GetScheduleDTO>(DeletedSchedule);
             _context.Remove(DeletedSchedule);  
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetListScheduleDTO>> GetListByDataAndCinema(DateOnly fromDate, DateOnly toDate)
        {
            var listDataCinema = await _context.Schedules.Where(x=>x.Year >= fromDate && x.Year <= toDate && x.Movies.Count > 0)
                .Include(x=>x.Movies)
                .ToListAsync();
            var mapped = _mapper.Map<List<GetListScheduleDTO>>(listDataCinema);
            return mapped;

        }
    }
}
