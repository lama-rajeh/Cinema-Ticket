using AutoMapper;
using Domain.Entities;
using Repository.GetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingProfiles
{
    public class MappingMovie_Cast : Profile
    {
        public MappingMovie_Cast()
        {
            //CreateMap<Movie, GetMovie_CastDTO>().ReverseMap(); انت كنتي كاتبة هيك
            CreateMap<Movie_Cast, GetMovie_CastDTO>().ReverseMap();
            CreateMap<Cast, GetCastName>().ReverseMap();
        CreateMap<Movie ,GetMovieName>().ReverseMap();  

        }
    }
}
