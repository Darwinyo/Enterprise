import { ProductCardModel } from './../../models/product-card/product-card.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-grid-product',
  templateUrl: './grid-product.component.html',
  styleUrls: ['./grid-product.component.css']
})
export class GridProductComponent implements OnInit {
  products: ProductCardModel[];
  constructor() {
    this.products = [];
  }

  ngOnInit() {
    this.fetchProducts();
  }
  fetchProducts() {
    for (let i = 0; i < 50; i++) {
      this.products.push(<ProductCardModel>{
        productname: 'Product ' + i,
        price: Math.round(Math.random() * 100),
        favorites: Math.ceil(Math.random() * 100),
        ratestar: (Math.random() * 5) + 1,
        reviews: Math.ceil(Math.random()) * 120
      });
    }
  }
}
