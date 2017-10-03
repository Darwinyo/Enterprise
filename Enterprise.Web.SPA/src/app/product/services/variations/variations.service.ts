import { serverUrl } from './../../../shared/consts/server-url.const';
import { ProductVariationControllerUrl } from './../../../shared/consts/api-url.const';
import { ProductVariationModel } from './../../models/product/product-variations/product-variation.model';
// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class VariationsService {
    urlVariationController = serverUrl + ProductVariationControllerUrl;
    constructor(private http: Http) { }
    getProductVariationByProductId(productId: string): Observable<ProductVariationModel[]> {
        return this.http.get(this.urlVariationController + '/' + productId).map(
            result => result.json()
        )
    }
}
