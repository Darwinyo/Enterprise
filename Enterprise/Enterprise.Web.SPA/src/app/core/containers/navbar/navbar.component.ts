import { UserLoginResponseModel } from './../../../auth/models/responses/user-login-response/user-login-response.model';
import { UserService } from './../../../auth/services/user/user.service';
import { UserLoginViewModel } from './../../../auth/viewmodels/user-login/user-login.viewmodel';
import { Router } from '@angular/router';
import { ProductReviewService } from './../../../product/services/product-review/product-review.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  logged: boolean;
  userLoginResponseModel: UserLoginResponseModel;
  toggleNotif: boolean;
  toggleCart: boolean;
  toggleUser: boolean;
  toggleLogin: boolean;
  constructor(
    private router: Router,
    private productReviewService: ProductReviewService,
    private userService: UserService
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
  loginUser(userLoginViewModel: UserLoginViewModel) {
    this.userService.userLogin(userLoginViewModel).subscribe(
      (res) => this.userLoginResponseModel = res,
      (err) => alert(err),
      () => {
        this.logged = this.userLoginResponseModel.isLogged;
        if (this.logged) {
          alert('You Are Logged');
        } else {
          alert('Wrong Password or UserLogin');
        }
        if (userLoginViewModel.rememberme && this.logged) {
          localStorage.setItem('userKey', this.userLoginResponseModel.userKey);
        }
      }
    )
  }
}
