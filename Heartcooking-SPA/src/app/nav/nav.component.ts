import { Component, OnInit } from '@angular/core';
import { UserForLogin } from './../models/user-for-login';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  userForLogin: UserForLogin = {};

  constructor() { }

  ngOnInit() {
  }

  login() {
    console.log(this.userForLogin);
  }

}
