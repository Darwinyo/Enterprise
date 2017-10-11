import { Router } from '@angular/router';
import { ProductCardViewModel } from './../../viewmodels/product-card/product-card.viewmodel';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent implements OnInit {
  @Input() productCard: ProductCardViewModel;
  @Input() isGrid;
  @Output() reviewEvent: EventEmitter<string>;

  constructor() {
    this.reviewEvent = new EventEmitter();
  }

  ngOnInit() {
    this.InitStars(this.productCard.productRating);
  }
  InitStars(rateStar) {
    this.productCard.stars = [];
    for (let i = 0; i < 5; i++) {
      if (rateStar >= i) {
        this.productCard.stars[i] = 'img/icons/fullstar.png';
      } else if (rateStar > (i - 1)) {
        this.productCard.stars[i] = 'img/icons/halfstar.png';
      } else {
        this.productCard.stars[i] = 'img/icons/nonestar.png';
      }
    }
  }
  RedirectToProductDetails() {
    this.reviewEvent.emit(this.productCard.productId);
  }
}
