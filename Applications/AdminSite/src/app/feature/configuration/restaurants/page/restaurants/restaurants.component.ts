import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PaginationResponse } from 'src/app/core/common/pagination.response';
import { COUNTRY_NAME } from 'src/app/core/model/country.model';
import { RestaurantsRequest } from 'src/app/core/request/restaurants.request';
import { RestaurantService } from 'src/app/core/service/api/configuration/restaurant.api.service';
import { RestaurantComponent } from '../restaurant/restaurant.component';


@Component({
  selector: 'app-restaurants',
  templateUrl: './restaurants.component.html',
  styleUrls: ['./restaurants.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class RestaurantsComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'email', 'phoneNumber', 'openTime', 'closeTime', 'country', 'manager'];
  restaurantsRequest: RestaurantsRequest = new RestaurantsRequest();
  restaurantsReponse: PaginationResponse<any> = new PaginationResponse<any>();

  countryName = COUNTRY_NAME;

  constructor(
    public dialog: MatDialog,
    private restaurantService: RestaurantService
  ) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.restaurantService.list(this.restaurantsRequest).subscribe(
      result => {
        this.restaurantsReponse = result;
      }
    );
  }

  pageOnChange(event: number): void {
    this.restaurantsRequest.pageNumber = event;
    this.loadData();
  }

  searchOnChange(event: string): void {
    this.restaurantsRequest.searchTerm = event;
    this.loadData();
  }

  create(): void {
    this.dialog.open(RestaurantComponent, {
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
    this.dialog.open(RestaurantComponent, {
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
}
