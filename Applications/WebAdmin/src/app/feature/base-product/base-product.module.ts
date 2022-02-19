import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/share.module';
import { BaseProductComponent } from './pages/base-product/base-product.component';
import { BaseProductRoutingModule } from './base-product-routing.module';


@NgModule({
  declarations: [
    BaseProductComponent,
  ],
  imports: [
    CommonModule,
    BaseProductRoutingModule,
    SharedModule.forRoot(),
  ]
})
export class BaseProductModule { }
