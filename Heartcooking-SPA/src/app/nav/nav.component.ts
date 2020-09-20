import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { UserForLogin } from './../models/user-for-login';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  userForLogin: UserForLogin = {};

  constructor(private authService: AuthService,
              private router: Router) { }

  ngOnInit() {
  }

  login() {

    this.authService.login(this.userForLogin).subscribe(next => {
      console.log('Logged in successfully');
    }, error => {
      console.log(error);
    });
  }

  loggedIn(): boolean {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/home']);
  }
}
