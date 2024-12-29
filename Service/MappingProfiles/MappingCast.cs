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
    public class MappingCast :Profile
    {
        public MappingCast()
        {
            CreateMap< CreateCastDto ,Cast>().ReverseMap();  
            CreateMap<Cast , GetCastDTO>().ReverseMap();
            CreateMap<Cast , UpdateCastDTO>().ReverseMap();
        }
    }
}
