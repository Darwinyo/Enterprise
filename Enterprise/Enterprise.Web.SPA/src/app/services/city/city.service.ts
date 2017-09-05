import { CityModel } from './../../models/city/city.model';
// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class CityService {
    urlCityController = 'http://localhost:63853/api/city';
    constructor(private http: Http) { }
    GetListOfCity(): Observable<CityModel[]> {
        return this.http.get(this.urlCityController).map(result => result.json());
    }
    GetCityById(cityId: number) {
        return this.http.get(this.urlCityController + '/' + cityId).map(result => result.text());
    }
}
