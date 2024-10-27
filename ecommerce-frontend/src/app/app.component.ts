import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <h1>E-Commerce App</h1>
    <nav>
      <a routerLink="/login">Login</a>
      <a routerLink="/register">Register</a>
      <a routerLink="/products">Products</a>
      <a routerLink="/cart">Cart</a>
    </nav>
    <router-outlet></router-outlet>
  `,
  styles: []
})
export class AppComponent {}
