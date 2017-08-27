import { ProductCategoryModel } from './../../models/product/product-category/product-category.model';
// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class CategoryService {
    urlCategoryController = 'http://localhost:63853/api/categoryproduct';
    constructor(private http: Http) { }
    GetAllCategories(): Observable<ProductCategoryModel[]> {
        return this.http.get(this.urlCategoryController).map(
            (result) => result.json()
        );
    }
}
