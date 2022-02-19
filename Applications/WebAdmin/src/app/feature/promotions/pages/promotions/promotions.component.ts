import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NzTableQueryParams } from 'ng-zorro-antd/table';
import { FormAction } from 'src/app/core/const/form';
import { Country, COUNTRY_FLAG, COUNTRY_NAME } from 'src/app/core/models/country.model';
import { PromotionsRequest } from 'src/app/core/requests/promotions.request';
import { RestaurantsRequest } from 'src/app/core/requests/restaurants.request';
import { PromotionsResponse } from 'src/app/core/responses/promotions.response';
import { RestaurantResponse } from 'src/app/core/responses/restaurants.response';
import { APIService } from 'src/app/core/services/api.service';
import { PromotionService } from 'src/app/core/services/api/promotion.api.service';
import { LoaderService } from 'src/app/core/services/loader.service';
import { RouterService } from 'src/app/core/services/router.service';

@Component({
  selector: 'app-promotions',
  templateUrl: './promotions.component.html',
  styleUrls: ['./promotions.component.scss']
})
export class PromotionsComponent implements OnInit {
  promotionsResponse: PromotionsResponse = new PromotionsResponse();
  promotionsRequest: PromotionsRequest = new PromotionsRequest();

  formAction = FormAction;
  countryName = COUNTRY_NAME;
  countryFlag = COUNTRY_FLAG;

  constructor(
    private promotionService: PromotionService,
    public loaderService: LoaderService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.loadData();
  }

  filterByCountry() {
    this.loadData();
  }

  loadData() {
    this.promotionService.list(this.promotionsRequest).subscribe(
      result => {
        this.promotionsResponse = result;
      }
    );
  }

  onQueryParamsChange(params: NzTableQueryParams): void {
    this.promotionsRequest.pageNumber = params.pageIndex;
    this.loadData();
  }

  create() {
    this.router.navigate(['wizard/restaurant/0']);
  }

  detail(id: number) {
    this.router.navigate(['promotion', id]);
  }

}
