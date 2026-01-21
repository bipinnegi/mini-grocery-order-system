import { Component, ChangeDetectorRef } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './app.html'
})
export class AppComponent {
  apiUrl = 'http://localhost:5042';

  products: any[] = [];
  message = '';

  constructor(
    private http: HttpClient,
    private cdr: ChangeDetectorRef
  ) {}

  // ✅ GET /products
  loadProducts() {
    this.http.get<any[]>(`${this.apiUrl}/products`)
      .subscribe({
        next: res => {
          this.products = res;
          this.cdr.detectChanges(); // ✅ correct
        },
        error: () => {
          this.message = 'Failed to load products';
          this.cdr.detectChanges(); // ✅ correct
        }
      });
  }

  // orders
  placeOrder(productId: number, quantity: number) {
  if (!quantity || quantity <= 0) {
    alert('Please enter a valid quantity');
    return;
  }

  this.http.post(`${this.apiUrl}/orders`, {
    productId,
    quantity: Number(quantity)
  }).subscribe({
    next: () => {
      alert('✅ Order placed successfully');
      this.loadProducts();
      this.cdr.detectChanges();
    },
    error: err => {
      alert(err.error?.message || '❌ Insufficient stock');
      this.cdr.detectChanges();
    }
  });
}


}
