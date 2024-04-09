using AutoMapper;
using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CategoriesController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            // Map DTO to Domain Model
            //var category = new Category
            //{
            //    Name = request.Name,
            //    UrlHandle = request.UrlHandle,
            //};

            var cat = mapper.Map<Category>(request);
            // Domain Model to DTO           
            await dbContext.Categories.AddAsync(cat);
            await dbContext.SaveChangesAsync();
           
            //var response = new CategoryDto
            //{
            //    Id = category.Id,
            //    Name = category.Name,
            //    UrlHandle = category.UrlHandle,
            //};
            var rsp = mapper.Map<CategoryDto>(cat);
            return Ok(rsp);
        }
    }
}
