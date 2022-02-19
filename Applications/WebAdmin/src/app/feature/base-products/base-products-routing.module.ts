import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BaseProductsComponent } from './pages/base-products/base-products.component';

const routes: Routes = [
  { path: '', component: BaseProductsComponent, },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BaseProductsRoutingModule { }
