import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutComponent } from './layout/layout.component';
import { SidenavComponent } from './layout/components/sidenav/sidenav.component';
import { UserBriefComponent } from './layout/components/user-brief/user-brief.component';
import { SharedModule } from './shared/shared.module';
import { NotificationSidenavComponent } from './layout/components/notification-sidenav/notification-sidenav.component';
import { httpInterceptorProviders } from './core/interceptor';
import { MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    UserBriefComponent,
    SidenavComponent,
    NotificationSidenavComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule.forRoot(),
    HttpClientModule,
  ],
  providers: [
    httpInterceptorProviders,
    { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: { hasBackdrop: true } }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
