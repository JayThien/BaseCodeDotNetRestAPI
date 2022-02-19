import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BaseProductComponent } from './page/base-product/base-product.component';
import { BaseProductsComponent } from './page/base-products/base-products.component';


const routes: Routes = [

  { path: '', component: BaseProductsComponent, },
  { path: ':id', component: BaseProductComponent, },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BaseProductsRoutingModule { }
