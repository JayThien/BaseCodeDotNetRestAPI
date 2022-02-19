import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RestaurantsComponent } from './pages/restaurants/restaurants.component';
import { SharedModule } from 'src/app/shared/share.module';
import { RestaurantsRoutingModule } from './restaurants-routing.module';


@NgModule({
  declarations: [
    RestaurantsComponent,
  ],
  imports: [
    CommonModule,
    RestaurantsRoutingModule,
    SharedModule.forRoot(),
  ]
})
export class RestaurantsModule { }
