import { ProductSpecsService } from './../../services/product-specs/product-specs.service';
import { ProductInfoDescriptionComponent } from './../../components/product-info-description/product-info-description.component';
import { ProductInfoImagesComponent } from './../../components/product-info-images/product-info-images.component';
import { ProductImagesService } from './../../services/product-images/product-images.service';
import { ProductInfoDetailsComponent } from './../../components/product-info-details/product-info-details.component';
import { VariationsService } from './../../services/variations/variations.service';
import { CityService } from './../../services/city/city.service';
import { ProductModel } from './../../models/product/product/product.model';
import { ProductService } from './../../services/product/product.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { ProductInfoDetailsViewModel } from './../../viewmodels/product-info-details/product-info-details.viewmodel';
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
  ProductItem: ProductInfoDetailsViewModel;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private productService: ProductService,
    private cityService: CityService,
    private variationService: VariationsService,
    private imageService: ProductImagesService,
    private specsService: ProductSpecsService) {
    this.ProductItem = <ProductInfoDetailsViewModel>{};
    this.productModel = <ProductModel>{};
  }

  ngOnInit() {
    this.route.paramMap.switchMap(
      (params: ParamMap) => this.productService.getProductById(params.get('id')))
      .subscribe(
      (product: ProductModel) => {
        this.convertToProductItem(product);
        this.convertToImagesArray(product.productId);
        this.convertToProductDescription(product);
      }
      )
  }
  convertToProductItem(model: ProductModel) {
    const variationStrArr = [];
    let locationItem = '';
    this.cityService.getCityById(model.productLocation).subscribe(
      x => locationItem = x,
      err => console.log(err),
      () => this.ProductItem.location = locationItem);
    this.ProductItem.productPrice = model.productPrice;
    this.ProductItem.productTitle = model.productName;
    this.ProductItem.ratestar = model.productRating;
    this.ProductItem.reviews = model.productReview;
    this.ProductItem.stock = model.productStock;
    this.variationService.getProductVariationByProductId(model.productId).subscribe(
      x => x.forEach(y => variationStrArr.push(y.productVariation)),
      (err) => console.log(err),
      () => {
        this.ProductItem.variations = variationStrArr;
        this.productDetails.InitData(this.ProductItem);
      }
    )
  }
  convertToImagesArray(productId: string) {
    this.imageService.getProductImageListByProductId(productId).subscribe(
      (result) => this.productModel.TblProductImage = result,
      (err) => console.log(err),
      () => this.productImage.populateImages(this.productModel.TblProductImage)
    )
  }
  convertToProductDescription(model: ProductModel) {
    this.specsService.getAllProductSpecsByProductId(model.productId).subscribe(
      (result) => this.productModel.TblProductSpecs = result,
      (err) => console.log(err),
      () => {
        this.productDescription.detailsProduct = this.productModel.TblProductSpecs;
        this.productDescription.descriptions = model.productDescription;
      }
    )
  }
}
