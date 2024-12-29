using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UpdateDTOS
{
    public class UpdateScheduleDTO
    {
        public int Id { get; set; }

        public DateOnly? Year { get; set; }

        public int? Week { get; set; }

        public int? CinemaId { get; set; }
    }
}
