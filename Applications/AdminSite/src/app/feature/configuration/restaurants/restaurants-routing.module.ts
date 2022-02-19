import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RestaurantComponent } from './page/restaurant/restaurant.component';
import { RestaurantsComponent } from './page/restaurants/restaurants.component';


const routes: Routes = [

  { path: '', component: RestaurantsComponent, },
  { path: ':id', component: RestaurantComponent, },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RestaurantsRoutingModule { }
