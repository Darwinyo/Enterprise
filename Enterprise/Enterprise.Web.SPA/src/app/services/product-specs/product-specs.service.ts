import { ProductSpecsModel } from './../../models/product/product-specs/product-specs.model';
// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class ProductSpecsService {
urlProductSpecsController = 'http://localhost:63853/api/productspecs';
constructor(private http: Http) { }
getAllProductSpecsByProductId(productId: string): Observable<ProductSpecsModel[]> {
    return this.http.get(this.urlProductSpecsController + '/' + productId).map(
        result => result.json()
    )
}
}
