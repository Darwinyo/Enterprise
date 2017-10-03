import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// Components
import { FilterCategoryComponent } from './components/filter-category/filter-category.component';
import { SortProductComponent } from './components/sort-product/sort-product.component';
import { GridProductComponent } from './components/grid-product/grid-product.component';
import { ProductInfoImagesComponent } from './components/product-info-images/product-info-images.component';
import { ProductInfoDetailsComponent } from './components/product-info-details/product-info-details.component';
import { ProductInfoDescriptionComponent } from './components/product-info-description/product-info-description.component';
import { ProductCategoryCardComponent } from './components/product-category-card/product-category-card.component';
import { ProductCardComponent } from './components/product-card/product-card.component';
import { ListProductCategoryComponent } from './components/list-product-category/list-product-category.component';
import { ListProductCardComponent } from './components/list-product-card/list-product-card.component';
import { FilterProductTailComponent } from './components/filter-product-tail/filter-product-tail.component';
import { FilterProductComponent } from './components/filter-product/filter-product.component';

// Containers
import { ProductDetailsComponent } from './containers/product-details/product-details.component';
import { HomeComponent } from './containers/home/home.component';

// Services
import { ProductReviewService } from './services/product-review/product-review.service';
import { ProductSpecsService } from './services/product-specs/product-specs.service';
import { VariationsService } from './services/variations/variations.service';
import { RecommendedProductService } from './services/recommended-product/recommended-product.service';
import { HotProductService } from './services/hot-product/hot-product.service';
import { CategoryService } from './services/category/category.service';
import { CityService } from './services/city/city.service';
import { ProductService } from './services/product/product.service';
import { ProductImagesService } from './services/product-images/product-images.service';
import { PeriodeService } from './services/periode/periode.service';

// Routes
import { ProductRouteModule } from './routes/product-route.module';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ProductRouteModule
  ],
  declarations: [
    FilterCategoryComponent,
    FilterProductComponent,
    FilterProductTailComponent,
    GridProductComponent,
    ListProductCardComponent,
    ListProductCategoryComponent,
    ProductCardComponent,
    ProductCategoryCardComponent,
    ProductInfoDescriptionComponent,
    ProductInfoDetailsComponent,
    ProductInfoImagesComponent,
    SortProductComponent,
    ProductDetailsComponent,
    HomeComponent
  ],
  exports: [
    FilterCategoryComponent,
    FilterProductComponent,
    FilterProductTailComponent,
    GridProductComponent,
    ListProductCardComponent,
    ListProductCategoryComponent,
    SortProductComponent,
    ProductDetailsComponent,
    HomeComponent
  ],
  providers: [
    ProductService,
    CityService,
    CategoryService,
    HotProductService,
    RecommendedProductService,
    VariationsService,
    ProductImagesService,
    ProductSpecsService,
    ProductReviewService,
    PeriodeService
  ],
})
export class ProductModule { }
