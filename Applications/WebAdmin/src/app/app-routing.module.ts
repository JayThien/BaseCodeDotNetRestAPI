import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { LayoutComponent } from './layout/layout.component';
import { ErrorPageComponent } from './shared/components/error-page/error-page.component';
import { MediaViewComponent } from './shared/components/media-view/media-view.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/home' },
  {
    path: '', component: LayoutComponent, canActivate: [AuthGuard], children: [
      { path: 'home', loadChildren: () => import('./feature/home/home.module').then(m => m.HomeModule) },
      {
        path: 'users',
        loadChildren: () => import('./feature/users/users.module').then(m => m.UsersModule)
      },
      {
        path: 'user',
        loadChildren: () => import('./feature/user/user.module').then(m => m.UserModule)
      },
      {
        path: 'restaurants',
        loadChildren: () => import('./feature/restaurants/restaurants.module').then(m => m.RestaurantsModule)
      },
      {
        path: 'restaurant',
        loadChildren: () => import('./feature/restaurant/restaurant.module').then(m => m.RestaurantModule)
      },
      {
        path: 'promotions',
        loadChildren: () => import('./feature/promotions/promotions.module').then(m => m.PromotionsModule)
      },
      {
        path: 'promotion',
        loadChildren: () => import('./feature/promotion/promotion.module').then(m => m.PromotionModule)
      },
      {
        path: 'menu',
        loadChildren: () => import('./feature/menu/menu.module').then(m => m.MenuModule)
      },
      {
        path: 'menus',
        loadChildren: () => import('./feature/menus/menus.module').then(m => m.MenusModule)
      },
      {
        path: 'base-product',
        loadChildren: () => import('./feature/base-product/base-product.module').then(m => m.BaseProductModule)
      },
      {
        path: 'base-products',
        loadChildren: () => import('./feature/base-products/base-products.module').then(m => m.BaseProductsModule)
      },
      {
        path: 'product',
        loadChildren: () => import('./feature/product/product.module').then(m => m.ProductModule)
      },
      {
        path: 'area',
        loadChildren: () => import('./feature/area/area.module').then(m => m.AreaModule)
      },
      { path: 'error-page', component: ErrorPageComponent },
    ]
  },
  { path: 'auth', loadChildren: () => import('./feature/auth/auth.module').then(m => m.AuthModule) },
  { path: 'media-view/:id', component: MediaViewComponent, }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
