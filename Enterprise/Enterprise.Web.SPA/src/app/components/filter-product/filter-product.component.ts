import { FilterModel } from './../../models/filter-product/filter.model';
import { FilterProductModel } from './../../models/filter-product/filter-product.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-filter-product',
  templateUrl: './filter-product.component.html',
  styleUrls: ['./filter-product.component.css']
})
export class FilterProductComponent implements OnInit {
  filters: FilterProductModel[];
  constructor() {
    this.filters = [];
  }

  ngOnInit() {
    this.fetchFilters();
    console.log(this.filters);
  }
  fetchFilters() {
    for (let i = 0; i < 5; i++) {
      const filterProductModel: FilterProductModel = <FilterProductModel>{};
      const filterarray: FilterModel[] = [];
      for (let x = 0; x < 10; x++) {
        filterarray.push(<FilterModel>{
          checked: Math.round(Math.random()) === 1,
          filter: 'filter ' + i + ' ' + x
        });
      }
      filterProductModel.category = 'Category ' + i;
      filterProductModel.filterarrays = filterarray;
      this.filters[i] = filterProductModel;
    }
  }
}
