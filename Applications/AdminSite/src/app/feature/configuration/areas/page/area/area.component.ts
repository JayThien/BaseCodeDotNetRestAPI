import { Component, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Country } from 'src/app/core/model/country.model';
import { AreaService } from 'src/app/core/service/api/configuration/area.api.service';
import { BaseConfiguration } from '../../../base-configuration';

@Component({
  selector: 'app-area',
  templateUrl: './area.component.html',
  styleUrls: ['./area.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AreaComponent extends BaseConfiguration implements OnInit {
  form = new FormGroup({
    id: new FormControl(0),
    name: new FormControl('', [Validators.required]),
    code: new FormControl('', [Validators.required]),
    country: new FormControl(Country.Vietnam),
    userId: new FormControl(0),
  });

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private areaService: AreaService,
    public dialog: MatDialog,
  ) {
    super();
  }


  deserialize(data: any): void {
    if (data) {
      this.form.controls.id.setValue(data.id);
      this.form.controls.name.setValue(data.name);
      this.form.controls.code.setValue(data.code);
      this.form.controls.country.setValue(data.country);
      this.form.controls.userId.setValue(data.userId);
    }
  }

  ngOnInit(): void {
    this.deserialize(this.data);
  }

  create(): void {
    this.areaService.create(this.form.value).subscribe(
      result => {
        console.log(result);
      }
    );
  }

  save(): void {
    this.areaService.save(this.form.value).subscribe(
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
}
