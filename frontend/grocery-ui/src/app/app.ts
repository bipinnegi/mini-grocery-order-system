import { Component, OnInit } from '@angular/core';
import { ProductService } from './services/product.service';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class AppComponent implements OnInit {
  products: any[] = [];
  message = '';

  constructor(private service: ProductService) {}

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.service.getProducts().subscribe(data => {
      this.products = data;
    });
  }

  order(productId: number) {
    this.service.placeOrder(productId, 1).subscribe({
      next: () => this.message = 'Order placed successfully',
      error: err => this.message = err.error
    });
  }
}
