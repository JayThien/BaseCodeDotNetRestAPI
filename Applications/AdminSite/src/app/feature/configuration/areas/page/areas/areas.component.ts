import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PaginationResponse } from 'src/app/core/common/pagination.response';
import { COUNTRY_NAME } from 'src/app/core/model/country.model';
import { AreasRequest } from 'src/app/core/request/areas.request';
import { AreaService } from 'src/app/core/service/api/configuration/area.api.service';
import { UserComponent } from '../../../users/page/user/user.component';
import { AreaComponent } from '../area/area.component';


@Component({
  selector: 'app-areas',
  templateUrl: './areas.component.html',
  styleUrls: ['./areas.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AreasComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'code', 'country', 'manager'];
  areasRequest: AreasRequest = new AreasRequest();
  areasReponse: PaginationResponse<any> = new PaginationResponse<any>();

  countryName = COUNTRY_NAME;

  constructor(
    public dialog: MatDialog,
    private areaService: AreaService
  ) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.areaService.list(this.areasRequest).subscribe(
      result => {
        this.areasReponse = result;
      }
    );
  }

  pageOnChange(event: number): void {
    this.areasRequest.pageNumber = event;
    this.loadData();
  }

  searchOnChange(event: string): void {
    this.areasRequest.searchTerm = event;
    this.loadData();
  }

  create(): void {
    this.dialog.open(AreaComponent, {
      maxWidth: '400px',
      disableClose: true,
      panelClass: 'custom-mat-dialog'
    }).afterClosed().subscribe(
      result => {
        this.loadData();
      }
    );
  }

  detail(user: any): void {
    this.dialog.open(AreaComponent, {
      data: user,
      maxWidth: '400px',
      disableClose: true,
      panelClass: 'custom-mat-dialog'
    }).afterClosed().subscribe(
      result => {
        this.loadData();
      }
    );
  }
}
