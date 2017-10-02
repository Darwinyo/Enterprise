import { ProductReviewControllerUrl } from './../../../shared/consts/api-url.const';
import { Http, Headers } from '@angular/http';
import { serverUrl } from './../../../shared/consts/server-url.const';
import { Injectable } from '@angular/core';

@Injectable()
export class ProductReviewService {
    urlProductReviewController = serverUrl + ProductReviewControllerUrl;
    constructor(private http: Http) { }
    addReview(productId: string) {
        return this.http.get(this.urlProductReviewController + '/' + productId).map(
            () => null
        );
    }
}
