import { Component, OnInit } from '@angular/core';
declare let $: any;
@Component({
  selector: 'app-filter-product-tail',
  templateUrl: './filter-product-tail.component.html',
  styleUrls: ['./filter-product-tail.component.css']
})
export class FilterProductTailComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    $('#ionrange_1').ionRangeSlider({
      min: 0,
      max: 5000,
      type: 'double',
      prefix: '$',
      maxPostfix: '+',
      prettify: false,
      hasGrid: true
    });

  }

}
