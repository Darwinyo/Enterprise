import { RecommendedProductService } from './../../services/recommended-product/recommended-product.service';
import { HotProductService } from './../../services/hot-product/hot-product.service';
import { PeriodeService } from './../../services/periode/periode.service';
import { ProductCategoryModel } from './../../models/product/product-category/product-category.model';
import { CategoryService } from './../../services/category/category.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  categories: ProductCategoryModel[];
  constructor(
    private categoryService: CategoryService,
    private periodeService: PeriodeService,
    private hotProductService: HotProductService,
    private recommendedProductService: RecommendedProductService) {
    this.categories = [];
  }

  ngOnInit() {
    this.fetchAllCategory();
    this.fetchCurrentPeriode();
  }
  fetchCurrentPeriode() {
    const date = new Date();
    console.log(date);
  }
  fetchAllCategory() {
    this.categoryService.GetAllCategories().subscribe(
      (result) => this.categories = result,
      (err) => console.log(err),
      () => console.log('CategoryLoaded')
    );
  }
}
