import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './page/user/user.component';
import { UsersComponent } from './page/users/users.component';


const routes: Routes = [

  { path: '', component: UsersComponent, },
  { path: ':id', component: UserComponent, },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
