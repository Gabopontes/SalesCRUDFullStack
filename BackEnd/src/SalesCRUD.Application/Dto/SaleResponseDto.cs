using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCRUD.Application.Dto
{
    public class SaleResponseDto
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public List<SaleItemResponseDto> Items { get; set; } = new List<SaleItemResponseDto>();
    }

    public class SaleItemResponseDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
