import { UserLoginResponseModel } from './../../models/responses/user-login-response/user-login-response.model';
import { UserLoginViewModel } from './../../viewmodels/user-login/user-login.viewmodel';
import { UserRegistrationResponseModel } from './../../models/responses/user-registration-response/user-registration-response.model';
import { UserLoginModel } from './../../models/user/user-login/user-login.model';
import { Observable } from 'rxjs/Rx';
import { Http, Headers } from '@angular/http';
import {
    CheckUserLoginControllerUrl, CheckPhoneControllerUrl, CheckEmailControllerUrl,
    UserRegistrationControllerUrl, UserLoginControllerUrl
} from './../../../shared/consts/api-url.const';
import { serverUrl } from './../../../shared/consts/server-url.const';
import { Injectable } from '@angular/core';

@Injectable()
export class UserService {
    urlCheckUserLoginController = serverUrl + CheckUserLoginControllerUrl;
    urlCheckPhoneController = serverUrl + CheckPhoneControllerUrl;
    urlCheckEmailController = serverUrl + CheckEmailControllerUrl;
    urlUserRegistrationController = serverUrl + UserRegistrationControllerUrl;
    urlUserLoginController = serverUrl + UserLoginControllerUrl;
    constructor(private http: Http) { }
    checkUserLogin(userLogin: string): Observable<boolean> {
        const headers: Headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post(this.urlCheckUserLoginController, userLogin, { headers: headers }).map(
            (response: any) => response._body === 'true'
        )
    }
    checkEmail(email: string) {
        const headers: Headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post(this.urlCheckEmailController, email, { headers: headers }).map(
            (response: any) => response._body === 'true'
        )
    }
    checkPhone(phone: string) {
        const headers: Headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post(this.urlCheckPhoneController, phone, { headers: headers }).map(
            (response: any) => response._body === 'true'
        )
    }
    userLogin(userLoginViewModel: UserLoginViewModel): Observable<UserLoginResponseModel> {
        const headers: Headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post(this.urlUserLoginController, userLoginViewModel, { headers: headers }).map(
            (response: any) => response.json()
        )
    }
    userRegistration(userLoginModel: UserLoginModel): Observable<UserRegistrationResponseModel> {
        const headers: Headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post(this.urlUserRegistrationController, userLoginModel, { headers: headers }).map(
            (res) => res.json()
        )
    }
    deleteUser(userId: string) {
        this.http.delete(this.urlUserRegistrationController + '/' + userId).map(
            null
        )
    }
}
