import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { NzTableQueryParams } from 'ng-zorro-antd/table';
import { FormAction } from 'src/app/core/const/form';
import { CATEGORIES, Category, CATEGORY_CHILD, CATEGORY_NAME } from 'src/app/core/models/category.model';
import { MenuItem } from 'src/app/core/models/menu_item.model';
import { SUBCATEGORY_NAME } from 'src/app/core/models/subcategory.model';
import { ProductsRequest } from 'src/app/core/requests/products.request';
import { ProductsResponse } from 'src/app/core/responses/products.response';
import { ProductService } from 'src/app/core/services/api/product.api.service';
import { LoaderService } from 'src/app/core/services/loader.service';

@Component({
  selector: 'app-product-tab',
  templateUrl: './product-tab.component.html',
  styleUrls: ['./product-tab.component.scss']
})
export class ProductTabComponent implements OnInit, OnChanges {
  @Input() categoryInput: Category;
  @Input() menu: MenuItem;

  productsRequest: ProductsRequest = new ProductsRequest();
  productsResponse: ProductsResponse = new ProductsResponse();

  category = Category;
  formAction = FormAction;

  categories = CATEGORIES;
  categoryName = CATEGORY_NAME;
  categoryChild = CATEGORY_CHILD;
  subCategoryName = SUBCATEGORY_NAME;

  constructor(
    public loaderService: LoaderService,
    private productService: ProductService,
    private router: Router,
  ) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.menu?.currentValue) {
      this.productsRequest.menuId = this.menu.id;
      this.loadData(this.productsRequest);
    }
  }

  ngOnInit(): void {
    this.productsRequest.category = this.categoryInput;
  }

  onQueryParamsChange(params: NzTableQueryParams): void {
    if (this.menu) {
      this.productsRequest.pageNumber = params.pageIndex;
      this.loadData(this.productsRequest);
    }
  }

  loadData(request: ProductsRequest): void {
    this.productService.list(request).subscribe(
      result => {
        this.productsResponse = result;
      }
    );
  }

  search() {
    this.loadData(this.productsRequest);
  }

  reset() {
    this.productsRequest.searchTerm = '';
    this.loadData(this.productsRequest);
  }

  goToProduct(formAction: FormAction, id: number) {
    localStorage.setItem(`${this.router.url}/product/${id}`, formAction.toString());
  }

  generateDetailUrl(id: number): string {
    return `product/${id}`;
  }

  subCategoryOnChange(event) {
    if (this.productsResponse.data.length === 0) {
      return;
    }
    this.productsRequest.subCategories = event;
    this.loadData(this.productsRequest);
  }

  delete(id) {
    this.productService.delete(id).subscribe(
      () => {
        this.loadData(this.productsRequest);
      }
    );
  }

  detail(id: number) {
    this.router.navigate(['product', id]);
  }
}
