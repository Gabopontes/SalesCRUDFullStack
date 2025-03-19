using Microsoft.AspNetCore.Mvc;
using SalesCRUD.Application;
using System;
using System.Threading.Tasks;
using SalesCRUD.Application.Dto;
using SalesCRUD.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ISaleService _saleService;

    public SalesController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleDto dto)
    {
        var sale = await _saleService.CreateSaleAsync(dto);
        return Ok(sale);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSale(Guid id)
    {
        var sale = await _saleService.GetSaleAsync(id);
        if (sale == null)
        {
            return NotFound();
        }
        return Ok(sale);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSale(Guid id, [FromBody] UpdateSaleDto dto)
    {
        var sale = await _saleService.UpdateSaleAsync(id, dto);
        if (sale == null)
        {
            return NotFound();
        }
        return Ok(sale);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> CancelSale(Guid id)
    {
        var result = await _saleService.CancelSaleAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}