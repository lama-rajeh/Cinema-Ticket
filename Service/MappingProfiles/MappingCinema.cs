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
    public class MappingCinema : Profile
    {
        public MappingCinema()
        {
            CreateMap<Cinema, CreateCinemaDto>().ReverseMap();
            CreateMap<Cinema,GetCinemaDTO>().ReverseMap();
            CreateMap<Cinema , UpdateCinemaDTO>().ReverseMap();
            CreateMap <Cinema , GetCinemaByMovieName>().ReverseMap();
        }
    }
}
