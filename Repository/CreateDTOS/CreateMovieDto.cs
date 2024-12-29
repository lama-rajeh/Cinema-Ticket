using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CreateDTOS
{
    public class CreateMovieDto
    {
        //public int Id { get; set; }

        public string? Title { get; set; }

        public string? Image { get; set; }

        public string? Description { get; set; }

        public decimal? Duration { get; set; } = 0; 
    }
}
