import { Component, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UserService } from 'src/app/core/service/api/configuration/user.api.service';
import { BaseConfiguration } from '../../../base-configuration';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class UserComponent extends BaseConfiguration implements OnInit {
  form = new FormGroup({
    id: new FormControl(0),
    fullname: new FormControl('', [Validators.required, Validators.minLength(3)]),
    dateOfBirth: new FormControl('', [Validators.required]),
    avatarURL: new FormControl(''),
    status: new FormControl(''),
    phoneNumber: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.email, Validators.required]),
    roleId: new FormControl(1, [Validators.required]),
    gender: new FormControl(true)
  });

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private userService: UserService,
    public dialog: MatDialog,
  ) {
    super();
  }


  deserialize(data: any): void {
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

  ngOnInit(): void {
    this.deserialize(this.data);
  }

  create(): void {
    this.userService.create(this.form.value).subscribe(
      result => {
        console.log(result);
      }
    );
  }

  save(): void {
    this.userService.save(this.form.value).subscribe(
      result => {
        console.log(result);
      }
    );
  }

  roleOnChange(event: any): void {
    this.form.controls.roleId.setValue(event);
  }

  uploaded(event: string): void {
    this.form.controls.avatarURL.setValue(event);
  }
}
