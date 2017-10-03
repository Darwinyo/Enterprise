import { ProductImageModel } from './../../models/product/product-image/product-image.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-info-images',
  templateUrl: './product-info-images.component.html',
  styleUrls: ['./product-info-images.component.css']
})
export class ProductInfoImagesComponent implements OnInit {
  imagesGalery: ProductImageModel[];
  imageSelected: string;
  constructor() {
    this.imageSelected = '';
  }

  ngOnInit() {
  }
  populateImages(productImageModel: ProductImageModel[]) {
    this.imagesGalery = productImageModel;
    this.imageSelected = this.imagesGalery[0].productImageUrl;
  }
  selectImage(image: ProductImageModel) {
    this.imageSelected = image.productImageUrl;
  }
  itemSelected(image: ProductImageModel): boolean {
    if (this.imageSelected === image.productImageUrl) {
      return true;
    } else {
      return false;
    }
  }

}
