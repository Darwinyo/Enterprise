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
  constructor(private categoryService: CategoryService) {
    this.categories = [];
  }

  ngOnInit() {
    this.fetchAllCategory();
  }
  fetchAllCategory() {
    this.categoryService.GetAllCategories().subscribe(
      (result) => this.categories = result,
      (err) => console.log(err),
      () => console.log('CategoryLoaded')
    );
  }
}
