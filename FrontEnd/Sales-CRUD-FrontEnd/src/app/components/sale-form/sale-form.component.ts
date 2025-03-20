import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Sale } from '../../models/sale.model';
import { SaleService } from '../../services/sale.service';

@Component({
  selector: 'app-sale-form',
  standalone: false,
  templateUrl: './sale-form.component.html',
  styleUrl: './sale-form.component.css'
})
export class SaleFormComponent implements OnInit {
  saleForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private saleService: SaleService
  ) {
    this.saleForm = this.fb.group({
      saleNumber: ['', Validators.required],
      saleDate: ['', Validators.required],
      customerId: ['', Validators.required],
      branchId: ['', Validators.required],
      items: this.fb.array([])
    });
  }

  ngOnInit(): void {}

  onSubmit(): void {
    if (this.saleForm.valid) {
      const sale: Sale = this.saleForm.value;
      this.saleService.createSale(sale).subscribe(
        () => alert('Venda criada com sucesso!'),
        (error) => console.error('Erro ao criar venda', error)
      );
    }
  }
}
