using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using core.Entities;
using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase


    {
    
        
        private readonly StoreContext _context;
      
          public ProductsController(StoreContext context)
    {
            _context = context;
           

    }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products =await _context.Product.ToListAsync();
        
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GettProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            return Ok(product); 
        }
        
    }
}