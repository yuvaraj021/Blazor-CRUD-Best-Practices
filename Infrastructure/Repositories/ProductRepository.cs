using BlazorCRUD.Domain.Entities;
using BlazorCRUD.Domain.Interfaces;
using BlazorCRUD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Infrastructure.Respositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _context.Products.ToListAsync();

        public async Task<Product> GetByIdAsync(int id) =>
            await _context.Products.FindAsync(id);

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            // Detach existing tracked entities with the same key
            var trackedEntity = _context.ChangeTracker.Entries<Product>()
                .FirstOrDefault(e => e.Entity.Id == product.Id);

            if (trackedEntity != null)
            {
                _context.Entry(trackedEntity.Entity).State = EntityState.Detached;
            }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
