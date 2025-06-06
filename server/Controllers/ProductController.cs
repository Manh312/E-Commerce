using Microsoft.AspNetCore.Mvc;
using server.Entities;
using server.Dto;
using server.Interface.Repository;

namespace server.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        [Route("getallproduct")]
        public async Task<ActionResult<ResponseDto>> GetAllProducts()
        {
            ResponseDto responseDto = new ResponseDto();
            IEnumerable<Entities.Product> products = await _productRepository.GetAllAsync();

            responseDto.Data = products;
            return Ok(responseDto);
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<ActionResult<ResponseDto>> GetProduct(int productId)
        {
            ResponseDto responseDto = new ResponseDto();
            Entities.Product product = await _productRepository.GetByIdAsync(productId);

            responseDto.Data = product;
            return Ok(responseDto);
        }

        [HttpPost()]
        [Route("create")]
        public async Task<ActionResult<ResponseDto>> CreateProduct(Entities.Product newProduct)
        {
            ResponseDto responseDto = new ResponseDto();
            await _productRepository.AddAsync(newProduct);
            return Created();
        }

        [HttpPost()]
        [Route("update")]
        public async Task<ActionResult<ResponseDto>> UpdateProducts(Entities.Product product)
        {
            await _productRepository.UpdateAsync(product);
            return Ok();
        }

        [HttpDelete()]
        [Route("delete/{productId}")]
        public async Task<ActionResult<ResponseDto>> DeleteProducts(int productId)
        {
            ResponseDto responseDto = new ResponseDto();
            Entities.Product product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                responseDto.IsSuccessed = false;
                responseDto.Message = $"No product found with id {productId.ToString()}";
                return NotFound(responseDto);
            }

            await _productRepository.DeleteAsync(product);
            return Ok(responseDto);
        }
    }
}
