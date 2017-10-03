import { RouterModule, Routes } from '@angular/router';
import { ErrorNotFoundComponent } from '../containers/error-not-found/error-not-found.component';

export const appRoutes: Routes = [
    { path: 'index', redirectTo: '/home', pathMatch: 'full' },
    { path: 'admin', loadChildren: './../../+admin/admin.module#AdminModule' },
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: '**', component: ErrorNotFoundComponent }
]
