import { Component, OnInit } from '@angular/core';
import { UserForLogin } from './../models/user-for-login';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  userForLogin: UserForLogin = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  login() {

    this.authService.login(this.userForLogin).subscribe(next => {
      console.log('Logged in successfully');
    }, error => {
      console.log('Failed to login');
    });
  }

}
