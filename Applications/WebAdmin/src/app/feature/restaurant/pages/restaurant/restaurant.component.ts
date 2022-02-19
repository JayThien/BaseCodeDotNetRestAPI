import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzModalService } from 'ng-zorro-antd/modal';
import { BaseWizard } from 'src/app/core/common/base-wizard';
import { Country } from 'src/app/core/models/country.model';
import { APIService } from 'src/app/core/services/api.service';
import { LoaderService } from 'src/app/core/services/loader.service';
import { RouterService } from 'src/app/core/services/router.service';
import { WizardService } from 'src/app/core/services/wizard.service';

@Component({
  selector: 'app-wizard-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.scss']
})
export class RestaurantComponent extends BaseWizard implements OnInit {

  constructor(
    private apiService: APIService,
    public loaderService: LoaderService,
    protected modal: NzModalService,
    public wizardService: WizardService,
    public router: Router,
  ) {
    super(modal, wizardService);
  }

  initForm(): void {
    this.form = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required]),
      imageUrl: new FormControl('', [Validators.required]),
      phoneNumber: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.email, Validators.required]),
      openTime: new FormControl('3/12/2020 11:00'),
      closeTime: new FormControl('3/12/2020 22:00'),
      reservationLink: new FormControl(''),
      country: new FormControl(Country.Vietnam),
      userId: new FormControl(-1),
    });
  }

  ngOnInit(): void {
    if (!this.wizardService._isCreate) {
      this.loadData();
    }
  }

  save() {
    this.apiService.updateRestaurant(this.form.value).subscribe(
      () => {
      }
    );
  }

  create() {
    this.apiService.createRestaurant(this.form.value).subscribe(
      result => {
        this.router.navigate(['/restaurants/']);
      }
    );
  }

  deserialize(data: any) {
    if (data) {
      this.form.controls.id.setValue(data.id);
      this.form.controls.name.setValue(data.name);
      this.form.controls.address.setValue(data.address);
      this.form.controls.imageUrl.setValue(data.imageUrl);
      this.form.controls.phoneNumber.setValue(data.phoneNumber);
      this.form.controls.email.setValue(data.email);
      this.form.controls.openTime.setValue(data.openTime);
      this.form.controls.closeTime.setValue(data.closeTime);
      this.form.controls.reservationLink.setValue(data.reservationLink);
      this.form.controls.country.setValue(data.country);
    }
  }

  uploaded(event) {
    this.form.controls.imageUrl.setValue(event.uploadedPath);
  }

  loadData() {
    this.apiService.getRestaurant(this.wizardService._id).subscribe(
      result => {
        this.deserialize(result);
      }
    );
  }

  countryOnChange(event: number) {
    this.form.controls.country.setValue(event);
  }

  userOnChange(event){

  }
}
