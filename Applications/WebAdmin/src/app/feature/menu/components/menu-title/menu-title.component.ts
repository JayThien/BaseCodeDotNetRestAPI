import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { Keys } from 'src/app/core/const/keys';
import { Area } from 'src/app/core/models/area.model';
import { COUNTRIES, Country, COUNTRY_FLAG, COUNTRY_NAME } from 'src/app/core/models/country.model';
import { MenuItem } from 'src/app/core/models/menu_item.model';
import { AreasRequest } from 'src/app/core/requests/areas.request';
import { AreaService } from 'src/app/core/services/api/area.api.service';
import { MenuService } from 'src/app/core/services/api/menu.api.service';
import { LoaderService } from 'src/app/core/services/loader.service';

@Component({
  selector: 'app-menu-title',
  templateUrl: './menu-title.component.html',
  styleUrls: ['./menu-title.component.scss']
})
export class MenuTitleComponent implements OnInit, OnChanges {
  @Input() menu: MenuItem = new MenuItem();

  form = new FormGroup({
    id: new FormControl(0),
    areaName: new FormControl(''),
    areaId: new FormControl(0, [Validators.required, Validators.min(0)]),
    country: new FormControl(Country.Vietnam, [Validators.required]),
  });

  countryFlag = COUNTRY_FLAG;
  countryName = COUNTRY_NAME;
  countries = COUNTRIES;
  isView = true;

  areas: Area[] = [];
  areasStorage: string;

  constructor(
    public loaderService: LoaderService,
    private areaService: AreaService,
    private menuService: MenuService,
  ) {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.menu?.currentValue) {
      this.deserialize(this.menu);
    }
  }

  ngOnInit(): void {
    this.areaService.list(new AreasRequest()).subscribe(
      result => {
        if (result?.data) {
          this.areasStorage = JSON.stringify(result.data);
          this.areas = result.data.filter(p => p.country === this.form.value.country);
        }
      }
    );
  }

  deserialize(data: any) {
    if (data) {
      this.form.controls.id.setValue(data.id);
      this.form.controls.areaName.setValue(data.areaName);
      this.form.controls.areaId.setValue(data.areaId);
      this.form.controls.country.setValue(data.country);
    }
  }

  save() {
    if (!this.form.valid) {
      return;
    }
    this.menuService.update(this.form.value).subscribe(
      () => {
        this.isView = true;
        this.form.controls.AreaName.setValue(this.areas.filter(p => p.id === this.form.value.AreaId)[0].name);
        localStorage.setItem(Keys.MenuItem, JSON.stringify(this.form.value));
      }
    );
  }


  uploaded(event) {
    this.form.controls.imageUrl.setValue(event.uploadedPath);
  }


  countryOnChange(event: number) {
    this.areas = JSON.parse(this.areasStorage).filter((p: { country: number; }) => p.country === event);
    this.form.controls.AreaId.setValue(-1);
  }

  discard() {
    this.isView = true;
  }
}
