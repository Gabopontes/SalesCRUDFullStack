import { Component, OnInit } from '@angular/core';
import { Sale } from '../../models/sale.model';
import { SaleService } from '../../services/sale.service';

@Component({
  selector: 'app-sale-list',
  standalone: false,
  templateUrl: './sale-list.component.html',
  styleUrl: './sale-list.component.css'
})
export class SaleListComponent implements OnInit {
  sales: Sale[] = [];

  constructor(private saleService: SaleService) { }

  ngOnInit(): void {
    this.loadSales();
  }

  loadSales(): void {
    this.saleService.getSales().subscribe(
      (data) => this.sales = data,
      (error) => console.error('Erro ao carregar vendas', error)
    );
  }

  cancelSale(id: string): void {
    this.saleService.cancelSale(id).subscribe(
      () => this.loadSales(), // Recarrega a lista após cancelar
      (error) => console.error('Erro ao cancelar venda', error)
    );
  }
}