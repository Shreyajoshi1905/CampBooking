using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Data
{
    public class ProductRepository : IProductRepository
    {
        private  readonly StoreContext _context;
        public ProductRepository(StoreContext context){
            _context = context;
        }
        public async Task<IReadOnlyList<ProductModel>> GetAllProducts()
        {
           return await _context.Products.Include(p=> p.CampCity).ToListAsync();
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            return await _context.Products.Include(p=> p.CampCity).FirstOrDefaultAsync(p=> p.Id == id);
        }
        public async Task<IReadOnlyList<CampCity>>GetCampCity(){
            return await _context.CampCities.ToListAsync();
        }
    }
}