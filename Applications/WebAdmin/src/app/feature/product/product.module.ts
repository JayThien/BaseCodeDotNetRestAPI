import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductRoutingModule } from './product-routing.module';
import { SharedModule } from 'src/app/shared/share.module';
import { ProductComponent } from './pages/product/product.component';
import { AdditionModalComponent } from './components/addition-modal/addition-modal.component';

@NgModule({
  declarations: [
    ProductComponent,
    AdditionModalComponent
  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    SharedModule.forRoot(),
  ]
})
export class ProductModule { }
