import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CATEGORIES, Category, CATEGORY_NAME } from 'src/app/core/models/category.model';

@Component({
  selector: 'app-select-category',
  templateUrl: './select-category.component.html',
  styleUrls: ['./select-category.component.scss']
})
export class SelectCategoryComponent implements OnInit {
  @Input() isView = true;
  @Input() value = Category.SoupStarterSalad;
  @Output() selected: EventEmitter<Category> = new EventEmitter<Category>();

  categories = CATEGORIES;
  categoriesName = CATEGORY_NAME;

  constructor(
  ) { }

  ngOnInit(): void {
  }

}
