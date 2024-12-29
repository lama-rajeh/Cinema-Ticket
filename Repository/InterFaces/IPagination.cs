using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.InterFaces
{
    public interface IPagination<T> where T : class 
    
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int maxPageSize { get; set; }

       Task<IReadOnlyList<T>>  ApplyPagination(IQueryable<T> data);

    }
}
