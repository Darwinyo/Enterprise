import { Component, OnInit, Input } from '@angular/core';
import { ProductInfoDetailsViewModel } from './../../viewmodels/product-info-details/product-info-details.viewmodel';

@Component({
  selector: 'app-product-info-details',
  templateUrl: './product-info-details.component.html',
  styleUrls: ['./product-info-details.component.css']
})
export class ProductInfoDetailsComponent implements OnInit {
  productInfoDetailViewModel: ProductInfoDetailsViewModel;
  deliverPrice: number;
  deliveryDropped: boolean;
  deliveryPriceDropped: boolean;
  deliver: string;
  quantity: number;
  locations: string[];
  deliveryOptions: string[];
  constructor() {
    this.productInfoDetailViewModel = <ProductInfoDetailsViewModel>{};
    this.deliver = 'Beijing';
    this.deliveryDropped = false;
    this.deliverPrice = 0;
    this.deliveryPriceDropped = false;
    this.quantity = 1;
    this.locations = [];
    this.deliveryOptions = [];
  }

  ngOnInit() {
    this.locations = [
      'Beijing',
      'Shanghai',
      'Xiamen',
      'Suzhou',
      'Nanjing',
      'Hongkong',
      'Taiwan',
      'HeiLongJiang',
      'GuangZhou'
    ];
    this.deliveryOptions = ['JNE', 'Cargo', 'Airplane'];
  }
  InitStars(rateStar) {
    for (let i = 1; i < 6; i++) {
      if (rateStar >= i) {
        this.productInfoDetailViewModel.stars[i] = 'img/icons/fullstar.png';
      } else if (rateStar > (i - 1)) {
        this.productInfoDetailViewModel.stars[i] = 'img/icons/halfstar.png';
      } else {
        this.productInfoDetailViewModel.stars[i] = 'img/icons/nonestar.png';
      }
    }
  }
  InitData(productInfoDetailModel: ProductInfoDetailsViewModel) {
    this.productInfoDetailViewModel = productInfoDetailModel;
    this.InitStars(this.productInfoDetailViewModel.productRating);
  }
  deliverClick() {
    this.deliveryDropped = !this.deliveryDropped;
  }
  deliverPriceClick() {
    this.deliveryPriceDropped = !this.deliveryPriceDropped;

  }
}
