import { Router } from '@angular/router';
import { ProductReviewService } from './../../services/product-review/product-review.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  logged: boolean;
  toggleNotif: boolean;
  toggleCart: boolean;
  toggleUser: boolean;
  toggleLogin: boolean;
  constructor(
    private router: Router,
    private productReviewService: ProductReviewService
  ) {
    this.logged = false;
    this.toggleNotif = false;
    this.toggleCart = false;
    this.toggleUser = false;
    this.toggleLogin = false;
  }

  ngOnInit() {
  }
  toggleDropNotif() {
    this.toggleNotif = !this.toggleNotif;
  }
  toggleDropCart() {
    this.toggleCart = !this.toggleCart;
  }
  toggleDropUser() {
    this.toggleUser = !this.toggleUser;
  }
  toggleDropLogin() {
    this.toggleLogin = !this.toggleLogin;
  }
  addReview(productId: string) {
    this.productReviewService.addReview(productId).subscribe(
      () => console.log('call addReview'),
      (err) => console.log(err),
      () => this.router.navigate(['product-details', productId])
    )
  }
}
