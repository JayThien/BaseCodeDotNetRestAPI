import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AreaRoutingModule } from './area-routing.module';
import { SharedModule } from 'src/app/shared/share.module';
import { AreaDetailComponent } from './components/area-detail/area-detail.component';
import { AreaComponent } from './pages/area/area.component';

@NgModule({
  declarations: [
    AreaComponent,
    AreaDetailComponent,
  ],
  imports: [
    CommonModule,
    AreaRoutingModule,
    SharedModule.forRoot(),
  ]
})
export class AreaModule { }
