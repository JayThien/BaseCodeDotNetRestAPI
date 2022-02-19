import { Component, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Country } from 'src/app/core/model/country.model';
import { UserService } from 'src/app/core/service/api/configuration/user.api.service';
import { BaseConfiguration } from '../../../base-configuration';

@Component({
  selector: 'app-promotion',
  templateUrl: './promotion.component.html',
  styleUrls: ['./promotion.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class PromotionComponent extends BaseConfiguration implements OnInit {
  form = new FormGroup({
    id: new FormControl(0),
    imageUrl: new FormControl(''),
    code: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    from: new FormControl(new Date(), [Validators.required]),
    to: new FormControl(new Date(), [Validators.required]),
    maximumDiscount: new FormControl(0.0, [Validators.required]),
    minimumOrderPrice: new FormControl(0.0, [Validators.required]),
    discountPrice: new FormControl(0, [Validators.required]),
    isPercent: new FormControl(false, [Validators.required]),
    country: new FormControl(Country.Vietnam),
    areaId: new FormControl(-1),
    minPoint: new FormControl(0),
    maxPoint: new FormControl(1000),
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
      this.form.controls.imageUrl.setValue(data.imageUrl);
      this.form.controls.code.setValue(data.code);
      this.form.controls.description.setValue(data.description);
      this.form.controls.from.setValue(data.from);
      this.form.controls.to.setValue(data.to);
      this.form.controls.maximumDiscount.setValue(data.maximumDiscount);
      this.form.controls.minimumOrderPrice.setValue(data.minimumOrderPrice);
      this.form.controls.discountPrice.setValue(data.discountPrice);
      this.form.controls.isPercent.setValue(data.isPercent);
      this.form.controls.country.setValue(data.country);
      this.form.controls.areaId.setValue(data.areaId);
      this.form.controls.minPoint.setValue(data.minPoint);
      this.form.controls.maxPoint.setValue(data.maxPoint);
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
