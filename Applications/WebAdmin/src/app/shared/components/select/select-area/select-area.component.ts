import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { Area } from 'src/app/core/models/area.model';
import { Country } from 'src/app/core/models/country.model';
import { AreasRequest } from 'src/app/core/requests/areas.request';
import { AreaService } from 'src/app/core/services/api/area.api.service';

@Component({
  selector: 'app-select-area',
  templateUrl: './select-area.component.html',
  styleUrls: ['./select-area.component.scss']
})
export class SelectAreaComponent implements OnInit, OnChanges {
  @Input() isView = true;
  @Input() value: Area;
  @Input() country: Country;
  @Output() selected: EventEmitter<number> = new EventEmitter<number>();

  areas: Area[] = [];
  areasStorage: string;
  selectedArea: Area;

  constructor(
    private areaService: AreaService
  ) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.country) {
      if (this.areas.length > 0) {
        this.filterByCountry(this.country);
        this.value = this.areas.filter(p => p.name === 'All')[0];
      }
    }
  }

  ngOnInit(): void {
    this.areaService.dropdown().subscribe(
      result => {
        this.areasStorage = JSON.stringify(result.data);
        this.filterByCountry(this.country);
      }
    );
  }

  filterByCountry(country: Country) {
    const areasStoraged = JSON.parse(this.areasStorage);
    this.areas = areasStoraged.filter((p: { country: Country; }) => p.country === country);
  }
}
