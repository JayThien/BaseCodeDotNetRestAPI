import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BaseProductComponent } from './pages/base-product/base-product.component';

const routes: Routes = [
  { path: ':id', component: BaseProductComponent, },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BaseProductRoutingModule { }
