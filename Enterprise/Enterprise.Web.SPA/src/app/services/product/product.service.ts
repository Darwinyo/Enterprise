import { ProductModel } from './../../models/product/product/product.model';
import { ImageModel } from './../../models/image-upload/image.model';

// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class ProductService {
    urlProductController = 'http://localhost:63853/api/product';
    constructor(private http: Http) { }
    CreateProduct(product: ProductModel) {
        const headers: Headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post(this.urlProductController, product, { headers: headers });
    }
    GetAllProduct(): Observable<ProductModel[]> {
        const headers: Headers = new Headers();
        return this.http.get(this.urlProductController).map(result => result.json());
    }
    GetProductById(productId: string) {
        return this.http.get(this.urlProductController + '/' + productId).map(
            (result) => result.json()
        )
    }
}
