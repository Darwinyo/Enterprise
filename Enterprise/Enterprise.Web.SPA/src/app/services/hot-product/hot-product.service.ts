// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import { ProductModel } from '../../models/product/product/product.model';

@Injectable()
export class HotProductService {
    urlHotProductController = 'http://localhost:63853/api/hotproduct';
    constructor(private http: Http) { }
    GetHotProductByPeriodeId(periodeId: string): Observable<ProductModel> {
        return this.http.get(this.urlHotProductController + '/' + periodeId).map(
            (result) => result.json()
        )
    };
}
