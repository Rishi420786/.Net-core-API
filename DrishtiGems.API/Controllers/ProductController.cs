using Common.CommonUtility;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dto;
using ServiceLayer.IServices;

namespace DrishtiGems.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        [Route("SaveProduct")]
        public async Task<IActionResult> SaveProduct(ProductDto product)
        {
            try
            {
                bool result = await _productService.AddRecord(product);
                if (result)
                {
                    return Ok(new OkResponse(CommonResource.ProductSaved));
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, CommonResource.Wrong);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(new OkResponse(CommonResource.Success, await _productService.GetAllRecords()));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetProductById")]
        public async Task<IActionResult> GetProductById(int? id)
        {
            try
            {
                return Ok(new OkResponse(CommonResource.Success, await _productService.GetRecordById(id)));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductDto product)
        {
            try
            {
                bool result = await _productService.UpdateRecord(product);
                if (result)
                {
                    return Ok(new OkResponse(CommonResource.ProductUpdated));
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, CommonResource.Wrong);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            try
            {
                bool result = await _productService.DeleteRecord(id);
                if (result)
                {
                    return Ok(new OkResponse(CommonResource.ProductDeleted));
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, CommonResource.Wrong);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
