import { HotProductCardsViewModel } from './../../viewmodels/hot-product/hot-product-cards.viewmodel';
import { serverUrl } from './../../../shared/consts/server-url.const';
import { HotProductControllerUrl } from './../../../shared/consts/api-url.const';
// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class HotProductService {
    urlHotProductController = serverUrl + HotProductControllerUrl;
    constructor(private http: Http) { }
    getHotProductByPeriodeId(periodeId: string): Observable<HotProductCardsViewModel> {
        return this.http.get(this.urlHotProductController + '/' + periodeId).map(
            (result) => result.json()
        )
    };
}
