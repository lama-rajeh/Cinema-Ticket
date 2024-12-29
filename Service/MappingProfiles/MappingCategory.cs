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
    public class MappingCategory :Profile
    {
        public MappingCategory()
        {
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<Category, GetCategoryDTO>().ReverseMap();
            //CreateMap<List<Category>, List<GetCategoryDTO>>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
        }
    }
}
