import { Component, OnInit, Input } from '@angular/core';
import { ProductInfoDetailsModel } from './../../models/product-info-details/product-info-details.model';

@Component({
  selector: 'app-product-info-details',
  templateUrl: './product-info-details.component.html',
  styleUrls: ['./product-info-details.component.css']
})
export class ProductInfoDetailsComponent implements OnInit {
  @Input() productDetailsModel: ProductInfoDetailsModel;
  productTitle: string;
  productPrice: number;
  stars: string[];
  ratestar: number;
  reviews: number;
  location: string;
  deliver: string;
  deliveryDropped: boolean;
  deliverPrice: number;
  deliveryPriceDropped: boolean;
  variations: string[];
  quantity: number;
  stock: number;
  locations: string[];
  deliveryOptions: string[];
  constructor() {
    this.productDetailsModel = <ProductInfoDetailsModel>{};
    this.productTitle = '';
    this.productPrice = 0;
    this.stars = [];
    this.ratestar = 0;
    this.reviews = 0;
    this.location = '';
    this.deliver = 'Beijing';
    this.deliveryDropped = false;
    this.deliverPrice = 0;
    this.deliveryPriceDropped = false;
    this.variations = [];
    this.quantity = 1;
    this.stock = 0;
    this.locations = [];
    this.deliveryOptions = [];
  }

  ngOnInit() {
    this.locations = ['Beijing', 'Shanghai', 'Xiamen', 'Suzhou', 'Nanjing', 'Hongkong', 'Taiwan', 'HeiLongJiang', 'GuangZhou'];
    this.deliveryOptions = ['JNE', 'Cargo', 'Airplane'];
    this.fetchData(this.productDetailsModel);
    this.InitStars(this.ratestar);
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
  fetchData(productInfoDetailModel: ProductInfoDetailsModel) {
    this.productTitle = productInfoDetailModel.productTitle;
    this.productPrice = productInfoDetailModel.productPrice;
    this.ratestar = productInfoDetailModel.ratestar;
    this.reviews = productInfoDetailModel.reviews;
    this.location = productInfoDetailModel.location;
    this.variations = productInfoDetailModel.variations;
    this.stock = productInfoDetailModel.stock;
  }
  deliverClick() {
    this.deliveryDropped = !this.deliveryDropped;
  }
  deliverPriceClick() {
    this.deliveryPriceDropped = !this.deliveryPriceDropped;

  }
}
