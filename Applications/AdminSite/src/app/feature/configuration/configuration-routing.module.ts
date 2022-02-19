import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConfigurationComponent } from './configuration.component';

const routes: Routes = [
  {
    path: '', component: ConfigurationComponent, children: [
      {
        path: 'users',
        loadChildren: () => import('./users/users.module').then(m => m.UsersModule)
      }, {
        path: 'areas',
        loadChildren: () => import('./areas/areas.module').then(m => m.AreasModule)
      }, {
        path: 'restaurants',
        loadChildren: () => import('./restaurants/restaurants.module').then(m => m.RestaurantsModule)
      }, {
        path: 'base-products',
        loadChildren: () => import('./base-products/base-products.module').then(m => m.BaseProductsModule)
      }, {
        path: 'promotions',
        loadChildren: () => import('./promotions/promotions.module').then(m => m.PromotionsModule)
      },
      // { path: 'restaurants', component: Nav3Component },
      // { path: 'base-products', component: Nav1Component },
      // { path: 'menus', component: Nav2Component },
      // { path: 'promotions', component: Nav3Component },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConfigurationRoutingModule { }
