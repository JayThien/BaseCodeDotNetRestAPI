import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { COUNTRIES, Country, COUNTRY_FLAG, COUNTRY_NAME } from 'src/app/core/models/country.model';

@Component({
  selector: 'app-select-country',
  templateUrl: './select-country.component.html',
  styleUrls: ['./select-country.component.scss']
})
export class SelectCountryComponent implements OnInit {
  @Input() isView = true;
  @Input() value: Country;
  @Output() selected: EventEmitter<number> = new EventEmitter<number>();

  countries = COUNTRIES;
  countryName = COUNTRY_NAME;
  countryFlag = COUNTRY_FLAG;

  selectedCountry: Country;

  constructor(
  ) { }


  ngOnInit(): void {
  }
}
