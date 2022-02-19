import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Country, COUNTRY_FLAG, COUNTRY_NAME } from 'src/app/core/models/country.model';
import { MenuItem } from 'src/app/core/models/menu_item.model';
import { APIService } from 'src/app/core/services/api.service';
import { MenuService } from 'src/app/core/services/api/menu.api.service';
import { LoaderService } from 'src/app/core/services/loader.service';

@Component({
  selector: 'app-menus',
  templateUrl: './menus.component.html',
  styleUrls: ['./menus.component.scss']
})
export class MenusComponent implements OnInit {
  data: MenuItem[] = [];
  vietnam: MenuItem[] = [];
  thailand: MenuItem[] = [];
  hongkong: MenuItem[] = [];
  philippines: MenuItem[] = [];
  slovakia: MenuItem[] = [];
  czechrepublic: MenuItem[] = [];


  countryName = COUNTRY_NAME;
  countryFlag = COUNTRY_FLAG;
  country = Country;

  constructor(
    public loaderService: LoaderService,
    private menuService: MenuService,
  ) { }

  ngOnInit(): void {
    this.loadData();
  }

  filterByCountry(country: Country): MenuItem[] {
    return this.data.filter(p => p.country === country);
  }

  loadData() {
    this.menuService.list().subscribe(
      result => {
        const data = result.data.filter(p => p.areaName !== 'All');
        this.vietnam = data.filter(p => p.country === this.country.Vietnam);
        this.thailand = data.filter(p => p.country === this.country.Thailand);
        this.hongkong = data.filter(p => p.country === this.country.HongKong);
        this.philippines = data.filter(p => p.country === this.country.Philippines);
        this.slovakia = data.filter(p => p.country === this.country.Slovakia);
        this.czechrepublic = data.filter(p => p.country === this.country.CzechRepublic);
      }
    );
  }
}
