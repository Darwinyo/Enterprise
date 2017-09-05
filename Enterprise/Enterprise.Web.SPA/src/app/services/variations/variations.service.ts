import { ProductVariationModel } from './../../models/product/product-variations/product-variation.model';
// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class VariationsService {
    urlVariationController = 'http://localhost:63853/api/productvariation';
    constructor(private http: Http) { }
    getProductVariationByProductId(productId: string): Observable<ProductVariationModel[]> {
        return this.http.get(this.urlVariationController + '/' + productId).map(
            result => result.json()
        )
    }
}
