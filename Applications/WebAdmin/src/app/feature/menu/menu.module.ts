import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MenuRoutingModule } from './menu-routing.module';
import { SharedModule } from 'src/app/shared/share.module';
import { ProductsComponent } from './components/products/products.component';
import { MenuComponent } from './pages/menu/menu.component';
import { ProductTabComponent } from './components/product-tab/product-tab.component';
import { MenuTitleComponent } from './components/menu-title/menu-title.component';

@NgModule({
  declarations: [
    ProductsComponent,
    MenuComponent,
    ProductTabComponent,
    MenuTitleComponent,
  ],
  imports: [
    CommonModule,
    MenuRoutingModule,
    SharedModule.forRoot(),
  ]
})
export class MenuModule { }
