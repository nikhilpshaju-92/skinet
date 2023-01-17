using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using core.Entities;
using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
      
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
            
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();

            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GettProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
             return Ok(await _repo.GetProductBrandsAsync());
        }
          [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
             return Ok(await _repo.GetProductTypesAsync());
        }
    }
}