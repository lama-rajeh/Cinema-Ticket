using Domain.Entities;
using Repository.CreateDTOS;
using Repository.GetDTO;
using Repository.UpdateDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.InterFaces
{
    public interface ICategoryService < T> where T : class
    {
        Task AddCategoryAsync(CreateCategoryDto Createcategory);
        Task<List <GetCategoryDTO>> GetAllCategory( IPagination<T> pagination);
        Task <GetCategoryDTO> GetCategoryId(int id);
        Task <UpdateCategoryDTO> UpdateCategoryDTO(UpdateCategoryDTO UpdateCategory);

        Task <GetCategoryDTO> DeleteCategoryAsync(int id);


    }
}
