import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NzModalService } from 'ng-zorro-antd/modal';
import { Area } from 'src/app/core/models/area.model';
import { Country } from 'src/app/core/models/country.model';
import { Dropdown } from 'src/app/core/models/dropdown.model';
import { APIService } from 'src/app/core/services/api.service';
import { UserService } from 'src/app/core/services/api/user.api.service';
import { LoaderService } from 'src/app/core/services/loader.service';

@Component({
  selector: 'app-area-detail',
  templateUrl: './area-detail.component.html',
  styleUrls: ['./area-detail.component.scss']
})
export class AreaDetailComponent implements OnInit {
  @Input() area: Area;
  form: FormGroup;
  users: Dropdown[] = [];

  constructor(
    public loaderService: LoaderService,
    private userService: UserService,
    protected modal: NzModalService,
  ) {
  }


  ngOnInit(): void {

    this.initForm();
    if (this.area.id) {
      this.deserialize(this.area);
    }
  }

  initForm(): void {
    this.form = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('', [Validators.required]),
      code: new FormControl('', [Validators.required]),
      country: new FormControl(Country.Vietnam),
      userId: new FormControl(0),
    });
  }

  deserialize(data: any) {
    if (data) {
      this.form.controls.id.setValue(data.id);
      this.form.controls.name.setValue(data.name);
      this.form.controls.code.setValue(data.code);
      this.form.controls.country.setValue(data.country);
      this.form.controls.userId.setValue(data.userId);
    }
  }

  countryOnChange(event) {
    this.form.controls.country.setValue(event);
  }

  userOnChange(event) {
    this.form.controls.userId.setValue(event);
  }
}
