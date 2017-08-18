import { Component, OnInit } from '@angular/core';

const pageLength = 1200;
const itemLength = 150;
@Component({
  selector: 'app-list-product-category',
  templateUrl: './list-product-category.component.html',
  styleUrls: ['./list-product-category.component.css']
})

export class ListProductCategoryComponent implements OnInit {
  items: string[];
  marginleft: number;
  constructor() {
    this.items = [];
    this.marginleft = 0;
  }

  ngOnInit() {
    this.fetchItems();
  }
  fetchItems() {
    for (let i = 0; i < 20; i++) {
      this.items[i] = 'Category ' + i;
    }
  }
  prevbtnclicked() {
    if (0 < (this.marginleft + pageLength)) {
      this.marginleft = 0;
    } else {
      this.marginleft += pageLength;
    }
  }
  nextbtnclicked() {
    if (this.marginleft - pageLength < ((this.items.length * -itemLength) + pageLength)) {
      this.marginleft = (this.items.length * -itemLength) + pageLength;
    } else {
      this.marginleft -= pageLength;
    }
  }
}
