import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NzTableFilterFn, NzTableQueryParams } from 'ng-zorro-antd/table';
import { RoutingKey } from 'src/app/core/const/routing-key';
import { CATEGORIES, Category, CATEGORY_CHILD, CATEGORY_NAME } from 'src/app/core/models/category.model';
import { SUBCATEGORY_NAME } from 'src/app/core/models/subcategory.model';
import { BaseProductsRequest } from 'src/app/core/requests/base-products.request';

import { BaseProductsResponse } from 'src/app/core/responses/base-products.response';
import { APIService } from 'src/app/core/services/api.service';
import { BaseProductService } from 'src/app/core/services/api/base-product.api.service';
import { LoaderService } from 'src/app/core/services/loader.service';
import { RouterService } from 'src/app/core/services/router.service';

@Component({
  selector: 'app-base-products',
  templateUrl: './base-products.component.html',
  styleUrls: ['./base-products.component.scss']
})
export class BaseProductsComponent implements OnInit {
  expandSet = new Set<number>();

  categories = CATEGORIES;
  categoryName = CATEGORY_NAME;
  categoryChild = CATEGORY_CHILD;

  subCategoryName = SUBCATEGORY_NAME;

  visible = false;
  filterVisible = false;

  productsRequest: BaseProductsRequest = new BaseProductsRequest();
  productsResponse: BaseProductsResponse = new BaseProductsResponse();
  menuSubGroupFilterFn: NzTableFilterFn = (list: string[], item: any) => {
    return list.some(name => item.name.indexOf(name) !== -1);
  }

  constructor(
    private apiService: APIService,
    public loaderService: LoaderService,
    private activateRoute: ActivatedRoute,
    private router: Router,
    private baseProductService: BaseProductService,
    private routerService: RouterService
  ) { }

  loadData(request: BaseProductsRequest): void {
    this.baseProductService.getBaseProducts(request).subscribe(
      result => {
        this.productsResponse = result;
      }
    );
  }

  ngOnInit(): void {
    this.activateRoute.queryParams.subscribe(
      queryParams => {
        let selectedGroupId: number;
        if (queryParams.category) {
          // tslint:disable-next-line: radix
          selectedGroupId = Number.parseInt(queryParams.category);
        } else {
          selectedGroupId = Category.SoupStarterSalad;
        }
        this.productsRequest.category = selectedGroupId;
        this.productsRequest.subCategories = [];
        this.loadData(this.productsRequest);
      }
    );
  }

  onExpandChange(id: number, checked: boolean): void {
    if (checked) {
      this.expandSet.add(id);
    } else {
      this.expandSet.delete(id);
    }
  }

  onQueryParamsChange(params: NzTableQueryParams): void {
    this.productsRequest.pageNumber = params.pageIndex;
    this.loadData(this.productsRequest);
  }

  search() {
    this.loadData(this.productsRequest);
  }

  reset() {
    this.productsRequest.searchTerm = '';
    this.loadData(this.productsRequest);
  }

  subCategoryOnChange(event) {
    this.productsRequest.subCategories = event;
    this.loadData(this.productsRequest);
  }

  // changeStatus(id: number, status: boolean) {
  //   this.apiService.changeMenuItemStatus(id).subscribe(
  //     () => {
  //       this.productsResponse.data.find(p => p.id === id).isAvailable = !status;
  //     }
  //   );
  // }

  goToView(id) {
    this.routerService.navigateToDetail(`/base-product/${id}`);
  }
  goToCreate() {
    this.routerService.navigateToCreate(RoutingKey.BaseProduct);
  }
}
