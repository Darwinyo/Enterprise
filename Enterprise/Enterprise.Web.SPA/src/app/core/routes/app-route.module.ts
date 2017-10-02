import { NgModule } from '@angular/core';
import { RouterModule, Router } from '@angular/router';

import * as appRoute from '../consts/app-route.const';

@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoute.appRoutes
    )
  ],
  exports: [RouterModule]
})
export class AppRouteModule { }
