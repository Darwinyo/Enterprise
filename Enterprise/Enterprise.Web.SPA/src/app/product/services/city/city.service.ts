import { serverUrl } from './../../../shared/consts/server-url.const';
import { CityControllerUrl } from './../../../shared/consts/api-url.const';
import { CityModel } from './../../models/city/city.model';
// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class CityService {
    urlCityController = serverUrl + CityControllerUrl;
    constructor(private http: Http) { }
    getListOfCity(): Observable<CityModel[]> {
        return this.http.get(this.urlCityController).map(result => result.json());
    }
    getCityById(cityId: number) {
        return this.http.get(this.urlCityController + '/' + cityId).map(result => result.text());
    }
}
