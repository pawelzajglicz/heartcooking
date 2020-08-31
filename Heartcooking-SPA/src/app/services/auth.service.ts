import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { UserForLogin } from './../models/user-for-login';
import { UserLoginResponse } from './../models/user-login-response';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.baseUrl + 'auth/';

  constructor(private http: HttpClient) { }

  login(userForLogin: UserForLogin) {
    return this.http.post(this.baseUrl + 'login', userForLogin)
      .pipe(
        map((user: UserLoginResponse) => {

          if (user) {
            localStorage.setItem('token', user.token);
          }
        })
      );
  }
}
