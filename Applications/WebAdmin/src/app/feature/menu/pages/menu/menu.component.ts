import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';

import { Keys } from 'src/app/core/const/keys';
import { COUNTRY_FLAG, COUNTRY_NAME } from 'src/app/core/models/country.model';
import { MenuItem } from 'src/app/core/models/menu_item.model';
import { MenuService } from 'src/app/core/services/api/menu.api.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  menu: MenuItem = new MenuItem();

  countryFlag = COUNTRY_FLAG;
  countryName = COUNTRY_NAME;

  constructor(
    private activateRoute: ActivatedRoute,
    private menuService: MenuService,
  ) { }

  ngOnInit(): void {
    this.activateRoute.params.subscribe(
      p => {
        this.menuService.get(p.id).subscribe(
          result => {
            this.menu = result;
            console.log(this.menu);
          }
        );
      }
    );
  }
}
