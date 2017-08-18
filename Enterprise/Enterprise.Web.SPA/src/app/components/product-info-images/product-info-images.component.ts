import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-info-images',
  templateUrl: './product-info-images.component.html',
  styleUrls: ['./product-info-images.component.css']
})
export class ProductInfoImagesComponent implements OnInit {
  imagesGalery: string[];
  imageSelected: string;
  constructor() {
    this.imageSelected = 'img/product/ryzen5.jpeg';
    this.imagesGalery = [
      'img/product/ryzen5.jpeg',
      'img/product/inteli7.jpeg',
      'img/product/inteli7.jpeg',
      'img/product/inteli7.jpeg'];
  }

  ngOnInit() {

  }
  itemSelected(image: string): boolean {
    if (this.imageSelected === image) {
      return true;
    } else {
      return false;
    }
  }

}
