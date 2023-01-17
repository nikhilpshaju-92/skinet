using core.Interfaces;
using core.Entities;

using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Data
{
    public class ProductRepository : IProductRepository
    {
        public StoreContext _context { get; }
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }


        public async Task<Product> GetProductByIdAsync(int id)
        {

          var selectedProduct = await _context.Product
             .Include(p => p.ProductType )
            .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id == id);
            return selectedProduct;
            // throw new System.NotImplementedException();
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {

            return await _context.Product
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();
            // throw new System.NotImplementedException();

        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductType.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrand.ToListAsync();
            //throw new NotImplementedException();
        }
    }
}