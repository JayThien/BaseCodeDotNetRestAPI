import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzDatePickerComponent } from 'ng-zorro-antd/date-picker';
import { NzModalService } from 'ng-zorro-antd/modal';
import { BaseWizard } from 'src/app/core/common/base-wizard';
import { Area } from 'src/app/core/models/area.model';
import { Country, COUNTRY_CURRENCY } from 'src/app/core/models/country.model';
import { AreasRequest } from 'src/app/core/requests/areas.request';
import { APIService } from 'src/app/core/services/api.service';
import { AreaService } from 'src/app/core/services/api/area.api.service';
import { PromotionService } from 'src/app/core/services/api/promotion.api.service';
import { LoaderService } from 'src/app/core/services/loader.service';
import { RouterService } from 'src/app/core/services/router.service';
import { WizardService } from 'src/app/core/services/wizard.service';

@Component({
  selector: 'app-wizard-promotion',
  templateUrl: './promotion.component.html',
  styleUrls: ['./promotion.component.scss']
})
export class PromotionComponent extends BaseWizard implements OnInit {
  startValue: Date | null = null;
  endValue: Date | null = null;

  @ViewChild('endDatePicker') endDatePicker!: NzDatePickerComponent;

  countryCurrency = COUNTRY_CURRENCY;
  disabledStartDate = (startValue: Date): boolean => {
    if (!startValue || !this.form.value.to) {
      return false;
    }
    return startValue.getTime() > this.form.value.to.getTime();
  }

  disabledEndDate = (endValue: Date): boolean => {
    if (!endValue || !this.form.value.from) {
      return false;
    }
    return endValue.getTime() <= this.form.value.from.getTime();
  }

  handleStartOpenChange(open: boolean): void {
    if (!open) {
      this.endDatePicker.open();
    }
  }

  handleEndOpenChange(open: boolean): void {
  }

  constructor(
    private apiService: APIService,
    public loaderService: LoaderService,
    protected modal: NzModalService,
    public wizardService: WizardService,
    public router: Router,
    private promotionService: PromotionService,
  ) {
    super(modal, wizardService);
  }

  initForm(): void {
    this.form = new FormGroup({
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
    this.promotionService.create(this.form.value).subscribe(
      result => {
        console.log(result);
      }
    );
  }

  deserialize(data: any) {
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

  uploaded(event) {
    this.form.controls.imageUrl.setValue(event.uploadedPath);
  }

  loadData() {
    this.promotionService.get(this.wizardService._id).subscribe(
      result => {
        console.log(result);
        this.deserialize(result);
      }
    );
  }

  countryOnChange(event: number) {
    this.form.controls.country.setValue(event);
  }

  areaOnChange(event: number) {
    this.form.controls.areaId.setValue(event);
  }
}
