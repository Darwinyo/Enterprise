# Enterprise.Web.SPA

### Notes
This project is using Angular CLI.
There's a webpack file in root folder (generated by CLI)

## Project Structure
- app is this application root
  - +admin
    - This module is lazy loaded
    - This module is intended for Admin
  - auth
    - This is authentication module
    - it has guard service for verify userlogin before its get routed.
    - this module is first layer before any modules
  - core
    - This is the core app module its have navbar, errorpages.
    - This Module has auth module dependecies
    - This is the second layer before any modules
  - product
    - Do contains every components that related about products.
    - it has all two dependencies (Auth & Core)
  - user
    - This Module is not ready yet.
    - This module will be responsible for user details, user settings, etc...
  - reducers
    - This Folder Contains app-state reducers (Main Reducer).
    - This Folder Contains root state that all other state from other module would extends
  - shared
    - shared for every modules
- css
  - 3rd-party css Library
- img
  - Contains some logos
- js 
  - Contains 3rd-party js Library

## Modular Structure
### actions
this folder will retains the strong types actions , has actioncreators, actions types for strong typing.
``` TypeScript
// auth.actions.ts
import { UserLoginModel } from './../models/user/user-login/user-login.model';
import { UserLoginViewModel } from './../viewmodels/user-login/user-login.viewmodel';
import { UserLoginResponseModel } from './../models/responses/user-login-response/user-login-response.model';
import { Action } from '@ngrx/store';
// This Part Strong Typing Actions
export const LOG_IN = '[AUTH] LOG_IN';
export const LOG_OUT = '[AUTH] LOG_OUT';
export const LOG_IN_REDIRECT = '[AUTH] LOG_IN_REDIRECT';
export const LOG_IN_SUCCESS = '[AUTH] LOG_IN_SUCCESS';
export const LOG_IN_FAILURE = '[AUTH] LOG_IN_FAILURE';
export const REGISTRATION = '[AUTH] REGISTRATION';
export const REGISTRATION_SUCCESS = '[AUTH] REGISTRATION_SUCCESS';
export const REGISTRATION_FAILURE = '[AUTH] REGISTRATION_FAILURE';

// This Is Actions Creators
export class Login implements Action {
    readonly type: string = LOG_IN;
	// we do define its payload to create Actions
    constructor(public payload: UserLoginViewModel) { }
}
export class LoginRedirect implements Action {
    readonly type: string = LOG_IN_REDIRECT;
}
export class LoginSuccess implements Action {
    readonly type: string = LOG_IN_SUCCESS;
    constructor(public payload: UserLoginResponseModel) { }
}
export class LoginFailure implements Action {
    readonly type: string = LOG_IN_FAILURE;
    constructor(public payload: any) { }
}
export class Logout implements Action {
    readonly type: string = LOG_OUT;
}
export class Registration implements Action {
    readonly type: string = REGISTRATION;
    constructor(public payload: UserLoginModel) { }
}
export class RegistrationSuccess implements Action {
    readonly type: string = REGISTRATION_SUCCESS;
}
export class RegistrationFailure implements Action {
    readonly type: string = REGISTRATION_FAILURE;
    constructor(public payload: any) { }
}
// This part We will use in Reducer (strong type sake)
export type Actions =
    | Login
    | Logout
    | LoginRedirect
    | LoginSuccess
    | LoginFailure
    | Registration
    | RegistrationSuccess
    | RegistrationFailure;
```
### components
this folder should store dumb components(which is no API Calls, no ngrx (store) Dependencies. only interact with event emitters).
``` TypeScript
// app-cart.components.ts
import { CartViewmodel } from './../../viewmodels/cart/cart.viewmodel';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  // this components only comunicate with eventemitter.
  @Output() reviewEvent: EventEmitter<string>;
  cartList: CartViewmodel[];
  constructor() {
    this.reviewEvent = new EventEmitter();
    this.cartList = [];
  }

  ngOnInit() {
  }
  initCartList(cartItems: CartViewmodel[]) {
    this.cartList = cartItems;
  }
  goToProductDetail(productId: string) {
  // this line will trigger reviewEvent, its parent component will be notified.
    this.reviewEvent.emit(productId);
  }
}

```

