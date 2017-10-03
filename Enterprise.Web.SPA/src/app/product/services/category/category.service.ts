import { CategoryControllerUrl } from './../../../shared/consts/api-url.const';
import { serverUrl } from './../../../shared/consts/server-url.const';
import { ProductCategoryModel } from './../../models/product/product-category/product-category.model';
// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class CategoryService {
    urlCategoryController = serverUrl + CategoryControllerUrl;
    constructor(private http: Http) { }
    getAllCategories(): Observable<ProductCategoryModel[]> {
        return this.http.get(this.urlCategoryController).map(
            (result) => result.json()
        );
    }
}
