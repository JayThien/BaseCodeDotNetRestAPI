import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UploaderComponent } from './components/uploader/uploader.component';
import { WaitingComponent } from './components/waiting/waiting.component';
import { UserSelectComponent } from './components/user-select/user-select.component';
import { UserMentionComponent } from './components/user-mention/user-mention.component';
import { NgZorroAntModule } from './ng-zorro-antd.module';
import { MediaViewComponent } from './components/media-view/media-view.component';
import { SafePipe } from './pipes/safe.pipe';
import { HasClaimDirective } from './directives/has-claim.directive';
import { ErrorPageComponent } from './components/error-page/error-page.component';
import { ValidationMessageComponent } from './components/validation-message/validation-message.component';
import { PhoneDirective } from './directives/phone.directive';
import { PhonePipe } from './pipes/phone.pipe';
import { SelectAreaComponent } from './components/select/select-area/select-area.component';
import { SelectCategoryComponent } from './components/select/select-category/select-category.component';
import { SelectCountryComponent } from './components/select/select-country/select-country.component';
import { SelectRestaurantComponent } from './components/select/select-restaurant/select-restaurant.component';
import { SelectSubCategoryComponent } from './components/select/select-subcategory/select-subcategory.component';
import { SelectUserComponent } from './components/select/select-user/select-user.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgZorroAntModule,
    ReactiveFormsModule,
  ],
  declarations: [
    SafePipe,
    PhonePipe,

    HasClaimDirective,

    PhoneDirective,
    UploaderComponent,
    WaitingComponent,
    UserSelectComponent,
    UserMentionComponent,
    MediaViewComponent,
    ErrorPageComponent,
    ValidationMessageComponent,

    SelectRestaurantComponent,
    SelectCategoryComponent,
    SelectSubCategoryComponent,
    SelectCountryComponent,
    SelectAreaComponent,
    SelectUserComponent,
  ],
  providers: [
    DatePipe
  ],
  exports: [
    CommonModule,
    FormsModule,
    NgZorroAntModule,
    ReactiveFormsModule,

    PhonePipe,

    HasClaimDirective,
    PhoneDirective,

    // select
    SelectRestaurantComponent,
    SelectCategoryComponent,
    SelectSubCategoryComponent,
    SelectCountryComponent,
    SelectAreaComponent,
    SelectUserComponent,

    UploaderComponent,
    WaitingComponent,
    UserSelectComponent,
    UserMentionComponent,
    MediaViewComponent,
    ErrorPageComponent,
    ValidationMessageComponent
  ],
  entryComponents: [
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
