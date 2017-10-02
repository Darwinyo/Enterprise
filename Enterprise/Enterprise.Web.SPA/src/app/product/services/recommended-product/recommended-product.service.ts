import { RecommendedProductCardsViewModel } from './../../viewmodels/recommended-product/recommended-product-cards.viewmodel';

import { serverUrl } from './../../../shared/consts/server-url.const';
import { RecommendedProductControllerUrl } from './../../../shared/consts/api-url.const';
// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class RecommendedProductService {
    urlRecommendedProductController = serverUrl + RecommendedProductControllerUrl;
    constructor(private http: Http) { }

    getRecommendedProductByPeriodeId(periodeId: string): Observable<RecommendedProductCardsViewModel> {
        return this.http.get(this.urlRecommendedProductController + '/' + periodeId).map(
            (result) => result.json()
        )
    }

}
