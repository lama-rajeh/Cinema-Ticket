using Domain.Entities;
using Repository.CreateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GetDTO
{
    public class GetMovie_CastDTO
    {
       // public int CastId { get; set; }

       // public int MovieId { get; set; }

      //  public int? Type { get; set; }

        public GetCastName Cast { get; set; } = null!;

        public GetMovieName Movie { get; set; } = null!;
    }
}
