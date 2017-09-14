import { Component, OnInit, Input } from '@angular/core';
import { ProductInfoDetailsViewModel } from './../../viewmodels/product-info-details/product-info-details.viewmodel';

@Component({
  selector: 'app-product-info-details',
  templateUrl: './product-info-details.component.html',
  styleUrls: ['./product-info-details.component.css']
})
export class ProductInfoDetailsComponent implements OnInit {
  productInfoDetailViewModel: ProductInfoDetailsViewModel;
  constructor() {
    this.productInfoDetailViewModel = <ProductInfoDetailsViewModel>{
      productTitle: '',
      productPrice: 0,
      stars: [],
      ratestar: 0,
      reviews: 0,
      location: '',
      deliver: 'Beijing',
      deliveryDropped: false,
      deliverPrice: 0,
      deliveryPriceDropped: false,
      variations: [],
      quantity: 1,
      stock: 0,
      locations: [],
      deliveryOptions: [],
    }
  }

  ngOnInit() {
    this.productInfoDetailViewModel.locations = [
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
    this.productInfoDetailViewModel.deliveryOptions = ['JNE', 'Cargo', 'Airplane'];
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
    this.productInfoDetailViewModel.location = productInfoDetailModel.location;
    this.productInfoDetailViewModel.productPrice = productInfoDetailModel.productPrice;
    this.productInfoDetailViewModel.productTitle = productInfoDetailModel.productTitle;
    this.productInfoDetailViewModel.ratestar = productInfoDetailModel.ratestar;
    this.productInfoDetailViewModel.reviews = productInfoDetailModel.reviews;
    this.productInfoDetailViewModel.stock = productInfoDetailModel.stock;
    this.productInfoDetailViewModel.variations = productInfoDetailModel.variations;
    this.InitStars(this.productInfoDetailViewModel.ratestar);
  }
  deliverClick() {
    this.productInfoDetailViewModel.deliveryDropped = !this.productInfoDetailViewModel.deliveryDropped;
  }
  deliverPriceClick() {
    this.productInfoDetailViewModel.deliveryPriceDropped = !this.productInfoDetailViewModel.deliveryPriceDropped;

  }
}
