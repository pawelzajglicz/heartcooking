import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Product } from '../../models/product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  products: Product[];

  constructor(private http: HttpClient) { }

  ngOnInit() {

    this.getProducts();
  }

  getProducts(): void {

    this.http.get('http://localhost:5000/api/products').subscribe((response: Product[]) => {
      this.products = response;
    }, error => {
      console.log(error);
    });
  }

}
