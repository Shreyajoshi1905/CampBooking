using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastucture.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly StoreContext _context;
        public ProductController(StoreContext context){
            _context = context; 
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> GetProducts(){
            var product = await _context.Products.ToListAsync();
            return product;
        }
        [HttpGet("getproductwithid/{id}")]
        public async Task<ActionResult<ProductModel>> GetProductWithId(int id){
            return await _context.Products.FirstOrDefaultAsync(p=>p.Id == id);
        }

    }
}