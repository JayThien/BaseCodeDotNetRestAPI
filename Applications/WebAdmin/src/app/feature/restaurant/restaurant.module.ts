import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from 'src/app/shared/share.module';
import { RestaurantRoutingModule } from './restaurant-routing.module';
import { RestaurantComponent } from './pages/restaurant/restaurant.component';


@NgModule({
  declarations: [
    RestaurantComponent,
  ],
  imports: [
    CommonModule,
    RestaurantRoutingModule,
    SharedModule.forRoot(),
  ]
})
export class RestaurantModule { }
