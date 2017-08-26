import { ProductEditorComponent } from './containers/product-editor/product-editor.component';
import { ProductService } from './services/product/product.service';
import { ProductInfoDescriptionComponent } from './components/product-info-description/product-info-description.component';

import { ProductInfoImagesComponent } from './components/product-info-images/product-info-images.component';
import { ProductInfoDetailsComponent } from './components/product-info-details/product-info-details.component';
import { ProductDetailsComponent } from './containers/product-details/product-details.component';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';

// Modules


// Components
import { AppComponent } from './app.component';
import { FooterComponent } from './components/footer/footer.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ProductCardComponent } from './components/product-card/product-card.component';
import { ProductCategoryCardComponent } from './components/product-category-card/product-category-card.component';
import { ListProductCategoryComponent } from './components/list-product-category/list-product-category.component';
import { ListProductCardComponent } from './components/list-product-card/list-product-card.component';
import { FilterCategoryComponent } from './components/filter-category/filter-category.component';
import { FilterProductComponent } from './components/filter-product/filter-product.component';
import { HomeComponent } from './containers/home/home.component';
import { GridProductComponent } from './components/grid-product/grid-product.component';
import { SortProductComponent } from './components/sort-product/sort-product.component';
import { FilterProductTailComponent } from './components/filter-product-tail/filter-product-tail.component';

// Containers
import { ErrorNotFoundComponent } from './containers/error-not-found/error-not-found.component';

// Routes
import { AppRouteModule } from './routes/app-route/app-route.module';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    ProductCardComponent,
    ProductCategoryCardComponent,
    ListProductCategoryComponent,
    ListProductCardComponent,
    FilterCategoryComponent,
    FilterProductComponent,
    FilterProductTailComponent,
    SortProductComponent,
    GridProductComponent,
    HomeComponent,
    ProductDetailsComponent,
    ProductInfoDetailsComponent,
    ProductInfoImagesComponent,
    ProductInfoDescriptionComponent,
    ProductEditorComponent,

    ErrorNotFoundComponent
  ],
  imports: [
    HttpModule,
    BrowserModule,
    AppRouteModule
  ],
  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
