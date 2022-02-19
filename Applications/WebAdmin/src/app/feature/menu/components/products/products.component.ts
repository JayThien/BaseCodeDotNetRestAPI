import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CATEGORIES, CATEGORY_CHILD, CATEGORY_NAME } from 'src/app/core/models/category.model';
import { MenuItem } from 'src/app/core/models/menu_item.model';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  @Input() menu: MenuItem;
  selectedTab = 0;
  categories = CATEGORIES;
  categoryName = CATEGORY_NAME;
  categoryChild = CATEGORY_CHILD;

  constructor(
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(
      result => {
        if (result.tab) {
          this.selectedTab = result.tab;
        } else {
          this.selectedTab = 0;
        }
      }
    );
  }

}
