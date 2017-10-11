import { FormsModule } from '@angular/forms';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { CustomRouterStateSerializer } from './shared/utils';
import { environment } from './../environments/environment.prod';
import { metaReducers, routerReducers } from './reducers/app-state.reducer';
import { RouterModule } from '@angular/router';
import { EffectsModule } from '@ngrx/effects';
// Angular
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';

// 3rd Party
import { StoreModule } from '@ngrx/store';

// Modules
import { CoreModule } from './core/core.module';

// Components
import { AppComponent } from './app.component';

// Containers

// Signal R

// Routes

// Services

// Helpers
import { PostApiHelper } from './shared/helpers/post-api.helper';
import { StoreRouterConnectingModule, RouterStateSerializer } from '@ngrx/router-store';



@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    RouterModule,
    HttpModule,
    BrowserModule,
    FormsModule,
    StoreModule.forRoot(routerReducers, { metaReducers }),
    StoreRouterConnectingModule,
    environment.production ? StoreDevtoolsModule.instrument() : [],
    EffectsModule.forRoot([]),
    CoreModule,
  ],
  providers: [
    PostApiHelper,
    { provide: RouterStateSerializer, useClass: CustomRouterStateSerializer }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
