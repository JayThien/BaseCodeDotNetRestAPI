import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from 'src/app/shared/share.module';
import { PromotionRoutingModule } from './promotion-routing.module';
import { PromotionComponent } from './pages/promotion/promotion.component';


@NgModule({
  declarations: [
    PromotionComponent,
  ],
  imports: [
    CommonModule,
    PromotionRoutingModule,
    SharedModule.forRoot(),
  ]
})
export class PromotionModule { }
