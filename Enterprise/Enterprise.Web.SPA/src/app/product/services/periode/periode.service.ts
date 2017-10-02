import { serverUrl } from './../../../shared/consts/server-url.const';
import { PeriodeControllerUrl } from './../../../shared/consts/api-url.const';
import { PeriodeModel } from './../../models/periode/periode.model';
// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class PeriodeService {
    urlPeriodeController = serverUrl + PeriodeControllerUrl;
    constructor(private http: Http) { }
    createNewPeriode(periodeModel: PeriodeModel) {
        const headers: Headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post(this.urlPeriodeController, periodeModel, { headers: headers }).map(
            (result) => result.json()
        )
    };
    getCurrentPeriodeId(dateTime: string): Observable<string> {
        return this.http.get(this.urlPeriodeController + '/' + dateTime).map(
            (result) => result.text()
        )
    };
}
