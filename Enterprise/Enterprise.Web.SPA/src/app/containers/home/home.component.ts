import { ProductReviewService } from './../../services/product-review/product-review.service';
import { Router } from '@angular/router';
import { RecommendedProductCardsViewModel } from './../../viewmodels/recommended-product/recommended-product-cards.viewmodel';

import { HotProductCardsViewModel } from './../../viewmodels/hot-product/hot-product-cards.viewmodel';
import { ListProductCardComponent } from './../../components/list-product-card/list-product-card.component';
import { RecommendedProductService } from './../../services/recommended-product/recommended-product.service';
import { HotProductService } from './../../services/hot-product/hot-product.service';
import { PeriodeService } from './../../services/periode/periode.service';
import { ProductCategoryModel } from './../../models/product/product-category/product-category.model';
import { CategoryService } from './../../services/category/category.service';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  @ViewChild('hotList') hotListProductCardComponent: ListProductCardComponent;
  @ViewChild('categoryList') recommendListProductCardComponent: ListProductCardComponent;
  categories: ProductCategoryModel[];
  periodeId: string;
  hotProducts: HotProductCardsViewModel;
  recommendedProducts: RecommendedProductCardsViewModel;
  constructor(
    private router: Router,
    private productReviewService: ProductReviewService,
    private categoryService: CategoryService,
    private hotProductService: HotProductService,
    private recommendedProductService: RecommendedProductService) {
    this.categories = [];
    this.periodeId = '';
  }

  ngOnInit() {
    this.fetchAllCategory();
    this.fetchCurrentPeriode();
  }
  fetchCurrentPeriode() {
    const date = new Date();
    const dateStr = date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate();
    this.periodeId = dateStr;
    this.fetchHotProductByPeriode();
    this.fetchRecommendedProductByPeriode();
  };
  fetchHotProductByPeriode() {
    this.hotProductService.getHotProductByPeriodeId(this.periodeId).subscribe(
      (result) => this.hotProducts = result,
      (err) => console.log(err),
      () =>
        this.hotListProductCardComponent.InitProductCardModel(this.hotProducts.hotProductCards)
    )
  };
  fetchRecommendedProductByPeriode() {
    this.recommendedProductService.getRecommendedProductByPeriodeId(this.periodeId).subscribe(
      (result) => this.recommendedProducts = result,
      (err) => console.log(err),
      () =>
        this.recommendListProductCardComponent.InitProductCardModel(this.recommendedProducts.recommendedProductCards)
    )
  }
  fetchAllCategory() {
    this.categoryService.getAllCategories().subscribe(
      (result) => this.categories = result,
      (err) => console.log(err),
      () => console.log('CategoryLoaded')
    );
  }
  addReview(productId: string) {
    this.productReviewService.addReview(productId).subscribe(
      () => console.log('call addReview'),
      (err) => console.log(err),
      () => this.router.navigate(['product-details', productId])
    )
  }
}
