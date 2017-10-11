import { ChatHub } from './signalr/chathub/chat.hub';
import { ChatService } from './services/chat/chat.service';
import { ChatEffects } from './effects/chat.effects';
import { ChatComponent } from './components/chat/chat.component';
import { NavbarEffects } from './effects/navbar.effects';
import { EffectsModule } from '@ngrx/effects';
import { coreStateReducer } from './reducers/core-state.reducer';
import { StoreModule } from '@ngrx/store';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// Modules
import { ProductModule } from './../product/product.module';
import { AuthModule } from 'app/auth/auth.module';

// Components
import { NavSearchbarComponent } from './components/nav-searchbar/nav-searchbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { CartComponent } from './components/cart/cart.component';

// Containers
import { NavbarComponent } from './containers/navbar/navbar.component';
import { ErrorNotFoundComponent } from './containers/error-not-found/error-not-found.component';

// Routes
import { AppRouteModule } from './routes/app-route.module';

// Services


// SignalR


@NgModule({
  declarations: [
    CartComponent,
    FooterComponent,
    NavSearchbarComponent,
    ErrorNotFoundComponent,
    NavbarComponent,
    ChatComponent
  ],
  imports: [
    AuthModule,
    ProductModule,
    AppRouteModule,
    CommonModule,
    RouterModule,
    FormsModule,
    StoreModule.forFeature('core', coreStateReducer),
    EffectsModule.forFeature([NavbarEffects, ChatEffects])
  ],
  exports: [
    FooterComponent,
    ErrorNotFoundComponent,
    NavbarComponent,
    ChatComponent
  ],
  providers: [
    ChatService,
    ChatHub,
  ]
})
export class CoreModule { }
