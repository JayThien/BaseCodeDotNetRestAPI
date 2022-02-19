import { Component, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Country } from 'src/app/core/model/country.model';
import { AreaService } from 'src/app/core/service/api/configuration/area.api.service';
import { RestaurantService } from 'src/app/core/service/api/configuration/restaurant.api.service';
import { BaseConfiguration } from '../../../base-configuration';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class RestaurantComponent extends BaseConfiguration implements OnInit {
  form = new FormGroup({
    id: new FormControl(0),
    name: new FormControl('', [Validators.required]),
    address: new FormControl('', [Validators.required]),
    imageUrl: new FormControl('', [Validators.required]),
    phoneNumber: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.email, Validators.required]),
    openTime: new FormControl('11:00'),
    closeTime: new FormControl('22:00'),
    reservationLink: new FormControl(''),
    country: new FormControl(Country.Vietnam),
    userId: new FormControl(-1),
  });

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private restaurantService: RestaurantService,
    public dialog: MatDialog,
  ) {
    super();
  }


  deserialize(data: any): void {
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
      this.form.controls.userId.setValue(data.user?.id);
    }
  }

  ngOnInit(): void {
    this.deserialize(this.data);
  }

  create(): void {
    this.restaurantService.create(this.form.value).subscribe(
      result => {
        console.log(result);
      }
    );
  }

  save(): void {
    this.restaurantService.save(this.form.value).subscribe(
      result => {
        console.log(result);
      }
    );
  }

  selectedManager(event: number): void {
    this.form.controls.userId.setValue(event);
  }

  selectedCountry(event: number): void {
    this.form.controls.country.setValue(event);
  }

  openTimeSelected(event: string): void {
    this.form.controls.openTime.setValue(event);
  }

  closeTimeSelected(event: string): void {
    this.form.controls.closeTime.setValue(event);
  }

  uploaded(event: string): void {
    this.form.controls.imageUrl.setValue(event);
  }
}
