using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Schedule_Movie
    {
        public int ScheduleId { get; set; } 
        public int MovieId { get; set; }

        public Schedule Schedule { get; set; } = null!;
        public Movie Movie { get; set; } = null!; 

    }
}
