import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Category, CATEGORY_CHILD } from 'src/app/core/model/category.model';
import { COUNTRIES, Country, COUNTRY_FLAG, COUNTRY_NAME } from 'src/app/core/model/country.model';
import { SUBCATEGORIES, SubCategory, SUBCATEGORY_NAME } from 'src/app/core/model/subcategory.model';

@Component({
  selector: 'app-select-sub-category',
  templateUrl: './select-sub-category.component.html',
  styleUrls: ['./select-sub-category.component.scss']
})
export class SelectSubCategoryComponent implements OnInit, OnChanges {
  @Input() isDisable = false;
  @Input() value!: Country;
  @Input() category!: Category;
  @Output() valueOnChange: EventEmitter<Country> = new EventEmitter<Country>();

  subCategories: SubCategory[] = SUBCATEGORIES;
  subCategoryName = SUBCATEGORY_NAME;

  constructor(
  ) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.category?.currentValue) {
      this.subCategories = CATEGORY_CHILD.get(this.category) || [];
    }
  }

  ngOnInit(): void {
  }

  selected(event: any): void {
    this.valueOnChange.emit(event.value);
  }

}
