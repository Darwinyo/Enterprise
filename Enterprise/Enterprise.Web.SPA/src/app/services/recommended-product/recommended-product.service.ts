import { ProductModel } from './../../models/product/product/product.model';
// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class RecommendedProductService {
    urlRecommendedProductController = 'http://localhost:63853/api/recommendedproduct';
    constructor(private http: Http) { }

    GetRecommendedProductByPeriodeId(periodeId: string): Observable<ProductModel> {
        return this.http.get(this.urlRecommendedProductController + '/' + periodeId).map(
            (result) => result.json()
        )
    }

}
