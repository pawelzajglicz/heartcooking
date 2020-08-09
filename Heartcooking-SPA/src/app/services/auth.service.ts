import { UserForLogin } from './../models/user-for-login';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

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
        map((response: any) => {

          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
          }
        })
      );
  }
}
