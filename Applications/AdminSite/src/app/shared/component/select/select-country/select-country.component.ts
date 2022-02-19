import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Dropdown } from 'src/app/core/common/dropdown.model';
import { COUNTRIES, Country, COUNTRY_FLAG, COUNTRY_NAME } from 'src/app/core/model/country.model';
import { RoleService } from 'src/app/core/service/api/role.api.service';

@Component({
  selector: 'app-select-country',
  templateUrl: './select-country.component.html',
  styleUrls: ['./select-country.component.scss']
})
export class SelectCountryComponent implements OnInit {
  @Input() isDisable = false;
  @Input() value!: Country;
  @Output() valueOnChange: EventEmitter<Country> = new EventEmitter<Country>();

  countries = COUNTRIES;
  countryName = COUNTRY_NAME;
  countryFlag = COUNTRY_FLAG;

  constructor(
  ) { }

  ngOnInit(): void {
  }

  selected(event: any): void {
    this.valueOnChange.emit(event.value);
  }

}
