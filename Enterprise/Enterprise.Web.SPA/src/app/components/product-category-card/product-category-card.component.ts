import { ProductCategoryModel } from './../../models/product/product-category/product-category.model';
import { Component, OnInit, Input } from '@angular/core';
@Component({
  selector: 'app-product-category-card',
  templateUrl: './product-category-card.component.html',
  styleUrls: ['./product-category-card.component.css']
})
export class ProductCategoryCardComponent implements OnInit {
  @Input() productCategory: ProductCategoryModel;
  constructor() { }

  ngOnInit() {

  }

}
