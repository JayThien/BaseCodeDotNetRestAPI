import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RestaurantsRoutingModule } from './restaurants-routing.module';
import { RestaurantsComponent } from './page/restaurants/restaurants.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { RestaurantComponent } from './page/restaurant/restaurant.component';


@NgModule({
  declarations: [
    RestaurantsComponent,
    RestaurantComponent
  ],
  imports: [
    CommonModule,
    RestaurantsRoutingModule,
    SharedModule.forRoot()
  ]
})
export class RestaurantsModule { }
