import { ProductCardModel } from './../../models/product-card/product-card.model';
import { Component, OnInit } from '@angular/core';

const pageLength = 1200;
const itemLength = 200;
@Component({
  selector: 'app-list-product-card',
  templateUrl: './list-product-card.component.html',
  styleUrls: ['./list-product-card.component.css']
})

export class ListProductCardComponent implements OnInit {
  products: ProductCardModel[];
  marginleft: number;

  constructor() {
    this.products = [];
    this.marginleft = 0;
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
  prevbtnclicked() {
    if (0 < (this.marginleft + pageLength)) {
      this.marginleft = 0;
    } else {
      this.marginleft += pageLength;
    }
  }
  nextbtnclicked() {
    if (this.marginleft - pageLength < ((this.products.length * -itemLength) + pageLength)) {
      this.marginleft = (this.products.length * -itemLength) + pageLength;
    } else {
      this.marginleft -= pageLength;
    }
  }

}
