import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AreaComponent } from './page/area/area.component';
import { AreasComponent } from './page/areas/areas.component';


const routes: Routes = [

  { path: '', component: AreasComponent, },
  { path: ':id', component: AreaComponent, },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AreasRoutingModule { }
