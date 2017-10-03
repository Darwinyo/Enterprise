import { CartViewmodel } from './../../viewmodels/cart/cart.viewmodel';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  @Output() reviewEvent: EventEmitter<string>;
  cartList: CartViewmodel[];
  constructor() {
    this.reviewEvent = new EventEmitter();
    this.cartList = [];
  }

  ngOnInit() {
  }
  initCartList(cartItems: CartViewmodel[]) {
    this.cartList = cartItems;
  }
  goToProductDetail(productId: string) {
    this.reviewEvent.emit(productId);
  }
}
