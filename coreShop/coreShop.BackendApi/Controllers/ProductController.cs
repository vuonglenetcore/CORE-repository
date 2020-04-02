using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreShop.Application.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreShop.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        public ProductController(IPublicProductService publicProductService)
        {
            _publicProductService = publicProductService;
        }
        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            var product = await _publicProductService.GetAll();
            return Ok(product);
        }
    }
}