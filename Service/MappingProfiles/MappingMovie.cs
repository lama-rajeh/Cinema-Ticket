using AutoMapper;
using Domain.Entities;
using Repository.CreateDTO;
using Repository.CreateDTOS;
using Repository.UpdateDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingProfiles
{
    public class MappingMovie :Profile
    {
        public MappingMovie()
        {
            CreateMap<Movie, GetMovieDTO>().ReverseMap();
            CreateMap<CreateMovieDto, Movie>().ReverseMap();
            CreateMap<UpdateMovieDTO, Movie>().ReverseMap();

        }
    }
}
