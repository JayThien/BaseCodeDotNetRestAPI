import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NzTableQueryParams } from 'ng-zorro-antd/table';
import { FormAction } from 'src/app/core/const/form';
import { Country, COUNTRY_FLAG, COUNTRY_NAME } from 'src/app/core/models/country.model';
import { RestaurantsRequest } from 'src/app/core/requests/restaurants.request';
import { RestaurantResponse } from 'src/app/core/responses/restaurants.response';
import { APIService } from 'src/app/core/services/api.service';
import { LoaderService } from 'src/app/core/services/loader.service';
import { RouterService } from 'src/app/core/services/router.service';

@Component({
  selector: 'app-restaurants',
  templateUrl: './restaurants.component.html',
  styleUrls: ['./restaurants.component.scss']
})
export class RestaurantsComponent implements OnInit {
  restaurantsResponse: RestaurantResponse = new RestaurantResponse();
  restaurantsRequest: RestaurantsRequest = new RestaurantsRequest();

  formAction = FormAction;
  countryName = COUNTRY_NAME;
  countryFlag = COUNTRY_FLAG;

  constructor(
    private apiService: APIService,
    public loaderService: LoaderService,
    private router: Router,
    private routerService: RouterService,
  ) { }

  ngOnInit(): void {
    this.loadData();
  }

  filterByCountry() {
    this.loadData();
  }

  loadData() {
    this.apiService.getRestaurants(this.restaurantsRequest).subscribe(
      result => {
        this.restaurantsResponse = result;
      }
    );
  }

  onQueryParamsChange(params: NzTableQueryParams): void {
    this.restaurantsRequest.pageNumber = params.pageIndex;
    this.loadData();
  }

  create() {
    this.router.navigate(['wizard/restaurant/0']);
  }

  changeStatus(id: number) {
    this.apiService.changeRestaurantStatus(id).subscribe();
  }


  detail(id: number) {
    this.router.navigate(['restaurant', id]);
  }

}
