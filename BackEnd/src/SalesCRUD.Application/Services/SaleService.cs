using SalesCRUD.Application.Dto;
using SalesCRUD.Application.Interfaces;
using SalesCRUD.Domain;
using SalesCRUD.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCRUD.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<SaleResponseDto> CreateSaleAsync(CreateSaleDto dto)
        {
            var sale = new Sale(dto.SaleNumber, dto.SaleDate, dto.CustomerId, dto.BranchId);

            foreach (var itemDto in dto.Items)
            {
                sale.AddItem(itemDto.ProductId, itemDto.Quantity, itemDto.UnitPrice);
            }

            sale.ApplyDiscounts();

            await _saleRepository.AddAsync(sale);

            return MapToSaleResponseDto(sale);
        }

        public async Task<SaleResponseDto> GetSaleAsync(Guid id)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null)
            {
                return null;
            }

            return MapToSaleResponseDto(sale);
        }

        public async Task<SaleResponseDto> UpdateSaleAsync(Guid id, UpdateSaleDto dto)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null)
            {
                return null;
            }

            // Atualiza os campos da venda
            sale.Update(dto.SaleNumber, dto.SaleDate, dto.CustomerId, dto.BranchId);

            await _saleRepository.UpdateAsync(sale);

            return MapToSaleResponseDto(sale);
        }

        public async Task<bool> CancelSaleAsync(Guid id)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null)
            {
                return false;
            }

            sale.Cancel();
            await _saleRepository.UpdateAsync(sale);
            return true;
        }

        private SaleResponseDto MapToSaleResponseDto(Sale sale)
        {
            return new SaleResponseDto
            {
                Id = sale.Id,
                SaleNumber = sale.SaleNumber,
                SaleDate = sale.SaleDate,
                CustomerId = sale.CustomerId,
                BranchId = sale.BranchId,
                TotalAmount = sale.TotalAmount,
                IsCancelled = sale.IsCancelled,
                Items = sale.Items.Select(item => new SaleItemResponseDto
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalAmount = item.TotalAmount
                }).ToList()
            };
        }
    }
}
