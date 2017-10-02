import { NgModule } from '@angular/core';
import { RouterModule, Router } from '@angular/router';

import * as authRoute from '../consts/auth-route.const';

@NgModule({
  imports: [
    RouterModule.forChild(
      authRoute.authRoutes
    )
  ],
  exports: [RouterModule]
})
export class AuthRouteModule { }
