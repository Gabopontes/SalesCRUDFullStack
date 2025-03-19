using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCRUD.Application.Dto
{
    public class UpdateSaleDto
    {
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
    }
}
