import { element } from 'protractor';
import { ProductModel } from './../../models/product/product/product.model';
import { ProductCardModel } from './../../models/product-card/product-card.model';
import { Component, OnInit, Input } from '@angular/core';

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
  }
  ConvertToProductCardModel(products: ProductModel[]) {
    products.forEach(item => {
      if (item.productName.length > 18) {
        item.productName = item.productName.substring(0, 18) + '...'
      }
      this.products.push(
        <ProductCardModel>{
          productId: item.productId,
          productname: item.productName,
          price: item.productPrice,
          imageUrl: item.productFrontImage,
          ratestar: item.productRating,
          favorites: item.productFavorite,
          reviews: item.productReview
        }
      )
    });
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
