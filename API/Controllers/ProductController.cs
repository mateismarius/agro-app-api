using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Category> _brandsRepository;
        private readonly IGenericRepository<ProductType> _typeRepository;
        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepository, IMapper mapper, 
                                IGenericRepository<Category> brandRepository,
                                IGenericRepository<ProductType> typeRepository)
        {
            _productRepository = productRepository;
            _brandsRepository = brandRepository;
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        // This endpoint retrieves all products with optional filtering and pagination.
        // It takes 'productParams' as a query parameter, which can contain filtering and sorting options.
        [HttpGet("/products")]
        public async Task<ActionResult<Pagination<Product>>> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            // Specifications to filter products and count them with given parameters
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductsWithFiltersForCountSpecification(productParams);

            // Get the total number of items and the filtered product list
            var totalItems = await _productRepository.CountAsync(countSpec);
            var products = await _productRepository.ListAsync(spec);

            // Return the paginated product list
            return Ok(new Pagination<Product>(productParams.PageIndex, productParams.PageSize,
                totalItems, products));
        }

        // This endpoint retrieves a single product by its ID, along with associated type and brand information.
        [HttpGet("/product/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            // Create a specification with the product ID
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            // Fetch the product using the specification
            var product = await _productRepository.GetEntityWithSpec(spec);

            // Return 404 Not Found if the product does not exist
            if (product == null) return NotFound(new ApiResponse(404));

            // Return the product
            return product;
        }

        // This endpoint retrieves a list of all product brands.
        [HttpGet("/products/brands")]
        public async Task<ActionResult<Category>> GetCategorys()
        {
            // Fetch all product brands
            var brands = await _brandsRepository.ListAllAsync();

            // Return the list of product brands
            return Ok(brands);
        }

        // This endpoint retrieves a list of all product types.
        [HttpGet("/products/types")]
        public async Task<ActionResult<Category>> GetProductTypes()
        {
            // Fetch all product types
            var types = await _typeRepository.ListAllAsync();

            // Return the list of product types
            return Ok(types);
        }

    }
}
