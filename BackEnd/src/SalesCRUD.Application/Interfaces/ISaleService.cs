using SalesCRUD.Application.Dto;
using SalesCRUD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCRUD.Application.Interfaces
{
    public interface ISaleService
    {
        Task<SaleResponseDto> CreateSaleAsync(CreateSaleDto dto);
        Task<SaleResponseDto> GetSaleAsync(Guid id);
        Task<SaleResponseDto> UpdateSaleAsync(Guid id, UpdateSaleDto dto);
        Task<bool> CancelSaleAsync(Guid id);
    }
}
