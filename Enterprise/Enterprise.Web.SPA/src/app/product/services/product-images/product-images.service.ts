import { serverUrl } from './../../../shared/consts/server-url.const';
import { ProductImagesControllerUrl } from './../../../shared/consts/api-url.const';
import { ProductImageModel } from './../../models/product/product-image/product-image.model';
// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class ProductImagesService {
    urlProductImageController = serverUrl + ProductImagesControllerUrl;
    constructor(private http: Http) { }
    getProductImageListByProductId(productId: string): Observable<ProductImageModel[]> {
        return this.http.get(this.urlProductImageController + '/' + productId).map(
            result => result.json()
        )
    };
}
