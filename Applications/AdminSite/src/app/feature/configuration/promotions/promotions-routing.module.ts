import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PromotionComponent } from './page/promotion/promotion.component';
import { PromotionsComponent } from './page/promotions/promotions.component';


const routes: Routes = [

  { path: '', component: PromotionsComponent, },
  { path: ':id', component: PromotionComponent, },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PromotionsRoutingModule { }
