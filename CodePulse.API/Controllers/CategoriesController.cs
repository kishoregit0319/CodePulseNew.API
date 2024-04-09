using AutoMapper;
using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
         
        private readonly IMapper mapper;
        private readonly ICategoryRepository CatRepo;

        public CategoriesController( IMapper mapper, ICategoryRepository CatRepo)
        {
            this.mapper = mapper;
            this.CatRepo = CatRepo;
        }
        //https://localhost:7142/api/Categories
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
           if( request is null)
            {
                return BadRequest("Send Valid Data");
            }
           if(!ModelState.IsValid) {

                return BadRequest(ModelState.Values
                    .SelectMany(val => val.Errors)
                    .Select(err => err.ErrorMessage).ToList());            
            }
            var catReq = mapper.Map<Category>(request);
            var rsp = mapper.Map<CategoryDto>( await CatRepo.CreateAsync(catReq));
            
            return Ok(rsp);
        }
        // get: api/categories
        // https://localhost:7142/api/Categories
        [HttpGet]

        public async Task<IActionResult> Categories()
        {
            var lstObj = await CatRepo.GetAllAsync();
            var rsp = mapper.Map<IEnumerable<CategoryDto>>(lstObj);
            return Ok(rsp); 
        }
    }
}
