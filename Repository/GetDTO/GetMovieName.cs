using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GetDTO
{
    public class GetMovieName
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public decimal? Duration { get; set; } = 0;
    }
}
