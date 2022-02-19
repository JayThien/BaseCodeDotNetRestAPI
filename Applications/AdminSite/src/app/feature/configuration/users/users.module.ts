import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UsersComponent } from './page/users/users.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { UserComponent } from './page/user/user.component';


@NgModule({
  declarations: [
    UsersComponent,
    UserComponent
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    SharedModule.forRoot()
  ]
})
export class UsersModule { }
