import { FilterCategoryModel } from './../../models/filter-category/filter-category.model';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-filter-category',
  templateUrl: './filter-category.component.html',
  styleUrls: ['./filter-category.component.css']
})
export class FilterCategoryComponent implements OnInit {
  @Input() categories: FilterCategoryModel[];
  constructor() {
    this.categories = [];
  }

  ngOnInit() {
    this.fetchCategory();
  }
  fetchCategory() {
    for (let i = 0; i < 10; i++) {
      this.categories[i] = <FilterCategoryModel>{ category: 'Category' + i, url: '/Category/' + i };
    }
  }
}