### containers
this folder only store smart components (calls API, able to dispatch actions,feed data to its child dumb components)
``` TypeScript
// registration.component.ts
import * as fromAuth from './../../reducers/auth-state.reducer';
import * as AuthActions from './../../actions/auth.actions';
@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit, AfterViewInit, OnDestroy {
  isUserLoginServerError: boolean;
  isPhoneServerError: boolean;
  isEmailServerError: boolean;
  checkEmailObservable$: Observable<any>;
  checkPhoneObservable$: Observable<any>;
  checkUserLoginObservable$: Observable<any>;
  pending$: Observable<boolean>;
  error$: Observable<string | null>;
  userLoginModel: UserLoginModel;
  serverMessageEmail: string;
  serverMessagePhone: string;
  serverMessageUserLogin: string;
  messageUserLoginError: string;
  messageEmailError: string;
  messagePhoneError: string;
  @ViewChild('registrationForm') registrationForm: NgForm;
  @ViewChild('userloginTxtBox') userloginTxtBox: ElementRef;
  @ViewChild('phoneTxtBox') phoneTxtBox: ElementRef;
  @ViewChild('emailTxtBox') emailTxtBox: ElementRef;

  constructor(
    private userService: UserService,
    private router: Router,
    private postApiHelper: PostApiHelper,
    private store: Store<fromAuth.State>
  ) {
    this.userLoginModel = <UserLoginModel>{};
    this.isEmailServerError = false;
    this.isPhoneServerError = false;
    this.isUserLoginServerError = false;
    this.pending$ = this.store.select(fromAuth.getRegistrationPending);
    this.error$ = this.store.select(fromAuth.getRegistrationError);
  }

  ngOnInit() {
  }
  // This will trigger after view initialize (so it can find controls perfectly)
  ngAfterViewInit(): void {
  // Rxjs niffty Stuff
    this.checkUserLoginObservable$ = Observable
	
	// making new observable that come from event in this case it come from userloginTxtBox, input event.
      .fromEvent(this.userloginTxtBox.nativeElement, 'input');
    this.checkUserLoginObservable$
	
	// this will get specific value that i care about
      .map((event: any) => event.target.value)
	  
	  // wait 1.5 sec if user keep typing in that duration, it will reset timer.
      .debounceTime(1500)
	  
	  // this will trigger when user stopped typing for 1.5 sec.
	  // this will filter => do value that i care has changed?. in this case (event.target.value=> come from userloginTxtBox)
      .distinctUntilChanged()
	  
	  // this will trigger if textbox value changed & user has stopped typing for 1.5 s.
	  // since observable is created by using event stream. this will not have complete flag.
	  // so we just subscribe it in next flag
      .subscribe((value) => {
        if (this.registrationForm.controls['userlogin'].valid) {
		// we call this method.
          this.checkUserLogin(value);
        }
      });
	  
    this.checkPhoneObservable$ = Observable
      .fromEvent(this.phoneTxtBox.nativeElement, 'input');
    this.checkPhoneObservable$
      .map((event: any) => event.target.value)
      .debounceTime(1500)
      .distinctUntilChanged()
      .subscribe((value) => {
        if (this.registrationForm.controls['phone'].valid) {
          this.checkPhone(value);
        }
      });
    this.checkEmailObservable$ = Observable
      .fromEvent(this.emailTxtBox.nativeElement, 'input');
    this.checkEmailObservable$
      .map((event: any) => event.target.value)
      .debounceTime(1500)
      .distinctUntilChanged()
      .subscribe((value) => {
        if (this.registrationForm.controls['email'].valid) {
          this.checkEmail(value);
        }
      });
  }
  ngOnDestroy(): void {

  }
  checkUserLogin(userLogin: string): void {
  // i do make Injectable helper for making json string
  // calling service directly from container
    this.userService.checkUserLogin(this.postApiHelper.concatDoubleQuote(userLogin)).subscribe(
      (result) => {
        this.isUserLoginServerError = result;
        if (result) {
          this.serverMessageUserLogin = 'Userlogin already registered';
        }
      },
      (err) => {
        this.isUserLoginServerError = true;
        this.serverMessageUserLogin = err;
        this.userLoginValidator(this.serverMessageUserLogin);
      },
	  // when the stream complete
	  // call this method
      () => this.userLoginValidator(this.serverMessageUserLogin)
    )
  }
  checkPhone(phone: string): void {
    this.userService.checkPhone(this.postApiHelper.concatDoubleQuote(phone)).subscribe(
      (result) => {
        this.isPhoneServerError = result;
        if (result) {
          this.serverMessagePhone = 'Phone already registered';
        }
      },
      (err) => {
        this.isPhoneServerError = true;
        this.serverMessagePhone = err;
        this.phoneValidator(this.serverMessagePhone);
      },
      () => this.phoneValidator(this.serverMessagePhone)
    )
  }
  checkEmail(email: string): void {
    this.userService.checkEmail(this.postApiHelper.concatDoubleQuote(email)).subscribe(
      (result) => {
        this.isEmailServerError = result;
        if (result) {
          this.serverMessageEmail = 'Email already registered';
        }
      },
      (err) => {
        this.isEmailServerError = true;
        this.serverMessageEmail = err;
        this.emailValidator(this.serverMessageEmail);
      },
      () => this.emailValidator(this.serverMessageEmail)
    )
  }
  userLoginValidator(message: string) {
    const control = this.registrationForm.controls['userlogin'];
    if (this.isUserLoginServerError) {
      control.setErrors({ backend: { error: message } });
      this.messageUserLoginError = control.errors['backend'].error;
    }
  }
  phoneValidator(message: string) {
    const control = this.registrationForm.controls['phone'];
    if (this.isPhoneServerError) {
      control.setErrors({ backend: { error: message } });
      this.messagePhoneError = control.errors['backend'].error;
    }
  }
  emailValidator(message: string) {
    const control = this.registrationForm.controls['email'];
    if (this.isEmailServerError) {
      control.setErrors({ backend: { error: message } });
      this.messageEmailError = control.errors['backend'].error;
    }
  }
  formValidator(): boolean {
    return this.registrationForm.invalid;
  }
  registerUser(registrationForm: NgForm) {
    const userLoginModel = <UserLoginModel>{
      userLogin: registrationForm.value['userlogin'],
      email: registrationForm.value['email'],
      phoneNumber: registrationForm.value['phone'],
      password: registrationForm.value['password']
    }
	// this will dispatch action to reducer.
	// since i have define side effect for action being dispatch, that will call side effect too.
	// note : in side effect i'll call service to do post API.
    this.store.dispatch(new AuthActions.Registration(userLoginModel));
  }
}
```
### consts
this folder contains some consts items. for strong typing sake
``` Typescript
// api-url.const.ts
export const CategoryControllerUrl = '/api/categoryproduct';
export const ChatControllerUrl = '/api/chat';
export const CityControllerUrl = '/api/city';
export const HotProductControllerUrl = '/api/hotproduct';
export const PeriodeControllerUrl = '/api/periode';
export const ProductControllerUrl = '/api/product';
export const ProductReviewControllerUrl = '/api/productreview';
export const ProductImagesControllerUrl = '/api/productimages';
export const ProductSpecsControllerUrl = '/api/productspecs';
export const RecommendedProductControllerUrl = '/api/recommendedproduct';
export const ProductVariationControllerUrl = '/api/productvariation';
export const CheckUserLoginControllerUrl = '/api/checkuserlogin';
export const CheckEmailControllerUrl = '/api/checkemail';
export const CheckPhoneControllerUrl = '/api/checkphone';
export const UserRegistrationControllerUrl = '/api/userregistration';
export const UserLoginControllerUrl = '/api/userlogin';

// product-route.const.ts
export const productRoutes: Routes = [
    { path: 'home', component: HomeComponent, pathMatch: 'full' },
    { path: 'product-details/:id', component: ProductDetailsComponent, pathMatch: 'full' }
]


```
### effects
this folder contains ngrx/effects that once our action dispatch, this side effects would triggers(we can dispatch another actions,console log, rerouting,....).

