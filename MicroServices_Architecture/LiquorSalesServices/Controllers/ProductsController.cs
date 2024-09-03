using AutoMapper;
using LiquorSalesService.Data;
using LiquorSalesService.Models;
using LiquorSalesService.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LiquorSaleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductViewDto>> SampleAllProducts()
        {
            var products = _productsRepository.GetAllProducts();

            return Ok(_mapper.Map<IEnumerable<ProductViewDto>>(products));
        }


        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductViewDto> GetProductById(string id)
        {
            var product = _productsRepository.GetProductsById(id);
            if (product != null)
            {
                return Ok(_mapper.Map<ProductViewDto>(product));
            }

            return NotFound();
        }


        [HttpPost]
        public ActionResult<ProductViewDto> CreateProduct(CreateProductDto createProduct)
        {
            var productModel = _mapper.Map<Products>(createProduct);
            _productsRepository.AddProduct(productModel);
            _productsRepository.SaveChanges();

            var productsView = _mapper.Map<ProductViewDto>(productModel);

            return CreatedAtRoute(nameof(GetProductById), new {Id = productsView.Id}, productsView);
        }

    }
}