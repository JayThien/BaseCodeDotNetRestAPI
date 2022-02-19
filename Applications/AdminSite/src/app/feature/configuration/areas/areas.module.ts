import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AreasRoutingModule } from './areas-routing.module';
import { AreasComponent } from './page/areas/areas.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { AreaComponent } from './page/area/area.component';


@NgModule({
  declarations: [
    AreasComponent,
    AreaComponent
  ],
  imports: [
    CommonModule,
    AreasRoutingModule,
    SharedModule.forRoot()
  ]
})
export class AreasModule { }
