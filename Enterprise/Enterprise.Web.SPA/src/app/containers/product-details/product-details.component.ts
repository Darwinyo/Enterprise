import { ProductInfoDetailsModel } from './../../models/product-info-details/product-info-details.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  ProductItem: ProductInfoDetailsModel;
  constructor() {
    this.ProductItem = <ProductInfoDetailsModel>{};
  }

  ngOnInit() {
    this.ProductItem.location = 'Shanghai';
    this.ProductItem.productPrice = 2000;
    this.ProductItem.productTitle = 'CPU';
    this.ProductItem.ratestar = 4;
    this.ProductItem.reviews = 1000;
    this.ProductItem.stock = 1020;
    this.ProductItem.variations = ['Black', 'White', 'Blue', 'Red'];
  }

}
