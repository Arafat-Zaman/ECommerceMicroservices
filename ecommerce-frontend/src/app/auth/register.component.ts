import { Component } from '@angular/core';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  template: `
    <div>
      <h2>Register</h2>
      <form (ngSubmit)="register()">
        <input type="text" [(ngModel)]="username" placeholder="Username" name="username" required />
        <input type="password" [(ngModel)]="password" placeholder="Password" name="password" required />
        <button type="submit">Register</button>
      </form>
    </div>
  `
})
export class RegisterComponent {
  username: string;
  password: string;

  constructor(private authService: AuthService, private router: Router) {}

  register() {
    this.authService.register(this.username, this.password).subscribe(() => {
      this.router.navigate(['/login']);
    }, err => {
      console.error('Registration failed', err);
    });
  }
}
