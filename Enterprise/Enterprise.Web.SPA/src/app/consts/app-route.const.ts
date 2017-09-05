import { PeriodeEditorComponent } from './../containers/periode-editor/periode-editor.component';
import { ProductEditorComponent } from './../containers/product-editor/product-editor.component';
import { ProductDetailsComponent } from './../containers/product-details/product-details.component';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from '../containers/home/home.component';
// import { LayoutsComponent } from '../containers/area-components/layouts/layouts.component';
// import { GraphFlotComponent } from '../containers/area-components/graph-flot/graph-flot.component';
// import { MailInboxComponent } from '../containers/area-components/mail-inbox/mail-inbox.component';
// import { GraphSparklineComponent } from '../containers/area-components/graph-sparkline/graph-sparkline.component';
// import { GraphPeityComponent } from '../containers/area-components/graph-peity/graph-peity.component';
// import { GraphC3Component } from '../containers/area-components/graph-c3/graph-c3.component';
// import { GraphChartistComponent } from '../containers/area-components/graph-chartist/graph-chartist.component';
// import { GraphChartjsComponent } from '../containers/area-components/graph-chartjs/graph-chartjs.component';
// import { GraphRickshawComponent } from '../containers/area-components/graph-rickshaw/graph-rickshaw.component';
// import { GraphMorrisComponent } from '../containers/area-components/graph-morris/graph-morris.component';
import { ErrorNotFoundComponent } from '../containers/error-not-found/error-not-found.component';

export const appRoutes: Routes = [
    { path: 'index', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent, pathMatch: 'full' },
    { path: 'product-details/:id', component: ProductDetailsComponent, pathMatch: 'full' },
    { path: 'product-editor', component: ProductEditorComponent, pathMatch: 'full' },
    { path: 'periode-editor', component: PeriodeEditorComponent, pathMatch: 'full' },
    // { path: 'dashboard', loadChildren: '../modules/dashboard/dashboard.module#DashboardModule'},
    // { path: 'layouts', component: LayoutsComponent },
    // { path: 'graph-flot', component: GraphFlotComponent },
    // { path: 'graph-morris', component: GraphMorrisComponent },
    // { path: 'graph-rickshaw', component: GraphRickshawComponent },
    // { path: 'graph-chartjs', component: GraphChartjsComponent },
    // { path: 'graph-chartist', component: GraphChartistComponent },
    // { path: 'graph-c3', component: GraphC3Component },
    // { path: 'graph-piety', component: GraphPeityComponent },
    // { path: 'graph-sparkline', component: GraphSparklineComponent },
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: '**', component: ErrorNotFoundComponent }
]
