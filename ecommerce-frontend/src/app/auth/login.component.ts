import { Component } from '@angular/core';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  template: `
    <div>
      <h2>Login</h2>
      <form (ngSubmit)="login()">
        <input type="text" [(ngModel)]="username" placeholder="Username" name="username" required />
        <input type="password" [(ngModel)]="password" placeholder="Password" name="password" required />
        <button type="submit">Login</button>
      </form>
    </div>
  `
})
export class LoginComponent {
  username: string;
  password: string;

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    this.authService.login(this.username, this.password).subscribe(res => {
      localStorage.setItem('access_token', res.token);
      this.router.navigate(['/products']);
    }, err => {
      console.error('Login failed', err);
    });
  }
}
