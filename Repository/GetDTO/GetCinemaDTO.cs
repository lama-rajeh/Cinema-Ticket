using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GetDTO
{
    public class GetCinemaDTO
    {
      //  public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Image { get; set; }

        public string? Location { get; set; }
    }
}
