import { element } from 'protractor';
import { ProductModel } from './../../models/product/product/product.model';
import { ProductCardViewModel } from './../../viewmodels/product-card/product-card.viewmodel';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

const pageLength = 1200;
const itemLength = 200;
@Component({
  selector: 'app-list-product-card',
  templateUrl: './list-product-card.component.html',
  styleUrls: ['./list-product-card.component.css']
})

export class ListProductCardComponent implements OnInit {
  @Output() reviewEvent: EventEmitter<string>;
  products: ProductCardViewModel[];
  marginleft: number;
  constructor() {
    this.reviewEvent = new EventEmitter();
    this.products = [];
    this.marginleft = 0;
  }

  ngOnInit() {
  }
  InitProductCardModel(products: ProductCardViewModel[]) {
    products.forEach(item => {
      if (item.productName.length > 18) {
        item.productName = item.productName.substring(0, 18) + '...'
      }
      this.products = products;
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
  EmitReviewEvent(productId: string) {
    this.reviewEvent.emit(productId)
  }
}
