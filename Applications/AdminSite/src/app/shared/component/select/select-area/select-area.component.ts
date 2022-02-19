import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Dropdown } from 'src/app/core/common/dropdown.model';
import { Category } from 'src/app/core/model/category.model';
import { AreaService } from 'src/app/core/service/api/configuration/area.api.service';

@Component({
  selector: 'app-select-area',
  templateUrl: './select-area.component.html',
  styleUrls: ['./select-area.component.scss']
})
export class SelectAreaComponent implements OnInit {
  @Input() isDisable = false;
  @Input() value!: number;
  @Output() valueOnChange: EventEmitter<number> = new EventEmitter<number>();

  areas: Dropdown[] = [];

  constructor(
    private areaService: AreaService
  ) { }

  ngOnInit(): void {
    this.areaService.dropdown().subscribe(
      result => {
        if (result.data) {
          this.areas = result.data;
        }
      }
    );
  }

  selected(event: any): void {
    this.valueOnChange.emit(event.value);
  }

}
