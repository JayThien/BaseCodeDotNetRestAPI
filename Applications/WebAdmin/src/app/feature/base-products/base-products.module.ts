import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/share.module';
import { BaseProductsComponent } from './pages/base-products/base-products.component';
import { BaseProductsRoutingModule } from './base-products-routing.module';

@NgModule({
  declarations: [
    BaseProductsComponent,
  ],
  imports: [
    CommonModule,
    BaseProductsRoutingModule,
    SharedModule.forRoot(),
  ]
})
export class BaseProductsModule { }
