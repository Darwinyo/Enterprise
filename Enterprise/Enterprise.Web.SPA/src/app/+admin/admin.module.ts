import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// Modules


// Components


// Containers
import { ProductEditorComponent } from './containers/product-editor/product-editor.component';
import { PeriodeEditorComponent } from './containers/periode-editor/periode-editor.component';

// Routes
import { AdminRouteModule } from './routes/admin-route.module';

// Services

@NgModule({
  declarations: [
    PeriodeEditorComponent,
    ProductEditorComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    AdminRouteModule,
    // StoreModule.forRoot()
  ],
  exports: [
  ],
  providers: [
  ]
})
export class AdminModule { }
