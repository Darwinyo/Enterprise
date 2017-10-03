import { LoginComponent } from './../containers/login/login.component';
import { RegistrationComponent } from './../containers/registration/registration.component';
import { Routes } from '@angular/router';

export const authRoutes: Routes = [
    { path: 'register', component: RegistrationComponent, pathMatch: 'full' },
    { path: 'login', component: LoginComponent, pathMatch: 'full' },
]
