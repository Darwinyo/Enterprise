import { NgModule } from '@angular/core';
import { RouterModule, Router } from '@angular/router';

import * as adminRoute from './../consts/admin-route.const'

@NgModule({
  imports: [
    RouterModule.forChild(
      adminRoute.adminRoutes
    )
  ],
  exports: [RouterModule]
})
export class AdminRouteModule { }
