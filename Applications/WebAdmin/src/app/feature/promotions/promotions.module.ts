import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from 'src/app/shared/share.module';
import { PromotionsComponent } from './pages/promotions/promotions.component';
import { PromotionsRoutingModule } from './promotions-routing.module';


@NgModule({
  declarations: [
    PromotionsComponent,
  ],
  imports: [
    CommonModule,
    PromotionsRoutingModule,
    SharedModule.forRoot(),
  ]
})
export class PromotionsModule { }
