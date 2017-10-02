import { ProductCategoryModel } from './../../models/product/product-category/product-category.model';
import { Component, OnInit, Input } from '@angular/core';

const pageLength = 1200;
const itemLength = 150;
@Component({
  selector: 'app-list-product-category',
  templateUrl: './list-product-category.component.html',
  styleUrls: ['./list-product-category.component.css']
})

export class ListProductCategoryComponent implements OnInit {
  @Input() categoryitems: ProductCategoryModel[];
  marginleft: number;
  constructor() {
    this.marginleft = 0;
  }
  ngOnInit() {
  }
  prevbtnclicked() {
    if (0 < (this.marginleft + pageLength)) {
      this.marginleft = 0;
    } else {
      this.marginleft += pageLength;
    }
  }
  nextbtnclicked() {
    if (this.marginleft - pageLength < ((this.categoryitems.length * -itemLength) + pageLength)) {
      this.marginleft = (this.categoryitems.length * -itemLength) + pageLength;
    } else {
      this.marginleft -= pageLength;
    }
  }
}
