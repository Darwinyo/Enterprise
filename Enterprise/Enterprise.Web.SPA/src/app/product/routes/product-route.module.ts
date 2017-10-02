import { NgModule } from '@angular/core';
import { RouterModule, Router } from '@angular/router';

import * as productRoute from '../consts/product-route.const';

@NgModule({
  imports: [
    RouterModule.forChild(
      productRoute.productRoutes
    )
  ],
  exports: [RouterModule]
})
export class ProductRouteModule { }
