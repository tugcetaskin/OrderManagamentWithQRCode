using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.CategoryDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDTO>>(_categoryService.TGetListAll());
            return Ok(values);
        }

        

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO categoryDTO)
        {
            categoryDTO.Status = true;
            var value = _mapper.Map<Category>(categoryDTO);
            _categoryService.TAdd(value);
            return Ok("Yeni Kategori Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.TGetById(id);
            _categoryService.TDelete(category);
            return Ok("Kategori Silindi.");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDTO categoryDTO)
        {
            var value = _mapper.Map<Category>(categoryDTO);
            _categoryService.TUpdate(value);
            return Ok("Kategori Güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _mapper.Map<GetCategoryDTO>(_categoryService.TGetById(id));
            return Ok(value);
        }

    }
}
