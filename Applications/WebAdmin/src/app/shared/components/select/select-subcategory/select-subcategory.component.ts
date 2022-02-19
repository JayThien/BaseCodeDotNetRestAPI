import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Category, CATEGORY_CHILD } from 'src/app/core/models/category.model';
import { SUBCATEGORIES, SubCategory, SUBCATEGORY_NAME } from 'src/app/core/models/subcategory.model';

@Component({
  selector: 'app-select-subcategory',
  templateUrl: './select-subcategory.component.html',
  styleUrls: ['./select-subcategory.component.scss']
})
export class SelectSubCategoryComponent implements OnInit, OnChanges {
  @Input() isView = true;
  @Input() value: SubCategory;
  @Input() category: Category;
  @Output() selected: EventEmitter<SubCategory> = new EventEmitter<SubCategory>();

  subCategories = SUBCATEGORIES;
  subCategoriesName = SUBCATEGORY_NAME;

  constructor(
  ) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.category) {
      this.subCategories = CATEGORY_CHILD.get(this.category);
    }
  }

  ngOnInit(): void {
  }

}
