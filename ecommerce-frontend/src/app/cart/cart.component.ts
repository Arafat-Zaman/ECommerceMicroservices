import { Component, OnInit } from '@angular/core';
import { CartService } from './cart.service';
import { Product } from '../products/product.model';

@Component({
  selector: 'app-cart',
  template: `
    <h2>Your Cart</h2>
    <div *ngFor="let item of items">
      <h3>{{ item.name }}</h3>
      <p>Price: ${{ item.price }}</p>
    </div>
    <button (click)="checkout()">Checkout</button>
  `
})
export class CartComponent implements OnInit {
  items: Product[];

  constructor(private cartService: CartService) {}

  ngOnInit() {
    this.items = this.cartService.getItems();
  }

  checkout() {
    // Implement checkout logic here
    console.log('Checkout:', this.items);
  }
}
