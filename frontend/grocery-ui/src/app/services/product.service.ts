import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ProductService {
  private apiUrl = 'https://localhost:7211'; // 🔴 your backend port

  constructor(private http: HttpClient) {}

  getProducts() {
    return this.http.get<any[]>(`${this.apiUrl}/products`);
  }

  placeOrder(productId: number, quantity: number) {
    return this.http.post(`${this.apiUrl}/orders`, {
      productId,
      quantity
    });
  }
}
