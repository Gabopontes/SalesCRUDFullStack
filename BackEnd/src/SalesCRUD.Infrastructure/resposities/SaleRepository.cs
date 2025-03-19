using Microsoft.EntityFrameworkCore;
using SalesCRUD.Domain;
using SalesCRUD.Infrastructure.Context;
using SalesCRUD.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCRUD.Infrastructure.resposities
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DeveloperStoreContext _context;

        public SaleRepository(DeveloperStoreContext context)
        {
            _context = context;
        }

        public async Task<Sale> GetByIdAsync(Guid id)
        {
            return await _context.Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sale sale)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var sale = await GetByIdAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
            }
        }
    }
}
