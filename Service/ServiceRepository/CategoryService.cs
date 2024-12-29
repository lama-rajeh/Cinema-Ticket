using AutoMapper;
using Domain.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.CreateDTOS;
using Repository.GetDTO;
using Repository.InterFaces;
using Repository.UpdateDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRepository
{
    public class CategoryService<T>  : ICategoryService<T> where T : class
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        

        public CategoryService(IMapper mapper, AppDbContext context )
        {
            _mapper = mapper;
            _context = context;
            
        }

        public async Task AddCategoryAsync(CreateCategoryDto Createcategory)
        { 
            //var Category = new Category();
            //Category.Name = Createcategory.Name;
            var mappedcategory = _mapper.Map<Category>(Createcategory);
            var Addcategory = _context.Categories.Add(mappedcategory);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetCategoryDTO>> GetAllCategory(IPagination<T> pagination)
        {
            //var CategoryAll = await _context.Categories.ToListAsync();
            var query =  _context.Categories.AsQueryable();
            var paginatedData = await pagination.ApplyPagination((IQueryable<T>)query);
            var CategoryMapp = _mapper.Map<List<GetCategoryDTO>>(paginatedData);

            return CategoryMapp;
        }

        public async Task<GetCategoryDTO> GetCategoryId(int id)
        {
            var GetCategory = await _context.Categories.FindAsync(id);
            var CategoryMapp = _mapper.Map<GetCategoryDTO>(GetCategory);
            return CategoryMapp;
        }

        public async Task<UpdateCategoryDTO> UpdateCategoryDTO(UpdateCategoryDTO UpdateCategory)
        {
            var categoryUpdate = _context.Categories.FirstOrDefault(x => x.Id == UpdateCategory.Id);
            //if (UpdateCategory.Name != null)
            //{
            //    UpdateCategory.Name = UpdateCategory.Name + "Lama";
            //}
            var mappCategory = _mapper.Map(UpdateCategory, categoryUpdate);

            await _context.SaveChangesAsync();
            var updatedCategory = _mapper.Map<Category, UpdateCategoryDTO>(mappCategory);

            return updatedCategory;
        }

        public async Task<GetCategoryDTO> DeleteCategoryAsync(int id)
        {
            var deleteCategory =  await _context.Categories.FindAsync(id);
            var deletmapp= _mapper.Map<GetCategoryDTO>(deleteCategory);
            

            _context.Categories.Remove(deleteCategory);
            
            await _context.SaveChangesAsync();
            return deletmapp;
        }

       
    }
}

