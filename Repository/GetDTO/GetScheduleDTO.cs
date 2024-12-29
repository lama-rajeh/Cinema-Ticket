using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GetDTO
{
    public class GetScheduleDTO
    {
        public int Id { get; set; }

        public DateOnly? Year { get; set; }

        public int? Week { get; set; }

        public int? CinemaId { get; set; }
    }
}
