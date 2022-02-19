import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Dropdown } from 'src/app/core/common/dropdown.model';
import { CATEGORIES, Category, CATEGORY_NAME } from 'src/app/core/model/category.model';
import { COUNTRIES, Country, COUNTRY_FLAG, COUNTRY_NAME } from 'src/app/core/model/country.model';
import { RoleService } from 'src/app/core/service/api/role.api.service';

@Component({
  selector: 'app-select-category',
  templateUrl: './select-category.component.html',
  styleUrls: ['./select-category.component.scss']
})
export class SelectCategoryComponent implements OnInit {
  @Input() isDisable = false;
  @Input() value!: Category;
  @Output() valueOnChange: EventEmitter<Category> = new EventEmitter<Category>();

  categories = CATEGORIES;
  categoryName = CATEGORY_NAME;

  constructor(
  ) { }

  ngOnInit(): void {
  }

  selected(event: any): void {
    this.valueOnChange.emit(event.value);
  }

}
