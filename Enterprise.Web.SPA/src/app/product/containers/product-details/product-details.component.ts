import { ProductSpecsService } from './../../services/product-specs/product-specs.service';
import { ProductImagesService } from './../../services/product-images/product-images.service';
import { VariationsService } from './../../services/variations/variations.service';
import { CityService } from './../../services/city/city.service';
import { ProductService } from './../../services/product/product.service';

import { ProductInfoDescriptionComponent } from './../../components/product-info-description/product-info-description.component';
import { ProductInfoImagesComponent } from './../../components/product-info-images/product-info-images.component';
import { ProductInfoDetailsComponent } from './../../components/product-info-details/product-info-details.component';

import { ProductModel } from './../../models/product/product/product.model';

import { ProductInfoDetailsViewModel } from './../../viewmodels/product-info-details/product-info-details.viewmodel';

import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { Component, OnInit, ViewChild } from '@angular/core';
import 'rxjs/add/operator/switchMap';
@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  @ViewChild('productDetails') productDetails: ProductInfoDetailsComponent;
  @ViewChild('productImage') productImage: ProductInfoImagesComponent;
  @ViewChild('productDescription') productDescription: ProductInfoDescriptionComponent;
  productModel: ProductModel;
  productItem: ProductInfoDetailsViewModel;
  productLocation: string;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private productService: ProductService,
    private cityService: CityService,
    private variationService: VariationsService,
    private imageService: ProductImagesService,
    private specsService: ProductSpecsService) {
    this.productModel = <ProductModel>{};
  }

  ngOnInit() {
    this.route.paramMap.switchMap(
      (params: ParamMap) => this.productService.getProductById(params.get('id')))
      .subscribe(
      (product: ProductInfoDetailsViewModel) => this.InitData(product)
      )
  }
  InitData(model: ProductInfoDetailsViewModel) {
    let locationItem = '';
    this.cityService.getCityById(model.productLocation).subscribe(
      x => locationItem = x,
      err => console.log(err),
      () => this.productLocation = locationItem);
    this.productItem = model;
    this.productItem.stars = [];
    console.log(this.productItem);
    this.productDetails.InitData(this.productItem);
    this.productImage.populateImages(this.productItem.productImages);
    this.productDescription.detailsProduct = this.productItem.productSpecs;
    this.productDescription.descriptions = model.productDescription;
  }
}
