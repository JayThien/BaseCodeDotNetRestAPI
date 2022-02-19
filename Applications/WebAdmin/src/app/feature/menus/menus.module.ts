import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from 'src/app/shared/share.module';
import { MenusComponent } from './pages/menus/menus.component';
import { MenuItemComponent } from './components/menu-item/menu-item.component';
import { MenusRoutingModule } from './menus-routing.module';

@NgModule({
  declarations: [
    MenusComponent,
    MenuItemComponent,
  ],
  imports: [
    CommonModule,
    MenusRoutingModule,
    SharedModule.forRoot(),
  ]
})
export class MenusModule { }
