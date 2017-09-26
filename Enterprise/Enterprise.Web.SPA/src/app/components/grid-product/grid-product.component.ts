import { ProductCardViewModel } from './../../viewmodels/product-card/product-card.viewmodel';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-grid-product',
  templateUrl: './grid-product.component.html',
  styleUrls: ['./grid-product.component.css']
})
export class GridProductComponent implements OnInit {
  products: ProductCardViewModel[];
  constructor() {
    this.products = [];
  }

  ngOnInit() {
    this.fetchProducts();
  }
  fetchProducts() {
    for (let i = 0; i < 50; i++) {
      this.products.push(<ProductCardViewModel>{
        productName: 'Product ' + i,
        productPrice: Math.round(Math.random() * 100),
        productFavorite: Math.ceil(Math.random() * 100),
        productRating: (Math.random() * 5) + 1,
        productReview: Math.ceil(Math.random()) * 120
      });
    }
  }
}
