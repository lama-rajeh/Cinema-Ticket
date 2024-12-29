using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UpdateDTOS
{
    public class UpdateCinemaDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Image { get; set; }

        public string? Location { get; set; }
    }
}
