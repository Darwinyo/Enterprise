import { ProductSpecsModel } from './../../models/product/product-specs/product-specs.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-info-description',
  templateUrl: './product-info-description.component.html',
  styleUrls: ['./product-info-description.component.css']
})
export class ProductInfoDescriptionComponent implements OnInit {
  descriptions: string;
  detailsProduct: ProductSpecsModel[];
  constructor() {
    this.descriptions = '';
    this.detailsProduct = [];
  }

  ngOnInit() {
  }
}
