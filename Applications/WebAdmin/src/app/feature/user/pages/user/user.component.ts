import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NzModalService } from 'ng-zorro-antd/modal';
import { BaseWizard } from 'src/app/core/common/base-wizard';
import { Gender, GENDER } from 'src/app/core/const/gender';
import { ACCOUNT_TYPE } from 'src/app/core/const/select/account-type';
import { Select } from 'src/app/core/const/select/select';
import { Dropdown } from 'src/app/core/models/dropdown.model';
import { APIService } from 'src/app/core/services/api.service';
import { RoleService } from 'src/app/core/services/api/role.api.service';
import { LoaderService } from 'src/app/core/services/loader.service';
import { RouterService } from 'src/app/core/services/router.service';
import { WizardService } from 'src/app/core/services/wizard.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent extends BaseWizard implements OnInit {
  //  declare const dropdown data
  genderDropdown = GENDER;
  accountTypeDropdown = ACCOUNT_TYPE;

  // declare variable loaded from api
  restaurant: string;

  // declare logic variable
  restaurants: Select[] = [];

  roleDropdowns: Dropdown[] = [];

  get roleName(): string {
    if (this.roleDropdowns.length === 0) {
      return '';
    }
    return this.roleDropdowns.filter(p => p.value === this.form.value.roleId)[0].label;
  }

  constructor(
    private apiService: APIService,
    public loaderService: LoaderService,
    protected routerService: RouterService,
    protected modal: NzModalService,
    public wizardService: WizardService,
    private roleService: RoleService
  ) {
    super(modal, wizardService);
  }

  ngOnInit(): void {
    this.roleService.dropdown().subscribe(
      result => {
        this.roleDropdowns = result.data;
      }
    );
    if (!this.wizardService._isCreate) {
      this.loadData();
    }
  }

  initForm(): void {
    this.form = new FormGroup({
      id: new FormControl(0),
      fullname: new FormControl('', [Validators.required]),
      dateOfBirth: new FormControl('', [Validators.required]),
      avatarURL: new FormControl(''),
      status: new FormControl(''),
      phoneNumber: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.email, Validators.required]),
      roleId: new FormControl(1, [Validators.required]),
      gender: new FormControl(true)
    });
  }

  deserialize(data: any) {
    if (data) {
      this.form.controls.id.setValue(data.id);
      this.form.controls.fullname.setValue(data.fullname);
      this.form.controls.dateOfBirth.setValue(data.dateOfBirth);
      this.form.controls.avatarURL.setValue(data.avatarURL);
      this.form.controls.status.setValue(data.status);
      this.form.controls.phoneNumber.setValue(data.phoneNumber);
      this.form.controls.email.setValue(data.email);
      this.form.controls.roleId.setValue(data.roleId);
      this.form.controls.gender.setValue(data.gender);
    }
  }

  save() {
    this.apiService.updateUser(this.form.value).subscribe(
      () => {
        this.loadData();
      }
    );
  }

  uploaded(event: any) {
    this.form.controls.avatarURL.setValue(event.uploadedPath);
  }

  create() {
    this.apiService.createUser(this.form.value).subscribe(
      () => {
      }
    );
  }

  loadData() {
    this.apiService.getUser(this.wizardService._id).subscribe(
      result => {
        this.deserialize(result);
      }
    );
  }
}
