import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sort-product',
  templateUrl: './sort-product.component.html',
  styleUrls: ['./sort-product.component.css']
})
export class SortProductComponent implements OnInit {
  hovered = false;
  constructor() { }

  ngOnInit() {
  }
  hover() {
    this.hovered = !this.hovered;
  }
}
