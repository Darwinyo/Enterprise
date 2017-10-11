
import { RegistrationEffects } from './effects/registration.effects';
import { LoginEffects } from './effects/login.effects';
import { AuthGuardService } from './services/auth/auth-guard.service';
import { LoginComponent } from './containers/login/login.component';
import { EffectsModule } from '@ngrx/effects';
import { authStateReducer } from './reducers/auth-state.reducer';
import { StoreModule } from '@ngrx/store';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// Modules


// Components
import { LoginNavComponent } from './components/login-nav/login-nav.component';

// Containers
import { RegistrationComponent } from './containers/registration/registration.component';

// Routes
import { AuthRouteModule } from './routes/auth-route.module';

// Services
import { UserService } from './services/user/user.service';

@NgModule({
  declarations: [
    RegistrationComponent,
    LoginComponent,
    LoginNavComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    AuthRouteModule,
    StoreModule.forFeature('auth', authStateReducer),
    EffectsModule.forFeature([LoginEffects, RegistrationEffects])
  ],
  providers: [
    UserService,
    AuthGuardService
  ],
  exports: [
    LoginNavComponent
  ]
})
export class AuthModule { }
