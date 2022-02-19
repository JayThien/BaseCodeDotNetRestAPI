import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PaginationResponse } from 'src/app/core/common/pagination.response';
import { UsersRequest } from 'src/app/core/request/users.request';
import { UserService } from 'src/app/core/service/api/configuration/user.api.service';
import { UserComponent } from '../user/user.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class UsersComponent implements OnInit {
  displayedColumns: string[] = ['fullname', 'email', 'phoneNumber', 'roleName'];
  userRequest: UsersRequest = new UsersRequest();
  userReponse: PaginationResponse<any> = new PaginationResponse<any>();

  constructor(
    public dialog: MatDialog,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.userService.list(this.userRequest).subscribe(
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
    this.dialog.open(UserComponent, {
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
    this.dialog.open(UserComponent, {
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
