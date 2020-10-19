import { Product } from './../models/product';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';

import { EnvConfigService } from './env-config.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseUrl: string;

  constructor(private envConfigService: EnvConfigService,
              private http: HttpClient) {

    this.envConfigService.getApiUrls$().subscribe((apiUrl: string) => {
      this.baseUrl = apiUrl;
    });
  }

  getProducts(): Observable<Product[]> {

    return this.http.get<Product[]>(this.baseUrl + 'products', httpOptions);
  }

  getProduct(id: number | string): Observable<Product> {

    return this.http.get<Product>(this.baseUrl + 'products/' + id, httpOptions);
  }
}
