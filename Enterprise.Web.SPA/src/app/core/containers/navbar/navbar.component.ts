import { Observable } from 'rxjs/Rx';
import { Store } from '@ngrx/store';
import { UserLoginResponseModel } from './../../../auth/models/responses/user-login-response/user-login-response.model';
import { UserService } from './../../../auth/services/user/user.service';
import { UserLoginViewModel } from './../../../auth/viewmodels/user-login/user-login.viewmodel';
import { Router } from '@angular/router';
import { ProductReviewService } from './../../../product/services/product-review/product-review.service';
import { Component, OnInit } from '@angular/core';
import * as fromCore from './../../reducers/core-state.reducer';
import * as NavbarActions from './../../actions/navbar.actions';
import * as AuthActions from './../../../auth/actions/auth.actions';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  logged$: Observable<boolean>;
  userLoginResponseModel: UserLoginResponseModel;
  toggleNotif$: Observable<boolean>;
  toggleCart$: Observable<boolean>;
  toggleUser$: Observable<boolean>;
  toggleLogin$: Observable<boolean>;
  constructor(
    private router: Router,
    private productReviewService: ProductReviewService,
    private userService: UserService,
    private coreStore: Store<fromCore.State>
  ) {
    this.logged$ = this.coreStore.select(fromCore.getLogged);
    this.toggleCart$ = this.coreStore.select(fromCore.getCartMenu);
    this.toggleLogin$ = this.coreStore.select(fromCore.getLoginMenu);
    this.toggleNotif$ = this.coreStore.select(fromCore.getNotifMenu);
    this.toggleUser$ = this.coreStore.select(fromCore.getUserMenu);
  }

  ngOnInit() {
  }
  toggleDropNotif() {
    this.coreStore.dispatch(new NavbarActions.ToggleNotif());
  }
  toggleDropCart() {
    this.coreStore.dispatch(new NavbarActions.ToggleCart());
  }
  toggleDropUser() {
    this.coreStore.dispatch(new NavbarActions.ToggleUser());
  }
  toggleDropLogin() {
    this.coreStore.dispatch(new NavbarActions.ToggleLogin());
  }
  addReview(productId: string) {
    this.productReviewService.addReview(productId).subscribe(
      () => console.log('call addReview'),
      (err) => console.log(err),
      () => this.router.navigate(['product-details', productId])
    )
  }
  loginUser(userLoginViewModel: UserLoginViewModel) {
    this.coreStore.dispatch(new AuthActions.Login(userLoginViewModel));
  }
}