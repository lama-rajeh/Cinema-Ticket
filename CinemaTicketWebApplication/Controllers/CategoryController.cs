using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.CreateDTOS;
using Repository.InterFaces;
using Repository.UpdateDTOS;
using Service.ServiceRepository;

namespace CinemaTicketWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService<Category> _categoryService;
        private readonly IPagination<Category> _Pagination;
        public CategoryController(ICategoryService<Category> categoryService, IPagination<Category> pagination)
        {
            _categoryService = categoryService;
            _Pagination = pagination;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategory)
        {
            await _categoryService.AddCategoryAsync(createCategory);
            return Ok(createCategory);
       
        }

        [HttpGet]
        [Route ("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory([FromQuery]Pagination<Category>pagination)
        {
            //_Pagination.pageNumber = pageNumber ?? _Pagination.pageNumber;
            //_Pagination.pageSize = pageSize ?? _Pagination.pageSize;
            _Pagination.pageNumber = pagination.pageNumber;
            _Pagination.pageSize = pagination.pageSize;

            var GetCategory = await _categoryService.GetAllCategory(_Pagination); 
            return Ok(GetCategory);
        }

        [HttpGet]
        [Route("GetId")]
        public async Task<IActionResult> GetCategoryID(int id)
        {
            var GetCategoryId = await _categoryService.GetCategoryId(id);
            return Ok(GetCategoryId);
        }

        [HttpPost]
        [Route("UpdateCategory")]
        public async Task<IActionResult> updateCategoryId( UpdateCategoryDTO updateCategoryDTO)
        {
            var updateCategory = await _categoryService.UpdateCategoryDTO( updateCategoryDTO);
            return Ok(updateCategory);
        }

        [HttpDelete]
        [Route ("DeletId")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
          var deletedCategory =  await _categoryService.DeleteCategoryAsync(id);
            return Ok(deletedCategory);
            
        }

    }
}
