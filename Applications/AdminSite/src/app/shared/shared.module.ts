import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AvatarComponent } from './component/avatar/avatar.component';
import { ModuleWithProviders } from '@angular/core';
import { AppMaterialModule } from './app-material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaginatorComponent } from './component/paginator/paginator.component';
import { SearchBoxComponent } from './component/search-box/search-box.component';
import { SelectRoleComponent } from './component/select/select-role/select-role.component';
import { ValidationMessageComponent } from './component/validation-message/validation-message.component';
import { PhoneDirective } from './directives/phone.directive';
import { PhonePipe } from './pipes/currency.pipe';
import { UploaderComponent } from './component/uploader/uploader.component';
import { DropzoneDirective } from './directives/dropzone.directive';
import { SelectCountryComponent } from './component/select/select-country/select-country.component';
import { SelectUserComponent } from './component/select/select-user/select-user.component';
import { SelectTimeComponent } from './component/select/select-time/select-time.component';
import { SelectCategoryComponent } from './component/select/select-category/select-category.component';
import { SelectSubCategoryComponent } from './component/select/select-sub-category/select-sub-category.component';
import { SelectAreaComponent } from './component/select/select-area/select-area.component';

@NgModule({
  declarations: [
    AvatarComponent,
    PaginatorComponent,
    ValidationMessageComponent,
    UploaderComponent,
    SearchBoxComponent,

    // Select
    SelectRoleComponent,
    SelectCountryComponent,
    SelectUserComponent,
    SelectTimeComponent,
    SelectCategoryComponent,
    SelectSubCategoryComponent,
    SelectAreaComponent,

    // Directive
    PhoneDirective,
    DropzoneDirective,

    // Pipe
    PhonePipe,

    UploaderComponent,
  ],
  imports: [
    CommonModule,
    AppMaterialModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  exports: [
    // Module
    AppMaterialModule,
    ReactiveFormsModule,
    FormsModule,

    AvatarComponent,
    PaginatorComponent,
    SearchBoxComponent,
    ValidationMessageComponent,
    UploaderComponent,
    // Select
    SelectRoleComponent,
    SelectCountryComponent,
    SelectUserComponent,
    SelectTimeComponent,
    SelectCategoryComponent,
    SelectSubCategoryComponent,
    SelectAreaComponent,

    // Directive
    PhoneDirective,
    DropzoneDirective,

    // Pipe
    PhonePipe,
  ],
  entryComponents: [
    UploaderComponent,
  ]
})

export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule,
      providers: [
      ],
    };
  }
}
