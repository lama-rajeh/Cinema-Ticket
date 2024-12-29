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
    public class MappingHall : Profile
    {
        public MappingHall()
        {
            CreateMap <CreateHallDto ,Hall>().ReverseMap();
            CreateMap<Hall , GetHallDTO>().ReverseMap();
            CreateMap<Hall, UpdateHallDTO>().ReverseMap();  
        }
    }
}
