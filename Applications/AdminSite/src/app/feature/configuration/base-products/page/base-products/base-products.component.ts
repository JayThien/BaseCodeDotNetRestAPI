import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PaginationResponse } from 'src/app/core/common/pagination.response';
import { UserService } from 'src/app/core/service/api/configuration/user.api.service';
import { BaseProductComponent } from '../base-product/base-product.component';
import { BaseProductsRequest } from 'src/app/core/request/base-products.request';
import { CATEGORIES, CATEGORY_NAME } from 'src/app/core/model/category.model';
import { BaseProductService } from 'src/app/core/service/api/configuration/base-product.api.service';
import { SUBCATEGORY_NAME } from 'src/app/core/model/subcategory.model';

@Component({
  selector: 'app-base-products',
  templateUrl: './base-products.component.html',
  styleUrls: ['./base-products.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class BaseProductsComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'category', 'subCategory'];
  baseProductRequest: BaseProductsRequest = new BaseProductsRequest();
  baseProductResponse: PaginationResponse<any> = new PaginationResponse<any>();

  categories = CATEGORIES;
  categoryName = CATEGORY_NAME;
  subCategoryName = SUBCATEGORY_NAME;

  constructor(
    public dialog: MatDialog,
    private baseProductService: BaseProductService
  ) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.baseProductService.list(this.baseProductRequest).subscribe(
      result => {
        this.baseProductResponse = result;
      }
    );
  }

  pageOnChange(event: number): void {
    this.baseProductRequest.pageNumber = event;
    this.loadData();
  }

  searchOnChange(event: string): void {
    this.baseProductRequest.searchTerm = event;
    this.loadData();
  }

  create(): void {
    this.dialog.open(BaseProductComponent, {
      maxWidth: '500px',
      disableClose: true,
      panelClass: 'custom-mat-dialog'
    }).afterClosed().subscribe(
      result => {
        this.loadData();
      }
    );
  }

  detail(user: any): void {
    this.dialog.open(BaseProductComponent, {
      data: user,
      maxWidth: '500px',
      disableClose: true,
      panelClass: 'custom-mat-dialog'
    }).afterClosed().subscribe(
      result => {
        this.loadData();
      }
    );
  }

  categoryOnChange(event: any): void {
    this.baseProductRequest.categories = event.value;
    this.loadData();
  }
}