``` TypeScript
// login.effects.ts
@Injectable()
export class LoginEffects {

    @Effect()
    login$ = this.actions$
	
	// this will get triggered when => AuthActions.LOG_IN action dispatched
        .ofType(AuthActions.LOG_IN)
		
		// get it's payload from that action
        .map((action: AuthActions.Login) => action.payload)
        .exhaustMap(userLogin =>
		
			// trigger services to call API
            this.userService.userLogin(userLogin)
                .map(response => {
                    if (response.isLogged === true) {
					
						// dispatch another actions
                        return new AuthActions.LoginSuccess(response)
                    } else {
                        return new AuthActions.LoginFailure('Wrong Pass or UserName')
                    }
                })
                .catch(err => of(new AuthActions.LoginFailure(err))));
    @Effect({ dispatch: false })
    loginRedirect$ = this.actions$
        .ofType(AuthActions.LOG_IN_REDIRECT)
		
		// do this when this AuthActions.LOG_IN_REDIRECT Action triggered
        .do(() => this.router.navigate(['/']));
    @Effect({ dispatch: false })
    loginSuccess$ = this.actions$
        .ofType(AuthActions.LOG_IN_SUCCESS)
        .do(() => {
            alert('youre logged in');
            this.navStore.dispatch(new NavbarActions.NavLogged());
            this.router.navigate(['/home']);
        });
    @Effect({ dispatch: false })
    loginFailure$ = this.actions$
        .ofType(AuthActions.LOG_IN_FAILURE)
        .do((err) => alert((<AuthActions.RegistrationFailure>err).payload));
    @Effect({ dispatch: false })
    logout$ = this.actions$
        .ofType(AuthActions.LOG_OUT)
        .do(() => alert('youre logged out'))
    constructor(
        private actions$: Actions,
        private userService: UserService,
        private router: Router,
        private navStore: Store<fromCore.State>
    ) { }
}

```
### models
this project contains models that return from API calls
``` TypeScript
// user-login-response.model.ts
export interface UserLoginResponseModel {
    userKey: string;
    userLogin: string;
    isLogged: boolean;
}

```
### viewmodels
this project contains models for ours view, model that we dispatch to API.
``` Typescript
// product-card.viewmodel.ts
export interface ProductCardViewModel {
    productId: string;
    productFrontImage: string;
    productRating: number;
    productName: string;
    productFavorite: number;
    productReview: number;
    productPrice: number;
    stars: string[];
}

```
### reducers
this project contains reducers.
In reducers i usually define its state model, InitialState, reducer itself,select its state.
``` Typescript
// auth.reducer.ts

// This Interface is Model of Current Store State
export interface State {
    userKey: string;
    userLogin: string;
    isLogged: boolean;
}
// This is InitialState
export const INITIAL_STATE = {
    userKey: undefined,
    userLogin: undefined,
    isLogged: false
}
// This Reducer Takes 2 parameters
// first is state (if we don't define this initialstate will be assign)
// Second parameter is action we would like to dispatch.
// action parameter is type of AuthActions.Actions (i defined this type in Action file),this is strong typing actions
export function authReducer(state = INITIAL_STATE, action: AuthActions.Actions): State {
    switch (action.type) {
        case AuthActions.LOG_IN_SUCCESS: {
            return {
				// this spread operator => copy state parameter
                ...state,
                userKey: (<LoginSuccess>action).payload.userKey,
                userLogin: (<LoginSuccess>action).payload.userLogin,
                isLogged: (<LoginSuccess>action).payload.isLogged,
            };
        }
        case AuthActions.LOG_OUT: {
			// same purpose with spread operator
            return Object.assign({}, state, INITIAL_STATE)
        }
        default:
            return state;
    }
}
// this strong type function, i've used this for root state.
export const getLoggedIn = (state: State) => state.isLogged;
export const getUserLogin = (state: State) => state.userLogin;
export const getUserKey = (state: State) => state.userKey;

```
In root reducer folder there is the root reducer for that module that extends from other state.
``` TypeScript
// auth-state.reducer.ts
// This is this module root State
export interface AuthState {
	// come from auth state
    userState: fromAuth.State;
	// come from login state
    loginState: fromLogin.State;
	// come from registration state
    registrationState: fromRegistration.State;
}
// this state extends app root state
export interface State extends fromRoot.State {
    authState: AuthState;
}

export const authStateReducer = {
    userReducer: fromAuth.authReducer,
    loginReducer: fromLogin.loginReducer,
    registrationReducer: fromRegistration.registrationReducer
}

export const selectAuthState = createFeatureSelector<AuthState>('auth');

export const selectUserState = createSelector(
    selectAuthState,
    (state: AuthState) => state.userState
);
export const getLoggedIn = createSelector(
    selectUserState,
	// here we used our const function for selection
    fromAuth.getLoggedIn
);
export const getUserLogin = createSelector(
    selectUserState,
    fromAuth.getUserLogin
);
export const getuserKey = createSelector(
    selectUserState,
    fromAuth.getUserKey
);
);

```
### routes
this project has routing module.
``` TypeScript
// auth-route.module.ts
@NgModule({
  imports: [
    RouterModule.forChild(
      authRoute.authRoutes
    )
  ],
  exports: [RouterModule]
})
export class AuthRouteModule { }

```
### services
this folder contains services that used for calling API,etc
``` TypeScript
// auth-guard.service.ts
@Injectable()
export class AuthGuardService implements CanActivate {
	// using ngrx Store
    constructor(private store: Store<fromAuth.State>) { }
    canActivate(): Observable<boolean> {
        return this.store
		
			// select from auth state, using selector we define in our auth root state
            .select(fromAuth.getLoggedIn)
            .map(authed => {
                if (!authed) {
				
					// dispatch new action,that trigger loginRedirect Effect
                    this.store.dispatch(new AuthActions.LoginRedirect());
                    return false;
                }
                return true;
            })
            .take(1);
    }
}
```
### helpers
this folder contains helper class that we inject to class that need those functions.
``` TypeScript
// post-api.helper.ts
@Injectable()
// i just make this helper class available for every componensts that inject it
export class PostApiHelper {
    concatDoubleQuote(plainStr: string): string {
        return '"' + plainStr + '"';
    }
}
```
### signalr
this folder contains signalr hub.
``` TypeScript
// chat.signalr.ts (abstraction)
import { ChatModel } from './../../../models/chat/chat.model';
// define hubs
export interface ChatSignalR {
    chatHub: ChatProxy
}

// just for easy references
export interface ChatProxy {
    client: ChatClient;
    server: ChatServer;
}

// this is abstraction for client side implementation of signalr
export interface ChatClient {
    setConnectionId: (id: string) => void;
    send: (message: ChatModel) => void;
}

// this is abstraction for server side implementation of signalr
export interface ChatServer {
    subscribe(groupName: string): void;
    unsubscribe(groupName: string): void;
}

export enum SignalRConnectionStatus {
    Connected = 1,
    Disconnected = 2,
    Error = 3
}

// chat.hub.ts

// declare jquery since angular nature doesn't playing with JQuery
declare var $: any;
export class ChatHub {
    chatConnection: ChatSignalR;
    chatHub: ChatProxy;
    chatServer: ChatServer;

    currentState: SignalRConnectionStatus;

    connectionState: Observable<SignalRConnectionStatus>;
    addChat: Observable<ChatModel>;
    setConnectionId: Observable<string>;

    connectionStateSubject: Subject<SignalRConnectionStatus>;
    chatSubject: Subject<ChatModel>;
    setConnectionIdSubject: Subject<string>;

    constructor() {
        this.chatSubject = new Subject<ChatModel>();
        this.setConnectionIdSubject = new Subject<string>();
        this.connectionStateSubject = new Subject<SignalRConnectionStatus>();

        this.currentState = SignalRConnectionStatus.Disconnected;

        this.setConnectionId = this.setConnectionIdSubject.asObservable();
        this.connectionState = this.connectionStateSubject.asObservable();
        this.addChat = this.chatSubject.asObservable();
    }
	// this method will be triggered in app components
    initSignalRConnection(): Observable<SignalRConnectionStatus> {
        $.connection.hub.logging = true;
        this.chatConnection = <ChatSignalR>$.connection;
        this.chatHub = this.chatConnection.chatHub;
        this.chatServer = this.chatHub.server;
        this.registerEventHandler();
        return this.startConnection();
    }
	// register events callbacks
    registerEventHandler() {
        this.chatHub.client.send = chatModel => this.onAddChat(chatModel);
        this.chatHub.client.setConnectionId = id => this.onSetConnectionId(id);
    }
    startConnection(): Observable<SignalRConnectionStatus> {
	
		// start connections
        $.connection.hub.start()
            .done(response => this.setConnectionState(SignalRConnectionStatus.Connected))
            .fail(error => this.connectionStateSubject.error(error));
        return this.connectionState;
    }
    setConnectionState(connectionState: SignalRConnectionStatus) {
        console.log('connection state changed to: ' + connectionState);
        this.currentState = connectionState;
        this.connectionStateSubject.next(connectionState);
    }
	
	// these functions below is callbacks functions
    onAddChat(chatModel: ChatModel) {
        console.log('come from onAddChat Method' + chatModel);
		
		// this will trigger every observer that subsribe to this subject
        this.chatSubject.next(chatModel);
    }
    onSetConnectionId(id: string) {
        console.log('onSetConnectionId Called');
        this.setConnectionIdSubject.next(id);
    }
}
// app.component.ts
export class AppComponent implements OnInit {
  @ViewChild('chat') chat: ChatComponent;
  chatModel: ChatModel[];
  userId: string;
  groupId: string;
  chatItem: ChatModel;
  connectionId: string;
  error: any;
  constructor(private router: Router, private chatService: ChatService) {
  }
  ngOnInit(): void {
  
  	// temporary code, i'll replace this after auth module complete.
    this.userId = prompt('Input UserId Please', 'User');
    this.groupId = 'TestGroup';
	// invoke signalr connection
    this.chatService.initSignalRConnection().subscribe(
      null,
      error => console.log('Error on init: ' + error)
    )
    this.listenToConnection();
    this.listenToConnectionState();
    this.chatService.addChat.subscribe(
      message => {
        console.log('received..');
        console.log(message);
        this.chatModel.push(message)
      }
    )
  }
  fetchChats(groupId: string) {
    this.chatService.getChatHistoryByGroupId(groupId).subscribe(
      (result) => this.chatModel = result,
      (err) => console.log(err),
      () => this.chat.populateChats(this.chatModel)
    )
  }
  // set Connection id
  listenToConnection() {
    this.chatService.setConnectionId.subscribe(
      id => {
        console.log(id);
        this.connectionId = id;
      }
    )
  }
  
  // get state and get all chat records
  listenToConnectionState() {
    this.chatService.connectionState.subscribe(
      connectionState => {
        if (connectionState === SignalRConnectionStatus.Connected) {
          console.log('Connected');
		  
		  // call services
          this.fetchChats(this.groupId);
        } else {
          console.log(connectionState.toString());
        }
      },
      error => {
        this.error = error;
        console.log(error);
      }
    )
  }
  send(event) {
    this.chatItem = <ChatModel>{
      userId: this.userId,
      groupId: this.groupId,
      message: event,
      messageDatetime: new Date()
    }
    this.chatService.postChat(this.chatItem).subscribe(
      x => console.log('Posted'),
      (err) => console.log(),
      () => console.log('Post Complete')
    )
  }
}

```