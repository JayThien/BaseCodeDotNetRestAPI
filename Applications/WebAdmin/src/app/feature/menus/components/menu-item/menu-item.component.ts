import { Component, Input, OnInit } from '@angular/core';
import { Area } from 'src/app/core/models/area.model';
import { Country, COUNTRY_FLAG, COUNTRY_NAME } from 'src/app/core/models/country.model';
import { MenuItem } from 'src/app/core/models/menu_item.model';
import { AreasRequest } from 'src/app/core/requests/areas.request';
import { AreaService } from 'src/app/core/services/api/area.api.service';
import { MenuService } from 'src/app/core/services/api/menu.api.service';

@Component({
  selector: 'app-menu-item',
  templateUrl: './menu-item.component.html',
  styleUrls: ['./menu-item.component.scss']
})
export class MenuItemComponent implements OnInit {
  @Input() country: Country;
  @Input() menuItems: MenuItem[] = [];

  areas: Area[] = [];
  areaId: number;

  countryName = COUNTRY_NAME;
  countryFlag = COUNTRY_FLAG;

  gridStyle = {
    textAlign: 'center',
    position: 'relative'
  };

  constructor(
    private areaService: AreaService,
    private menuService: MenuService,
  ) { }

  ngOnInit(): void {
    // this.areaService.list(new AreasRequest()).subscribe(
    //   result => {
    //     if (result?.data) {
    //       this.areas = result.data.filter(p => p.country === this.country);
    //     }
    //   }
    // );
  }

  get lastItemIndex(): number {
    return this.menuItems.length - 1;
  }

  add() {
    this.menuItems.push({
      id: 0,
      areaId: -1,
      areaName: '',
      country: this.country,
    });
  }

  save() {
    this.menuItems[this.lastItemIndex].areaId = this.areaId;
    this.menuService.create(this.menuItems[this.lastItemIndex]).subscribe(
      result => {
        // update last item
        this.menuItems[this.lastItemIndex].id = result;
        this.menuItems[this.lastItemIndex].areaName = this.areas.filter(
          p => p.id === this.menuItems[this.lastItemIndex].areaId
        )[0].name;
        this.areaId = -1;
      }
    );
  }

  discard() {
    this.menuItems.pop();
  }

  delete(item: MenuItem) {
    this.menuService.delete(item.id).subscribe(
      () => {
        this.menuItems.splice(this.menuItems.indexOf(item), 1);
      }
    );
  }
}
