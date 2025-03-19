﻿using SalesCRUD.Domain;

namespace SalesCRUD.Infrastructure.Interfaces
{
    public interface ISaleRepository
    {
        Task<Sale> GetByIdAsync(Guid id);
        Task AddAsync(Sale sale);
        Task UpdateAsync(Sale sale);
        Task DeleteAsync(Guid id);
    }
}