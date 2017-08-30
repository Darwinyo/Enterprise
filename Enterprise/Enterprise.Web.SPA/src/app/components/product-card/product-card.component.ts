import { ProductCardModel } from './../../models/product-card/product-card.model';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent implements OnInit {
  @Input() productCard: ProductCardModel;
  @Input() isGrid;
  imageUrl: string;
  price: number;
  ratestar: number;
  productname: string;
  favorites: number;
  reviews: number;
  stars: string[];

  constructor() {
    this.stars = [];
  }

  ngOnInit() {
    this.MapData(this.productCard);
    this.InitStars(this.ratestar);
  }
  MapData(productCardModel: ProductCardModel) {
    this.ratestar = productCardModel.ratestar;
    this.productname = productCardModel.productname;
    this.favorites = productCardModel.favorites;
    this.reviews = productCardModel.reviews;
    this.price = productCardModel.price;
    this.imageUrl=productCardModel.imageUrl;
  }
  InitStars(rateStar) {
    for (let i = 1; i < 6; i++) {
      if (rateStar >= i) {
        this.stars[i] = 'img/icons/fullstar.png';
      } else if (rateStar > (i - 1)) {
        this.stars[i] = 'img/icons/halfstar.png';
      } else {
        this.stars[i] = 'img/icons/nonestar.png';
      }
    }
  }
}
