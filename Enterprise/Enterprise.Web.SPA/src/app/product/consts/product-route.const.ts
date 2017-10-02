import { RouterModule, Routes } from '@angular/router';
import { ProductDetailsComponent } from './../containers/product-details/product-details.component';
import { HomeComponent } from '../containers/home/home.component';

export const productRoutes: Routes = [
    { path: 'home', component: HomeComponent, pathMatch: 'full' },
    { path: 'product-details/:id', component: ProductDetailsComponent, pathMatch: 'full' }
]
