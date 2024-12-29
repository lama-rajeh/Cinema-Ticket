using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GetDTO
{
    public class GetListScheduleDTO
    {
        public int Id { get; set; }
        public DateOnly? Year { get; set; }
        public int? Week { get; set; }
        public TimeOnly? FromTime { get; set; }
        public TimeOnly? ToTime { get; set; }
        //public int? CinemaId { get; set; }
        //public virtual GetNameCinema? Cinema { get; set; }
        public  ICollection<GetMovieNameBySchedule>? Movies { get; set; } = null;
    }
}
