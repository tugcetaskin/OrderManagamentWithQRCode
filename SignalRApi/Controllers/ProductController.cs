using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.ProductDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDTO>>(_productService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("AvarageMainMealPrice")]
        public IActionResult AvarageMainMealPrice()
        {
            return Ok(_productService.TAvarageMainMealPrice());
        }

        [HttpGet("HighestPriceProduct")]
        public IActionResult HighestPriceProduct()
        {
            return Ok(_productService.THighestPriceProduct());
        }

        [HttpGet("LowestPriceProduct")]
        public IActionResult LowestPriceProduct()
        {
            return Ok(_productService.TLowestPriceProduct());
        }

        [HttpGet("AvarageProductPrice")]
        public IActionResult AvarageProductPrice()
        {
            return Ok(_productService.TAvarageProductPrice());
        }
        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            return Ok(_productService.TGetProductCount());
        }

        [HttpGet("ProductCountByCategoryMain")]
        public IActionResult ProductCountByCategoryMain()
        {
            return Ok(_productService.TProductNumberByCategoryMain());
        }

        [HttpGet("ProductCountByCategoryDessert")]
        public IActionResult ProductCountByCategoryDessert()
        {
            return Ok(_productService.TProductNumberByCategoryDessert());
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var value = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDTO productDTO)
        {
            var value = _mapper.Map<Product>(productDTO);
            _productService.TAdd(value);
            return Ok("Ürün Başarılı Bir Şekilde Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDTO productDTO)
        {
            var value = _mapper.Map<Product>(productDTO);
            _productService.TUpdate(value);
            return Ok("Ürün Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _mapper.Map<GetProductDTO>(_productService.TGetById(id));
            return Ok(value);
        }

        [HttpGet("GetNineProduct")]
        public IActionResult GetNineProduct()
        {
            var result = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetNineProducts());
            return Ok(result);
        }
    }
}
