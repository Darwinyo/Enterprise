import { ImageModel } from './../../models/image-upload/image.model';

// Angular Dependencies
import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

// Vendor
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class ProductService {
    constructor(private http: Http) { }
    TestConnection(images: ImageModel[]): Observable<any> {
        const headers: Headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post('http://localhost:63853/api/product', images, { headers: headers }).map(result => result.json());
    }
    FetchConnection(): Observable<any> {
        const headers: Headers = new Headers();
        return this.http.get('http://localhost:63853/api/product').map(result => result.json());
    }
}
