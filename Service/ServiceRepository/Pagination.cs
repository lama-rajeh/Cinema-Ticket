using Microsoft.EntityFrameworkCore;
using Repository.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRepository
{
    public class Pagination <T> : IPagination <T> where T : class
    {
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 5;
        public int maxPageSize { get ; set ; } = 10;

        async Task<IReadOnlyList<T>> IPagination<T>.ApplyPagination(IQueryable<T> data)
        {
            var PageSize = pageSize > maxPageSize ? maxPageSize : pageSize;
            return await data.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToListAsync();
        }
    }
}
