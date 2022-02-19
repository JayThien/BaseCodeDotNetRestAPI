import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PaginationResponse } from 'src/app/core/common/pagination.response';
import { UsersRequest } from 'src/app/core/request/users.request';
import { PromotionService } from 'src/app/core/service/api/configuration/promotion.api.service';
import { UserService } from 'src/app/core/service/api/configuration/user.api.service';
import { PromotionComponent } from '../promotion/promotion.component';

@Component({
  selector: 'app-promotions',
  templateUrl: './promotions.component.html',
  styleUrls: ['./promotions.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class PromotionsComponent implements OnInit {
  displayedColumns: string[] = ['id', 'code', 'minPoint', 'maxPoint', 'from', 'to', 'discount'];
  userRequest: UsersRequest = new UsersRequest();
  userReponse: PaginationResponse<any> = new PaginationResponse<any>();

  constructor(
    public dialog: MatDialog,
    private promotionService: PromotionService
  ) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.promotionService.list(this.userRequest).subscribe(
      result => {
        this.userReponse = result;
      }
    );
  }

  pageOnChange(event: number): void {
    this.userRequest.pageNumber = event;
    this.loadData();
  }

  searchOnChange(event: string): void {
    this.userRequest.searchTerm = event;
    this.loadData();
  }

  create(): void {
    this.dialog.open(PromotionComponent, {
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
    this.dialog.open(PromotionComponent, {
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
