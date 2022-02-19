import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PromotionsRoutingModule } from './promotions-routing.module';
import { PromotionsComponent } from './page/promotions/promotions.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { PromotionComponent } from './page/promotion/promotion.component';


@NgModule({
  declarations: [
    PromotionsComponent,
    PromotionComponent
  ],
  imports: [
    CommonModule,
    PromotionsRoutingModule,
    SharedModule.forRoot()
  ]
})
export class PromotionsModule { }
