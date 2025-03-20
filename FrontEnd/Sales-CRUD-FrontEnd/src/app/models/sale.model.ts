export interface Sale {
    id: string;
    saleNumber: string;
    saleDate: Date;
    customerId: string;
    branchId: string;
    totalAmount: number;
    isCancelled: boolean;
    items: SaleItem[];
  }
  
  export interface SaleItem {
    productId: string;
    quantity: number;
    unitPrice: number;
    totalAmount: number;
  }