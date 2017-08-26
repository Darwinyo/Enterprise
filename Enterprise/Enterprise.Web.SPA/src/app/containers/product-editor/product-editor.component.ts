import { ProductModel } from './../../models/product/product/product.model';
import { Component, OnInit } from '@angular/core';
declare let $: any;
@Component({
  selector: 'app-product-editor',
  templateUrl: './product-editor.component.html',
  styleUrls: ['./product-editor.component.css']
})
export class ProductEditorComponent implements OnInit {
  productModel: ProductModel;
  title: string;
  constructor() {
    this.productModel = <ProductModel>{};
    this.title = '';
  }

  ngOnInit() {
    $('.summernote').summernote();

    $('.input-group.date').datepicker({
      todayBtn: 'linked',
      keyboardNavigation: false,
      forceParse: false,
      calendarWeeks: true,
      autoclose: true
    });
  }

}
