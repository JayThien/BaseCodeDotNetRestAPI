import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BaseProductsRoutingModule } from './base-products-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BaseProductComponent } from './page/base-product/base-product.component';
import { BaseProductsComponent } from './page/base-products/base-products.component';


@NgModule({
  declarations: [
    BaseProductsComponent,
    BaseProductComponent,

  ],
  imports: [
    CommonModule,
    BaseProductsRoutingModule,
    SharedModule.forRoot()
  ]
})
export class BaseProductsModule { }
