using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CreateDTOS
{
    public class CreateScheduleDto
    {
        // public int Id { get; set; }
        //public DateOnly? Year { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int? Week { get; set; }
        //public int? dayOfWeek { get; set; }
        public int? CinemaId { get; set; }
    }
}
