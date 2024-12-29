using AutoMapper;
using Domain.Entities;
using Repository.CreateDTOS;
using Repository.GetDTO;
using Repository.UpdateDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingProfiles
{
    public class MappingSchedule : Profile
    {
        public MappingSchedule()
        {
            CreateMap<CreateScheduleDto, Schedule>().ReverseMap();
            CreateMap<Schedule, GetScheduleDTO>().ReverseMap();
            CreateMap<Schedule, UpdateScheduleDTO>().ReverseMap();
            // CreateMap<Cinema,GetNameCinema>().ReverseMap();
            CreateMap<Movie, GetMovieNameBySchedule>().ReverseMap();
            CreateMap<Schedule,GetListScheduleDTO >().ReverseMap();


        }
    }
}
