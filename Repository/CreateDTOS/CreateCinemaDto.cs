using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CreateDTOS
{
    public class CreateCinemaDto
    {
        public string Name { get; set; } = null!;

        public string? Image { get; set; }

        public string? Location { get; set; }
    }
}
