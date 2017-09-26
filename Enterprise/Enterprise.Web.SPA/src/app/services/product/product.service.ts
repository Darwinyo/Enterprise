import { serverUrl } from './../../consts/server-url.const';
import { ProductControllerUrl } from './../../consts/api-url.const';
import { ProductModel } from './../../models/product/product/product.model';

// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class ProductService {
    urlProductController = serverUrl + ProductControllerUrl;
    constructor(private http: Http) { }
    createProduct(product: ProductModel) {
        const headers: Headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post(this.urlProductController, product, { headers: headers });
    }
    getAllProduct(): Observable<ProductModel[]> {
        const headers: Headers = new Headers();
        return this.http.get(this.urlProductController).map(result => result.json());
    }
    getProductById(productId: string) {
        return this.http.get(this.urlProductController + '/' + productId).map(
            (result) => result.json()
        )
    }
}
