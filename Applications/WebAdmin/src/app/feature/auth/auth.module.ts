import { NgModule } from '@angular/core';

import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './components/login/login.component';

import { SharedModule } from 'src/app/shared/share.module';
import { ChangePasswordComponent } from './components/change-password/change-password.component';
import { AuthService } from './core/auth.service';
import { AuthAPIService } from '../../core/services/api/auth.api.service';

@NgModule({
  declarations: [
    LoginComponent,
    ChangePasswordComponent,
  ],
  imports: [
    AuthRoutingModule,
    SharedModule.forRoot(),
  ],
  providers: [
    AuthService,
    AuthAPIService,
  ]
})
export class AuthModule { }
