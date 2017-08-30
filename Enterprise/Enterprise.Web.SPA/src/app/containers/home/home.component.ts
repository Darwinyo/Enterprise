import { ListProductCardComponent } from './../../components/list-product-card/list-product-card.component';
import { ProductModel } from './../../models/product/product/product.model';
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
  hotProducts: ProductModel[];
  recommendedProducts: ProductModel[];
  constructor(
    private categoryService: CategoryService,
    private periodeService: PeriodeService,
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
    this.periodeService.GetCurrentPeriodeId(dateStr).subscribe(
      (result) => this.periodeId = result,
      (err) => console.log(err),
      () => {
        this.fetchHotProductByPeriode();
        this.fetchRecommendedProductByPeriode();
        console.log('called');
      }
    )
  };
  fetchHotProductByPeriode() {
    this.hotProductService.GetHotProductByPeriodeId(this.periodeId).subscribe(
      (result) => this.hotProducts = result,
      (err) => console.log(err),
      () => this.hotListProductCardComponent.ConvertToProductCardModel(this.hotProducts)
    )
  };
  fetchRecommendedProductByPeriode() {
    this.recommendedProductService.GetRecommendedProductByPeriodeId(this.periodeId).subscribe(
      (result) => this.recommendedProducts = result,
      (err) => console.log(err),
      () => this.recommendListProductCardComponent.ConvertToProductCardModel(this.recommendedProducts)
    )
  }
  fetchAllCategory() {
    this.categoryService.GetAllCategories().subscribe(
      (result) => this.categories = result,
      (err) => console.log(err),
      () => console.log('CategoryLoaded')
    );
  }
}
